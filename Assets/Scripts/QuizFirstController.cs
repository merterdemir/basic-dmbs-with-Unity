using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class QuizFirstController : MonoBehaviour {

	public InputField quizPercentage;
	public TMP_Dropdown quizCount; 
	public Button nextButton;
	public Text errorText;
	public Text courseName;
	public GameObject quizGridPanel;
	public GameObject firstPanel;
	public GameObject normalPanel;

	private string courseInfoCategories;
	private List<string> courseInfoCategoriesList;
	private char delimeter;
	private char secondDelimeter;


	// Use this for initialization
	void Awake () {

		quizCount.value = 0;
		quizPercentage.interactable = false;
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
			if (quizCount.value != 0)
				quizPercentage.interactable = true;
			else
				quizPercentage.interactable = false;

			if (quizCount.value != 0) {
				if (quizPercentage.text != "")
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
		float quizPer;
		if (quizCount.value != 0) {
			quizPer = float.Parse (quizPercentage.text);

			if (quizPer > 100f) 
			{
				errorText.gameObject.SetActive (true);
				return;
			} 
			else 
			{
				string temp = "";
				temp = "Quiz" + secondDelimeter + quizPer.ToString();
				courseInfoCategoriesList.Add (temp);

				courseInfoCategories = "";

				for (int i = 0; i < courseInfoCategoriesList.Count; ++i) 
				{
					if (courseInfoCategories != "")
						courseInfoCategories += delimeter + courseInfoCategoriesList [i];
					else
						courseInfoCategories = courseInfoCategoriesList [i];
				}
				//Debug.Log (quizCount.value);
				PlayerPrefs.SetInt (courseName.text + " Quiz Count", quizCount.value);

				for (int i = 1; i <= quizCount.value; ++i)
					PlayerPrefs.SetInt (courseName.text + " Quiz " + i.ToString (), 0);

				PlayerPrefs.SetString (courseName.text, courseInfoCategories);
				PlayerPrefs.Save ();
				quizCount.value = 0;
				quizPercentage.text = "";
			}
		}
		else 
		{
			PlayerPrefs.SetInt (courseName.text + " Quiz Count", quizCount.value);
			PlayerPrefs.Save ();
			quizCount.value = 0;
			quizPercentage.text = "";
		}
		quizGridPanel.GetComponent<QuizesManager> ().goingToOpen = true;
		firstPanel.SetActive (false);
		normalPanel.SetActive (true);
	}
}
