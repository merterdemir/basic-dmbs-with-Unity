using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PointsCalculator : MonoBehaviour {

	public Text courseLabel;
	public Text pointsLabel;
	public bool changeHasMade;

	private string courseName, categories;
	private float midtermPerc, finalPerc, quizPerc, labsPerc, homeworkPerc, grade;
	private int midtermCount, quizCount, labsCount, homeworkCount;
	private List<string> categoriesList;
	private char delimeter, secondDelimeter;

	// Use this for initialization
	void Start () {
		changeHasMade = false;
		PointsCalculate ();
	}
	
	// Update is called once per frame
	void Update () {
		if (changeHasMade)
			PointsCalculate ();
	}

	void PointsCalculate()
	{
		categories = "";
		categoriesList = new List<string> ();
		delimeter = System.Convert.ToChar (17);
		secondDelimeter = System.Convert.ToChar (18);
		courseName = courseLabel.text;
		midtermPerc = 0f; finalPerc = 0f; quizPerc = 0f; labsPerc = 0f; homeworkPerc = 0f;
		grade = 0f; midtermCount = 0; quizCount = 0; labsCount = 0; homeworkCount = 0;

		categories = PlayerPrefs.GetString (courseName);

		categoriesList = categories.Split (delimeter).ToList<string> ();
		List<string> temp = new List<string> ();
		int tempGrade = 0;

		foreach (string category in categoriesList) 
		{
			tempGrade = 0;
			temp = category.Split (secondDelimeter).ToList<string> ();
			if (temp [0] == "Final") 
			{
				if (PlayerPrefs.HasKey (courseName + " Final")) 
				{
					finalPerc = float.Parse(temp[1]);
					tempGrade = PlayerPrefs.GetInt (courseName + " Final");
					grade += (float)tempGrade * (finalPerc * 0.01f);
				}
			}
			else if (temp [0] == "Midterm") 
			{
				if (PlayerPrefs.HasKey (courseName + " Midterm Count")) 
				{
					midtermCount = PlayerPrefs.GetInt (courseName + " Midterm Count");
					midtermPerc = float.Parse(temp[1]);
					for (int i = 1; i <= midtermCount; ++i)
						tempGrade += PlayerPrefs.GetInt(courseName + " Midterm " + i.ToString());
					grade += (float)tempGrade * (midtermPerc * 0.01f) / (float) midtermCount;
				}
			}
			else if (temp [0] == "Lab") 
			{
				if (PlayerPrefs.HasKey (courseName + " Lab Count")) 
				{
					labsCount = PlayerPrefs.GetInt (courseName + " Lab Count");
					labsPerc = float.Parse(temp[1]);
					for (int i = 1; i <= labsCount; ++i)
						tempGrade += PlayerPrefs.GetInt(courseName + " Lab " + i.ToString());
					grade += (float)tempGrade * (labsPerc * 0.01f) / (float) labsCount;;
				}
			}
			else if (temp [0] == "Homework") 
			{
				if (PlayerPrefs.HasKey (courseName + " Homework Count")) 
				{
					homeworkCount = PlayerPrefs.GetInt (courseName + " Homework Count");
					homeworkPerc = float.Parse(temp[1]);
					for (int i = 1; i <= homeworkCount; ++i)
						tempGrade += PlayerPrefs.GetInt(courseName + " Homework " + i.ToString());
					grade += (float)tempGrade * (homeworkPerc * 0.01f) / (float) homeworkCount;;
				}
			}
			else if (temp [0] == "Quiz") 
			{
				if (PlayerPrefs.HasKey (courseName + " Quiz Count")) 
				{
					quizCount = PlayerPrefs.GetInt (courseName + " Quiz Count");
					quizPerc = float.Parse(temp[1]);
					for (int i = 1; i <= quizCount; ++i)
						tempGrade += PlayerPrefs.GetInt(courseName + " Quiz " + i.ToString());
					grade += (float)tempGrade * (quizPerc * 0.01f) / (float) quizCount;;
				}
			}
		}

		pointsLabel.text = grade.ToString("F2") + " points collected for this course.";

		changeHasMade = false;
	}
}
