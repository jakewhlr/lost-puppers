using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAbilities : MonoBehaviour {
	// public GameObject collidingDoor;

	playerControls parentPlayers;
	public GameObject missilePrefab;

	float shotDelay;
	float lastShot;
    GameObject playerController;
    int direction;


    void Start(){
		parentPlayers = gameObject.GetComponent<Transform>().parent.gameObject.GetComponent<playerControls>();
		shotDelay = 0.5f;
		lastShot = Time.time;
        playerController = GameObject.Find("Players");
    }

	void Update(){
        direction = playerController.GetComponent<playerControls>().direction;
        if (gameObject == parentPlayers.currentCharacter){
			if(gameObject.tag == "shoot"){
				if(Input.GetKeyDown(KeyCode.F)){
					Shoot();
				}
			}
		}
	}

	void Shoot(){
		if(Time.time - lastShot > shotDelay){
			Instantiate(missilePrefab, transform.position + (transform.right * 1f * direction), Quaternion.identity);
			lastShot = Time.time;
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if(gameObject == parentPlayers.currentCharacter){
			switch(gameObject.tag){
				case "unlock":
					if(Input.GetKeyDown(KeyCode.F)){
						if(col.gameObject.tag == "door"){
							col.gameObject.SetActive(false);
						}
					}
				break;
				case "throw":
					if(Input.GetKeyDown(KeyCode.F)){
						if((col.gameObject.tag == "shoot") || (col.gameObject.tag == "unlock")){

							col.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.up * 1500) + (transform.right * 500 * direction));
						}
					}
				break;
			}
		}
	}

}
