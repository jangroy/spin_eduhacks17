using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByScene(string sceneName) {
		Application.LoadLevel (sceneName);
	}
}
