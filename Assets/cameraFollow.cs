using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public GameObject players;

   Transform playerPos;

	void Start () {
		playerPos = players.GetComponent<playerControls>().currentCharacter.transform;

	}

	// Update is called once per frame
	void Update () {
		playerPos = players.GetComponent<playerControls>().currentCharacter.transform;
		Vector3 position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
		transform.position = position;
	}
}
