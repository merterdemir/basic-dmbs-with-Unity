using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class HomeworkFirstController : MonoBehaviour {

	public InputField homeworkPercentage;
	public TMP_Dropdown homeworkCount; 
	public Button nextButton;
	public Text errorText;
	public Text courseName;
	public GameObject homeworkGridPanel;
	public GameObject firstPanel;
	public GameObject normalPanel;

	private string courseInfoCategories;
	private List<string> courseInfoCategoriesList;
	private char delimeter;
	private char secondDelimeter;


	// Use this for initialization
	void Awake () {

		homeworkCount.value = 0;
		homeworkPercentage.interactable = false;
		nextButton.interactable = false;
		errorText.gameObject.SetActive (false);
		courseInfoCategories = "";
		courseInfoCategoriesList = new List<string> ();
		delimeter = System.Convert.ToChar (17);
		secondDelimeter = System.Convert.ToChar (18);

		if (!PlayerPrefs.HasKey (courseName.text))
			PlayerPrefs.SetString (courseName.text, courseInfoCategories);
		else
			courseInfoCategories = PlayerPrefs.GetString (courseName.text);

		if (courseInfoCategories != "") {
			courseInfoCategoriesList = courseInfoCategories.Split (delimeter).ToList<string> ();
		}
	}

	// Update is called once per frame
	void Update () {

		if (transform.gameObject.activeSelf) {
			if (homeworkCount.value != 0)
				homeworkPercentage.interactable = true;
			else
				homeworkPercentage.interactable = false;

			if (homeworkCount.value != 0) {
				if (homeworkPercentage.text != "")
					nextButton.interactable = true;
				else
					nextButton.interactable = false;
			} else
				nextButton.interactable = true;
		}
	}

	public void ClickedNext()
	{
		errorText.gameObject.SetActive (false);
		float homeworkPer;
		if (homeworkCount.value != 0) {
			homeworkPer = float.Parse (homeworkPercentage.text);

			if (homeworkPer > 100f) 
			{
				errorText.gameObject.SetActive (true);
				return;
			} 
			else 
			{
				string temp = "";
				temp = "Homework" + secondDelimeter + homeworkPer.ToString();
				courseInfoCategoriesList.Add (temp);

				courseInfoCategories = "";

				for (int i = 0; i < courseInfoCategoriesList.Count; ++i) 
				{
					if (courseInfoCategories != "")
						courseInfoCategories += delimeter + courseInfoCategoriesList [i];
					else
						courseInfoCategories = courseInfoCategoriesList [i];
				}
				//Debug.Log (homeworkCount.value);
				PlayerPrefs.SetInt (courseName.text + " Homework Count", homeworkCount.value);

				for (int i = 1; i <= homeworkCount.value; ++i)
					PlayerPrefs.SetInt (courseName.text + " Homework " + i.ToString (), 0);

				PlayerPrefs.SetString (courseName.text, courseInfoCategories);
				PlayerPrefs.Save ();
				homeworkCount.value = 0;
				homeworkPercentage.text = "";
			}
		}
		else 
		{
			PlayerPrefs.SetInt (courseName.text + " Homework Count", homeworkCount.value);
			PlayerPrefs.Save ();
			homeworkCount.value = 0;
			homeworkPercentage.text = "";
		}
		homeworkGridPanel.GetComponent<HomeworksManager> ().goingToOpen = true;
		firstPanel.SetActive (false);
		normalPanel.SetActive (true);	
	}
}
