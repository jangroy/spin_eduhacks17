using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createScript : MonoBehaviour {
	public GameObject appleobject;
	public GameObject bananaobject;
	public int matrix = 3;
	private bool [,,] cubes = new bool[3,3,3];

	public void fillcubeArray() {
		for(int a = 0; a < matrix; a++){
			for(int b = 0; b < matrix; b++){
				for(int c = 0; c < matrix; c++) {
					cubes[a,b,c] = (Random.value > 0.5f);
				}
			}
		}
	}

	public void button_onClick(){
		Destroy(GameObject.Find("Object group1"));
		Destroy(GameObject.Find("Object group2"));
		Destroy(GameObject.Find("Object group3"));
		Destroy(GameObject.Find("Object group4"));
		fillcubeArray ();
		GameObject gogo1 = makeObjectWithPosition(cubes, new Vector3(0,0,0),"Object group1");
		fillcubeArray ();
		GameObject gogo2 = makeObjectWithPosition(cubes, new Vector3(500,0,0),"Object group2");
		fillcubeArray ();
		GameObject gogo3 = makeObjectWithPosition(cubes, new Vector3(510,0,0),"Object group3");
		fillcubeArray ();
		GameObject gogo4 = makeObjectWithPosition(cubes, new Vector3(520,0,0),"Object group4");
	}

	// Use this for initialization
	void Start () {
		fillcubeArray ();
	}

	// Update is called once per frame
	void Update () {

	}

	private GameObject makeObjectWithPosition(bool[,,] randomArray, Vector3 position, string name){
		GameObject objects = new GameObject ();
		for(int a = 0; a < matrix; a++){
			for(int b = 0; b < matrix; b++){
				for(int c = 0; c < matrix; c++) {
					if (randomArray [a, b, c]) {
						if ((a + b + c) % 2 == 0) {
							GameObject go = Instantiate (appleobject, new Vector3 (position.x+a-1, position.y+b-1, -c + position.z+1), Quaternion.Euler (0, 0, 0)) as GameObject;
							go.transform.parent = objects.transform;
						} else {
							GameObject go2 = Instantiate (bananaobject, new Vector3 (position.x+a-1, position.y+b-1, -c+position.z+1), Quaternion.Euler (0, 0, 0)) as GameObject;
							go2.transform.parent = objects.transform;
						}
					}
				}
			}
		}
		objects.name = name;
		objects.AddComponent (System.Type.GetType("rotateScript"));
		return objects;
	}
}
