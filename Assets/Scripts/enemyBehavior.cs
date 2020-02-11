using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){
		if((col.gameObject.tag == "unlock") || (col.gameObject.tag == "shoot") || (col.gameObject.tag == "throw")){
			col.gameObject.SetActive(false);
			Application.LoadLevel (Application.loadedLevel);
		} else if(col.gameObject.tag == "missile"){
			Destroy(gameObject);
		}
	}
}
