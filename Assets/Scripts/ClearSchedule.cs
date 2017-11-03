using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ClearSchedule : MonoBehaviour {

	public GameObject clearPanel;
	public GameObject errorPanel;
	public GameObject checkPanel;
	public List<CheckCollision> days;

	private string clearString;
	private char startingLetter;
	private int startingInteger;
	private char lastLetter;
	private int lastInteger;
	private string courses;
	private List<string> courseList;
	private char delimeter;
	// Use this for initialization
	void Start () {

		courses = "";
		clearString = "";
		startingLetter = 'A';
		startingInteger = 1;
		lastLetter = 'E';
		lastInteger = 9;
		courseList = new List<string> ();
		delimeter = System.Convert.ToChar (17);
		//PlayerPrefs.DeleteAll ();
		
	}

	public void OpenClearPanel()
	{
		courses = "";

		if (PlayerPrefs.HasKey ("Available Courses"))
			courses = PlayerPrefs.GetString ("Available Courses");

		if (courses != "") 
		{
			clearPanel.SetActive (true);
			checkPanel.SetActive (true);
			if (errorPanel.activeSelf)
				errorPanel.SetActive (false);
		}
		else 
		{
			clearPanel.SetActive (true);
			errorPanel.SetActive (true);
			if (checkPanel.activeSelf)
				checkPanel.SetActive (false);
		}

		clearPanel.GetComponent<RectTransform> ().SetAsLastSibling ();
		
	}

	public void DeleteAllEntries()
	{
		courses = "";

		if (PlayerPrefs.HasKey("Available Courses"))
			PlayerPrefs.SetString("Available Courses", clearString);

		for (char i = startingLetter; i <= lastLetter; i++)
		{
			for (int j = startingInteger; j <= lastInteger; ++j) 
			{
				if (PlayerPrefs.HasKey (i + j.ToString ())) 
				{
					courses = PlayerPrefs.GetString (i + j.ToString ());
					if (courses != "") 
					{
						courseList = courses.Split (delimeter).ToList<string> ();
						for (int k = 0; k < courseList.Count; k++) 
						{
							if (PlayerPrefs.HasKey (courseList [k])) 
							{
								PlayerPrefs.DeleteKey (courseList [k]);
								PlayerPrefs.DeleteKey (courseList [k] + " Count");
								if (PlayerPrefs.HasKey (courseList [k] + " Final")) 
								{
									PlayerPrefs.DeleteKey (courseList [k] + " Final");
									int midtermCount = PlayerPrefs.GetInt (courseList [k] + " Midterm Count");
									for (int m = 1; m <= midtermCount; m++)
										PlayerPrefs.DeleteKey (courseList [k] + " Midterm " + m.ToString ());
									PlayerPrefs.DeleteKey (courseList [k] + " Midterm Count");
								}
								if (PlayerPrefs.HasKey (courseList [0] + " Quiz Count")) 
								{
									int quizCount = PlayerPrefs.GetInt (courseList [0] + " Quiz Count");
									for (int m = 1; m <= quizCount; m++)
										PlayerPrefs.DeleteKey (courseList [0] + " Quiz " + m.ToString ());
									PlayerPrefs.DeleteKey (courseList [0] + " Quiz Count");
								}
								if (PlayerPrefs.HasKey (courseList [0] + " Lab Count")) 
								{
									int labCount = PlayerPrefs.GetInt (courseList [0] + " Lab Count");
									for (int m = 1; m <= labCount; m++)
										PlayerPrefs.DeleteKey (courseList [0] + " Lab " + m.ToString ());
									PlayerPrefs.DeleteKey (courseList [0] + " Lab Count");
								}
								if (PlayerPrefs.HasKey (courseList [0] + " Homework Count")) 
								{
									int homeworkCount = PlayerPrefs.GetInt (courseList [0] + " Homework Count");
									for (int m = 1; m <= homeworkCount; m++)
										PlayerPrefs.DeleteKey (courseList [0] + " Homework " + m.ToString ());
									PlayerPrefs.DeleteKey (courseList [0] + " Homework Count");
								}
							}
						}
						PlayerPrefs.SetString (i + j.ToString (), clearString);
					}
				}
			}
		}

		for (int i = 0; i < days.Count; ++i)
			days [i].ClearColor ();

		clearPanel.SetActive (false);
		errorPanel.SetActive (false);
		checkPanel.SetActive (false);
	}
}