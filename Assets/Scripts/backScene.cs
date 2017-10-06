using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backScene : MonoBehaviour {

	// Use this for initialization
	public void back () {
		SceneManager.LoadScene("menuScene");
	}
}
