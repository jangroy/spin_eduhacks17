using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCubeRot : MonoBehaviour {

	public float speed = 10f;  // degrees per second to rotate in each axis. Set in inspector.

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right, speed * Time.deltaTime);
	}
}

