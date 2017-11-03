using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DeleteCourseButton : MonoBehaviour {

	public TMP_Dropdown dropdown;
	public Text successNotification;
	public GameObject nameField;
	public Button deleteButton;
	public List<CheckCollision> days;

	private string courses;
	private string availableCourses;
	private List<string> courseList;
	private List<string> availableCoursesList;

	private char delimeter;
	private string rectangleTag;
	private int courseOwnCount;

	public void DeleteCourse()
	{
		courseOwnCount = 0;
		delimeter = System.Convert.ToChar (17);
		courses = "";
		availableCourses = "";
		availableCoursesList = new List<string> ();
		courseList = new List<string> ();
		rectangleTag = nameField.tag;


		foreach (TMP_Dropdown.OptionData option in dropdown.options)
			courseList.Add (option.text);
		
		availableCourses = PlayerPrefs.GetString ("Available Courses");
		if (availableCourses != "")
			availableCoursesList = availableCourses.Split (delimeter).ToList<string> ();
		
		if (courseList.Count > 1) 
		{
			if (PlayerPrefs.HasKey (courseList [dropdown.value])) 
			{
				courseOwnCount = PlayerPrefs.GetInt (courseList [dropdown.value] + " Count");

				if (courseOwnCount <= 1) 
				{
					PlayerPrefs.DeleteKey (courseList [dropdown.value] + " Count");
					PlayerPrefs.DeleteKey (courseList [dropdown.value]);

					if (PlayerPrefs.HasKey (courseList [dropdown.value] + " Final")) 
					{
						PlayerPrefs.DeleteKey (courseList [dropdown.value] + " Final");
						int midtermCount = PlayerPrefs.GetInt (courseList [dropdown.value] + " Midterm Count");
						for (int m = 1; m <= midtermCount; m++)
							PlayerPrefs.DeleteKey (courseList [dropdown.value] + " Midterm " + m.ToString ());
						PlayerPrefs.DeleteKey (courseList [dropdown.value] + " Midterm Count");
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

					availableCoursesList.Remove (courseList [dropdown.value]);
					availableCourses = "";

					for (int i = 0; i < availableCoursesList.Count; ++i) 
					{
						if (i == 0)
							availableCourses += availableCoursesList [i];
						else
							availableCourses += delimeter + availableCoursesList [i];
					}

					PlayerPrefs.SetString ("Available Courses", availableCourses);
				} 
				else 
				{
					courseOwnCount--;
					PlayerPrefs.SetInt (courseList [dropdown.value] + " Count", courseOwnCount);
				}

				courses = "";
				courseList.RemoveAt (dropdown.value);
				for (int i = 0; i < courseList.Count; ++i)
				{
					if (i == 0)
						courses += courseList [i];
					else
						courses += delimeter + courseList [i];
				}
				PlayerPrefs.SetString (rectangleTag, courses);
				dropdown.ClearOptions ();
				dropdown.AddOptions (courseList);
			}
		}
		else 
		{
			List<string> temp = new List<string> ();
			temp.Add ("No course left");
			courses = "";
			PlayerPrefs.SetString (rectangleTag, courses);
			if (PlayerPrefs.HasKey (courseList [0])) 
			{
				courseOwnCount = PlayerPrefs.GetInt (courseList [0] + " Count");

				if (courseOwnCount <= 1) 
				{
					PlayerPrefs.DeleteKey (courseList [0] + " Count");
					PlayerPrefs.DeleteKey (courseList [0]);

					if (PlayerPrefs.HasKey (courseList [0] + " Final")) 
					{
						PlayerPrefs.DeleteKey (courseList [0] + " Final");
						int midtermCount = PlayerPrefs.GetInt (courseList [0] + " Midterm Count");
						for (int m = 1; m <= midtermCount; m++)
							PlayerPrefs.DeleteKey (courseList [0] + " Midterm " + m.ToString ());
						PlayerPrefs.DeleteKey (courseList [0] + " Midterm Count");
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

					availableCoursesList.Remove (courseList [0]);
					availableCourses = "";
					for (int i = 0; i < availableCoursesList.Count; ++i) 
					{
						if (i == 0)
							availableCourses += availableCoursesList [i];
						else
							availableCourses += delimeter + availableCoursesList [i];
					}

					PlayerPrefs.SetString ("Available Courses", availableCourses);
				} 
				else 
				{
					courseOwnCount--;
					PlayerPrefs.SetInt (courseList [0] + " Count", courseOwnCount);
				}
			}

			dropdown.ClearOptions ();
			dropdown.AddOptions (temp);
			dropdown.interactable = false;
			deleteButton.interactable = false;

		}

		successNotification.gameObject.SetActive (true);
		foreach (CheckCollision day in days)
			day.ClearColor();
		PlayerPrefs.Save ();
	}
}
