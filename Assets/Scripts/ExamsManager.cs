using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ExamsManager : MonoBehaviour {

	public Text courseName;
	public GameObject content;
	public GameObject buttonPrefab;

	private int midtermCount;
	private int finalGrade;
	public bool goingToOpen;

	void Awake()
	{
		midtermCount = 0;
		finalGrade = 0;
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
		if (!PlayerPrefs.HasKey (courseName.text + " Final"))
			PlayerPrefs.SetInt (courseName.text + " Final", finalGrade);
		else
			finalGrade = PlayerPrefs.GetInt (courseName.text + " Final");

		if (!PlayerPrefs.HasKey (courseName.text + " Midterm Count"))
			PlayerPrefs.SetInt (courseName.text + " Midterm Count", midtermCount);
		else
			midtermCount = PlayerPrefs.GetInt (courseName.text + " Midterm Count");

		foreach (Transform child in content.transform) 
			Destroy (child.gameObject);

		for (int i = 1; i <= midtermCount; ++i) 
		{
			GameObject temp = Instantiate (buttonPrefab, content.transform);
			temp.transform.Find ("Text").GetComponent<Text> ().text = " Midterm " + i.ToString ();
		}

		GameObject finalButton = Instantiate(buttonPrefab, content.transform);
		finalButton.transform.Find("Text").GetComponent<Text>().text = " Final";

		goingToOpen = false;

	}

}
