using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCubeRot : MonoBehaviour {

	//public float speed = 10f;  // degrees per second to rotate in each axis. Set in inspector.

	public float speedx = 1f;
	public float speedy = 1f;
	public float speedz = 1f;

	// Update is called once per frame
	void Update () {
		transform.Rotate(speedx, speedy, speedz);
		//transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}

