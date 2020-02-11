using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {
	int speed;
	int jump_thrust = 1000;
	int jump_counter;

	GameObject[] characters = new GameObject[3];
	int currentCharacterIndex;
	public GameObject currentCharacter;
	Color tempColor;

	GameObject collidingDoor;
	GameObject collidingPlayer;

	float lastJump;
	float jumpDelay;
    public int direction;

	void Awake() {
		for(int i = 0; i < 3; i++){
			characters[i] = transform.GetChild(i).gameObject;
			setInactive(characters[i]);
		}
		currentCharacterIndex = 0;
		setActive(characters[currentCharacterIndex]);
		jumpDelay = 1.25f;
        direction = 1;
	}

	void Update () {
		if(Input.GetKey(KeyCode.LeftShift)){
			speed = 15;
		}
		else{
			speed = 8;
		}

        if(Input.GetKey("left")){
            currentCharacter.GetComponent<Animator>().ResetTrigger("MoveIdle");
            currentCharacter.GetComponent<Animator>().SetTrigger("MoveLeft");
			currentCharacter.GetComponent<Transform>().Translate(-speed * Time.deltaTime, 0, 0);
            direction = -1;
        } else if( Input.GetKeyUp("left") ) {
            currentCharacter.GetComponent<Animator>().ResetTrigger("MoveLeft");
            currentCharacter.GetComponent<Animator>().SetTrigger("MoveIdle");
        }

        if (Input.GetKey("right")){
            currentCharacter.GetComponent<Animator>().ResetTrigger("MoveIdle");
            currentCharacter.GetComponent<Animator>().SetTrigger("MoveRight");
			currentCharacter.GetComponent<Transform>().Translate(speed * Time.deltaTime, 0, 0);
            direction = 1;
        } else if( Input.GetKeyUp("right") ) {
            currentCharacter.GetComponent<Animator>().ResetTrigger("MoveRight");
            currentCharacter.GetComponent<Animator>().SetTrigger("MoveIdle");
        }


        if (Input.GetKeyDown("space")){
			setInactive(currentCharacter);
			currentCharacterIndex = (currentCharacterIndex + 1) % 3;
			setActive(characters[currentCharacterIndex]);
		}
		if(Input.GetKeyDown("up")){
			if(Time.time - lastJump > jumpDelay){
				currentCharacter.GetComponent<Rigidbody2D>().AddForce(transform.up * jump_thrust);
				lastJump = Time.time;
			}
		}
		if(jump_counter > 0){
			jump_counter--;
		}
	}

	void setActive(GameObject character){
		Color tempColor;
		currentCharacter = character;
		tempColor = character.GetComponent<SpriteRenderer>().color;
		tempColor.a = 1f;
		character.GetComponent<SpriteRenderer>().color = tempColor;
	}

	void setInactive(GameObject character){
		Color tempColor;
		tempColor = character.GetComponent<SpriteRenderer>().color;
		tempColor.a = 0.5f;
		character.GetComponent<SpriteRenderer>().color = tempColor;
	}
}
