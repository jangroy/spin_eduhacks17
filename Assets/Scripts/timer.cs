using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
	public float timeLeft = 5;
	public Text timerText;
	public Button btn;

	void Start () 
	{
		// bind timerText to textdisplay
		timerText = GameObject.Find("txtTimer").GetComponent<Text>();
		Button btn = GameObject.Find("btnStart").GetComponent<Button>();
		btn.onClick.AddListener (taskOnClick1);
	}

	void taskOnClick1() 
	{
		Debug.Log ("void taskOnClick1 here");
		btn.gameObject.SetActive (false);
		Debug.Log ("btn.gameObject.activeSelf = " + btn.gameObject.activeSelf);
	}

	// Update is called once per frame
	void Update () 
	{
		if (btn.gameObject.activeSelf == false) 
		{
			if (timeLeft > 0) 
			{
				timeLeft -= Time.deltaTime; 
				timerText.text = Mathf.FloorToInt(timeLeft + 1).ToString();
			} 
			else 
			{
				timerText.text = "Finished";
			}
		}
	}

}
