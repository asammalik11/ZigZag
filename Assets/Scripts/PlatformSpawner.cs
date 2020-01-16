using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject coin;
	Vector3 lastPos;
	float size;
	public bool gameOver;

	// Use this for initialization
	void Start () {
		
	}

	public void StartSpawningPlatform(){
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;

		for (int i = 0; i < 20; i++){
			SpawnPlatform();
		}

		InvokeRepeating ("SpawnPlatform", 2f, 0.2f);
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver == true) {
			CancelInvoke ("SpawnPlatform");
		}
	}

	void SpawnPlatform(){
		int rand = Random.Range (0, 10);

		if (rand < 5) {
			SpawnX ();
		}
		if (rand >= 5) {
			SpawnZ ();
		}

	}

	void SpawnX(){
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 8);
		if (rand < 1) {
			Instantiate (coin, new Vector3(pos.x,pos.y +1,pos.z), coin.transform.rotation);
		}

	}

	void SpawnZ() {
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 6);
		if (rand < 1) {
			Instantiate (coin, new Vector3(pos.x,pos.y +1,pos.z), coin.transform.rotation);
		}
	}
}
