using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LabsFirstController : MonoBehaviour {

	public InputField labPercentage;
	public TMP_Dropdown labCount; 
	public Button nextButton;
	public Text errorText;
	public Text courseName;
	public GameObject labGridPanel;
	public GameObject firstPanel;
	public GameObject normalPanel;

	private string courseInfoCategories;
	private List<string> courseInfoCategoriesList;
	private char delimeter;
	private char secondDelimeter;


	// Use this for initialization
	void Awake () {

		labCount.value = 0;
		labPercentage.interactable = false;
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
			if (labCount.value != 0)
				labPercentage.interactable = true;
			else
				labPercentage.interactable = false;

			if (labCount.value != 0) {
				if (labPercentage.text != "")
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
		float labPer;
		if (labCount.value != 0) {
			labPer = float.Parse (labPercentage.text);

			if (labPer > 100f) 
			{
				errorText.gameObject.SetActive (true);
				return;
			} 
			else 
			{
				string temp = "";
				temp = "Lab" + secondDelimeter + labPer.ToString();
				courseInfoCategoriesList.Add (temp);

				courseInfoCategories = "";

				for (int i = 0; i < courseInfoCategoriesList.Count; ++i) 
				{
					if (courseInfoCategories != "")
						courseInfoCategories += delimeter + courseInfoCategoriesList [i];
					else
						courseInfoCategories = courseInfoCategoriesList [i];
				}
				//Debug.Log (labCount.value);
				PlayerPrefs.SetInt (courseName.text + " Lab Count", labCount.value);

				for (int i = 1; i <= labCount.value; ++i)
					PlayerPrefs.SetInt (courseName.text + " Lab " + i.ToString (), 0);

				PlayerPrefs.SetString (courseName.text, courseInfoCategories);
				PlayerPrefs.Save ();
				labCount.value = 0;
				labPercentage.text = "";
			}
		}
		else 
		{
			PlayerPrefs.SetInt (courseName.text + " Lab Count", labCount.value);
			PlayerPrefs.Save ();
			labCount.value = 0;
			labPercentage.text = "";
		}
		labGridPanel.GetComponent<LabsManager> ().goingToOpen = true;
		firstPanel.SetActive (false);
		normalPanel.SetActive (true);	
	}
}
