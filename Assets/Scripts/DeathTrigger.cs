using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

	void Start(){
	}

	void Update(){
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "unlock" || other.gameObject.tag == "shoot" || other.gameObject.tag == "throw"){
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
