using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float speed;
	public bool started;
	public bool gameOver;
	Rigidbody rb;

	public GameObject particle;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if(Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;

				GameManager.instance.StartGame ();
			}
		}
			
		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			Camera.main.GetComponent<CameraFollow> ().gameOver = true;
			rb.velocity = new Vector3 (0, -25f, 0);

			GameManager.instance.StopGame ();

		}


		if (Input.GetMouseButtonDown (0) && !gameOver) {
			SwitchDirection();
		}
	}

	void SwitchDirection () {
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Coin") {
			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part, 1f);
		}
	}
}
