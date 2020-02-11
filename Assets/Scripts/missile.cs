using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int direction = GameObject.Find("Players").GetComponent<playerControls>().direction;
		Destroy(gameObject, 3.5f);
		GetComponent<Rigidbody2D>().AddForce((transform.right * 500 * direction) + (transform.up * 250));
	}

	// Update is called once per frame
	void Update () {

	}
}
