using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start(){

	}

	// Update is called once per frame
	void Update(){

	}

	void OnCollisionEnter2D (Collision2D other){
		if(SceneManager.GetActiveScene().name == "Level 1"){
			SceneManager.LoadScene("Level 2");
		}

		else if(SceneManager.GetActiveScene().name == "Level 2"){
			SceneManager.LoadScene ("Level 3");
		}

		else if(SceneManager.GetActiveScene().name == "Level 3"){
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
