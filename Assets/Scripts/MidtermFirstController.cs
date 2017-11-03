using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MidtermFirstController : MonoBehaviour {

	public InputField midtermPercentage;
	public InputField finalPercentage;
	public TMP_Dropdown midtermCount; 
	public Button nextButton;
	public Text errorText;
	public Text courseName;
	public GameObject mfGridPanel;
	public GameObject normalPanel;
	public GameObject firstPanel;

	private string courseInfoCategories;
	private List<string> courseInfoCategoriesList;
	private char delimeter;
	private char secondDelimeter;


	// Use this for initialization
	void Awake () {

		midtermCount.value = 0;
		midtermPercentage.interactable = false;
		finalPercentage.interactable = true;
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
			if (midtermCount.value != 0)
				midtermPercentage.interactable = true;
			else
				midtermPercentage.interactable = false;

			if (finalPercentage.text != "") {
				if (midtermCount.value != 0) {
					if (midtermPercentage.text != "")
						nextButton.interactable = true;
					else
						nextButton.interactable = false;
				} else
					nextButton.interactable = true;
			} else
				nextButton.interactable = false;
		}
	}

	public void ClickedNext()
	{
		errorText.gameObject.SetActive (false);
		float finalPer, midtermPer;
		finalPer = float.Parse (finalPercentage.text);
		if (midtermCount.value != 0) {
			midtermPer = float.Parse (midtermPercentage.text);

			if (finalPer > 100f || midtermPer > 100f) 
			{
				errorText.gameObject.SetActive (true);
				return;
			} 
			else 
			{
				string temp = "";
				temp = "Midterm" + secondDelimeter + midtermPer.ToString();
				courseInfoCategoriesList.Add (temp);

				temp = "Final" + secondDelimeter + finalPer.ToString ();
				courseInfoCategoriesList.Add (temp);

				courseInfoCategories = "";

				for (int i = 0; i < courseInfoCategoriesList.Count; ++i) 
				{
					if (courseInfoCategories != "")
						courseInfoCategories += delimeter + courseInfoCategoriesList [i];
					else
						courseInfoCategories = courseInfoCategoriesList [i];
				}
				//Debug.Log (midtermCount.value);
				PlayerPrefs.SetInt (courseName.text + " Midterm Count", midtermCount.value);

				for (int i = 1; i <= midtermCount.value; ++i)
					PlayerPrefs.SetInt (courseName.text + " Midterm " + i.ToString (), 0);
				
				PlayerPrefs.SetInt(courseName.text + " Final", 0);
				PlayerPrefs.SetString (courseName.text, courseInfoCategories);
				PlayerPrefs.Save ();
				midtermCount.value = 0;
				midtermPercentage.text = "";
				finalPercentage.text = "";
			}
		}
		else 
		{
			if (finalPer > 100f) 
			{
				errorText.gameObject.SetActive (true);
				return;
			} 
			else 
			{
				string temp = "";

				temp = "Final" + secondDelimeter + finalPer.ToString ();
				courseInfoCategoriesList.Add (temp);

				courseInfoCategories = "";

				for (int i = 0; i < courseInfoCategoriesList.Count; ++i) 
				{
					if (courseInfoCategories != "")
						courseInfoCategories += delimeter + courseInfoCategoriesList [i];
					else
						courseInfoCategories = courseInfoCategoriesList [i];
				}

				PlayerPrefs.SetInt (courseName.text + " Midterm Count", midtermCount.value);

				PlayerPrefs.SetInt(courseName.text + " Final", 0);
				PlayerPrefs.SetString (courseName.text, courseInfoCategories);
				PlayerPrefs.Save ();
				midtermCount.value = 0;
				midtermPercentage.text = "";
				finalPercentage.text = "";
			}
		}
		mfGridPanel.GetComponent<ExamsManager> ().goingToOpen = true;
		firstPanel.SetActive (false);
		normalPanel.SetActive (true);
	}
}
