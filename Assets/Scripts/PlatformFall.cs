using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

	public float fallDelay = 1f;

	private Vector3 originalposition;
	private Rigidbody2D rb2d;

	void Start(){
		originalposition = transform.position;
	}

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void OnCollisionStay2D (Collision2D other){
		if(other.gameObject.tag == "unlock" || other.gameObject.tag == "shoot" || other.gameObject.tag == "throw"){
			Invoke ("Fall", fallDelay);
		}
	}

	void Fall()
	{
		rb2d.isKinematic = false;
		Invoke ("PlatformSpawn", 2f);
	}

	void PlatformSpawn(){
		rb2d.isKinematic = true;
		rb2d.velocity = new Vector3 (0, 0, 0);
		transform.position = originalposition;
		rb2d.freezeRotation = true;
		rb2d.rotation = 0;
	}
}
