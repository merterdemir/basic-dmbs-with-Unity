using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuizesManager : MonoBehaviour {

	public Text courseName;
	public GameObject content;
	public GameObject buttonPrefab;

	private int quizCount;
	public bool goingToOpen;

	void Awake()
	{
		quizCount = 0;
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
		if (!PlayerPrefs.HasKey (courseName.text + " Quiz Count"))
			PlayerPrefs.SetInt (courseName.text + " Quiz Count", quizCount);
		else
			quizCount = PlayerPrefs.GetInt (courseName.text + " Quiz Count");

		foreach (Transform child in content.transform) 
			Destroy (child.gameObject);

		if (quizCount == 0) 
		{
			GameObject temp = Instantiate (buttonPrefab, content.transform);
			temp.transform.Find ("Text").GetComponent<Text> ().text = " No quizes";
			temp.GetComponent<Button> ().interactable = false;
		}
		else 
		{
			for (int i = 1; i <= quizCount; ++i) {
				GameObject temp = Instantiate (buttonPrefab, content.transform);
				temp.transform.Find ("Text").GetComponent<Text> ().text = " Quiz " + i.ToString ();
			}
		}
		goingToOpen = false;

	}

}
