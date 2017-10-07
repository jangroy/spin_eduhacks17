using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createObjectScript : MonoBehaviour {
	public GameObject appleobject;
	public GameObject bananaobject;
	public GameObject arrow;
	public Text notifyCorrectText;
	private float time;

	private int matrix;
	private bool [,,] cubes;
	private int[] coordinates = { 0, 400, 600, 800, -1000};

	private void fillcubeArray() {
		for(int a = 0; a < matrix; a++){
			for(int b = 0; b < matrix; b++){
				for(int c = 0; c < matrix; c++) {
					cubes[a,b,c] = (Random.value > 0.5f);
				}
			}
		}
	}

	private void resetCameraLocation() {
		for (int a = 0; a < 5; a++) {
			int cameraNumber = a + 1;
			GameObject.FindWithTag ("camera" + cameraNumber.ToString()).transform.position = new Vector3(coordinates [a+1],0,-5);
		}
	}

	private void randomizeCameraLocation() {
		int[] tempArray = { 1, 2, 3 ,4 };
		int[] randomizedArray = randomizeArray (tempArray);

		for (int a = 0; a < randomizedArray.Length; a++) {
			int cameraNumber = randomizedArray[a];
			GameObject.FindWithTag ("camera" + cameraNumber.ToString()).transform.position = new Vector3(coordinates [a+1],0,-5);
		}
	}

	// Big O(n^2) please fix them later for practice. 
	// array is going to be short all the time because array size indicates the number of cameras in the scene.

	//This function returns new randomized array of input array.
	private int [] randomizeArray(int [] array) {
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		int [] newArray = new int[array.Length];
		for (int a = 0; a < array.Length; a++) {
			newArray [a] = array [a];
		}

		for (int t = 0; t < newArray.Length; t++ )
		{
			int tmp = newArray[t];
			int r = Random.Range(t, newArray.Length);
			newArray[t] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}

	public void setUpGame() {
		destoryObjects ();
		instantiateGame ();
	}	

	public void instantiateGame(){
//		resetCameraLocation ();
		randomizeCameraLocation ();
		fillcubeArray ();
		GameObject gogo1 = makeObjectWithPosition(cubes, new Vector3(coordinates[0],0,0),"Object group1");
		GameObject gogo5 = makeObjectWithPosition(cubes, new Vector3(coordinates[4],0,0),"Object group1(1)");
		fillcubeArray ();
		GameObject gogo2 = makeObjectWithPosition(cubes, new Vector3(coordinates[1],0,0),"Object group2");
		fillcubeArray ();
		GameObject gogo3 = makeObjectWithPosition(cubes, new Vector3(coordinates[2],0,0),"Object group3");
		fillcubeArray ();
		GameObject gogo4 = makeObjectWithPosition(cubes, new Vector3(coordinates[3],0,0),"Object group4");

	}

	public void button_onClick(string cameraNumber){
		Debug.Log ("I clicked " + cameraNumber);
		if (GameObject.FindWithTag ("camera" + cameraNumber).transform.position.x == coordinates[4]) {
			changeTextWithNotify ("Correct!");
			setUpGame ();
		} else {
			Debug.Log ("Wrong,please try again.");
			changeTextWithNotify ("Please try again.");
			whenIncorrect ();
		}
	}

	private void changeTextWithNotify(string text) {
		notifyCorrectText.text = text;
		enableText ();
		CancelInvoke("disableText");
		Invoke ("disableText", 1);
	}

	private void enableText() {
		notifyCorrectText.enabled = true; 
	}

	private void disableText() {
		notifyCorrectText.enabled = false; 
	}

	public void whenIncorrect(){
		//Do Something
	}


	// Use this for initialization
	void Start () {
		matrix = PlayerPrefs.GetInt("difficulty");
		cubes = new bool[PlayerPrefs.GetInt("difficulty"), PlayerPrefs.GetInt("difficulty"), PlayerPrefs.GetInt("difficulty")];
		GameObject arrowTxt = (GameObject)GameObject.Find("arrow");
		// arrowTxt.transform.SetParent("Object Group1");

		// Debug.Log(PlayerPrefs.GetInt("difficulty"));
		fillcubeArray ();
//		notifyCorrectText.text = "";
		setUpGame();
//		resetCameraLocation ();
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
							GameObject aObject = Instantiate (appleobject, new Vector3 (position.x+a-1, position.y+b-1, -c + position.z+1), Quaternion.Euler (0, 0, 0)) as GameObject;
							if (name == "Object group1") {
								aObject.AddComponent (System.Type.GetType("rotateScript"));
							}
							aObject.transform.parent = objects.transform;
						} else {
							GameObject bObject = Instantiate (bananaobject, new Vector3 (position.x+a-1, position.y+b-1, -c+position.z+1), Quaternion.Euler (0, 0, 0)) as GameObject;
							if (name == "Object group1") {
								bObject.AddComponent (System.Type.GetType("rotateScript"));
							}
							bObject.transform.parent = objects.transform;
						}
					}
				}
			}
		}
		if (name == "Object group1") {
			GameObject gameArrow = Instantiate (arrow) as GameObject;
			gameArrow.AddComponent (System.Type.GetType ("rotateScript"));
			gameArrow.transform.parent = objects.transform;
			Debug.Log ("print tis");
		}
		objects.name = name;
//		objects.AddComponent (System.Type.GetType("rotateScript"));
		return objects;
	}

	public void destoryObjects(){
		Destroy(GameObject.Find("Object group1"));
		Destroy(GameObject.Find("Object group2"));
		Destroy(GameObject.Find("Object group3"));
		Destroy(GameObject.Find("Object group4"));
		Destroy(GameObject.Find("Object group1(1)"));
	}
}
