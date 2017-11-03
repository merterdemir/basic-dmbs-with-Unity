using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HomeworksManager : MonoBehaviour {

	public Text courseName;
	public GameObject content;
	public GameObject buttonPrefab;

	private int homeworkCount;
	public bool goingToOpen;

	void Awake()
	{
		homeworkCount = 0;
		goingToOpen = false;
		Redesign ();
	}

	void Update()
	{
		if (goingToOpen)
			Redesign ();
	}

	void Redesign()
	{
		if (!PlayerPrefs.HasKey (courseName.text + " Homework Count"))
			PlayerPrefs.SetInt (courseName.text + " Homework Count", homeworkCount);
		else
			homeworkCount = PlayerPrefs.GetInt (courseName.text + " Homework Count");

		foreach (Transform child in content.transform) 
			Destroy (child.gameObject);

		if (homeworkCount == 0) 
		{
			GameObject temp = Instantiate (buttonPrefab, content.transform);
			temp.transform.Find ("Text").GetComponent<Text> ().text = " No homeworks";
			temp.GetComponent<Button> ().interactable = false;
		}
		else 
		{
			for (int i = 1; i <= homeworkCount; ++i) {
				GameObject temp = Instantiate (buttonPrefab, content.transform);
				temp.transform.Find ("Text").GetComponent<Text> ().text = " Homework " + i.ToString ();
			}
		}
		goingToOpen = false;

	}

}
