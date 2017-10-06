using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menuController : MonoBehaviour {
	public Component[] buttons;
  void Start()
    {
		//buttons [] 0 = play, 1 = fidget, 2 = help, 3,4,5, = difficulty
		buttons = GetComponentsInChildren<Button>(true);
		buttons[0].GetComponent<Button>().onClick.AddListener(TaskOnClick);
		buttons[1].GetComponent<Button>().onClick.AddListener(loadFigdet);
		// for (int i = 0; i < buttons.Length; i++) 
		// 	{
		// 		Debug.Log("buttons[" + i + "]: " + buttons[i]);
		// 	}
    }

		void loadFigdet() {
			SceneManager.LoadScene("fidgetScene");
		}
    void TaskOnClick()
    {	
		// Debug.Log(buttons[0].gameObject);
		buttons[0].gameObject.SetActive(false);
		buttons[1].gameObject.SetActive(false);
		
		buttons[3].gameObject.SetActive(true);
		buttons[3].GetComponent<Button>().onClick.AddListener(() => SetDifLoadScene(3));
		buttons[4].gameObject.SetActive(true);
		buttons[4].GetComponent<Button>().onClick.AddListener(() => SetDifLoadScene(4));
		// buttons[5].gameObject.SetActive(true);
		// buttons[5].GetComponent<Button>().onClick.AddListener(() => SetDifLoadScene(5));
    }
    void SetDifLoadScene(int difficultyNum)
    {	
		if (difficultyNum == 3) 
		{
			PlayerPrefs.SetInt("difficulty", 2);
			SceneManager.LoadScene("playScene");
		} 
		else if (difficultyNum == 4) 
		{
			PlayerPrefs.SetInt("difficulty", 3);
			SceneManager.LoadScene("playScene");
		}
		// else 
		// {
		// 	PlayerPrefs.SetString("difficulty", "hard");
		// 	SceneManager.LoadScene("playScene");
		// }
		Debug.Log("difficulty = " + PlayerPrefs.GetInt("difficulty"));
    }
}

