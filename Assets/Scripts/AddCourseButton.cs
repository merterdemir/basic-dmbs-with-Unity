using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AddCourseButton : MonoBehaviour {

	public TMP_Dropdown dropdown;
	public InputField inputField;
	public Text errorText1;
	public Text errorText2;
	public Text successNotification;
	public GameObject editPanel;
	public GameObject questPanel;
	public GameObject addPanel;
	public GameObject nameField;

	private string availableCourses;
	private string availableCoursesOnDH;
	private List<string> availableCoursesList;

	private char delimeter;
	private string tagName;
	private string emptyCourseName;
	// Use this for initialization
	void Awake () {

		availableCoursesOnDH = "";
		delimeter = System.Convert.ToChar (17);
		availableCourses = "";
		availableCoursesList = new List<string> ();
		tagName = nameField.tag;
	}
	
	// Update is called once per frame
	void Update () {

		if (tagName != nameField.tag)
			tagName = nameField.tag;
		
	}

	public void AddCourse()
	{
		if (dropdown.value == 0) 
		{
			emptyCourseName = new System.String (' ', inputField.text.Length);
			if (inputField.text != "" &&  inputField.text != emptyCourseName && inputField.text != "Other")
			{
				errorText2.gameObject.SetActive (false);
				errorText1.gameObject.SetActive (false);
				successNotification.gameObject.SetActive (false);

				availableCoursesList.Clear ();
				foreach (TMP_Dropdown.OptionData option in dropdown.options)
					availableCoursesList.Add (option.text);

				foreach (string courseName in availableCoursesList) 
				{
					if (courseName == inputField.text || PlayerPrefs.HasKey (inputField.text)) 
					{
						Debug.Log (courseName);
						Debug.Log(courseName == inputField.text);
						Debug.Log(PlayerPrefs.HasKey (inputField.text));
						if (errorText2.gameObject.activeSelf)
							errorText2.gameObject.SetActive (false);
						if (successNotification.gameObject.activeSelf)
							successNotification.gameObject.SetActive (false);
						errorText1.gameObject.SetActive (true);
						break;
					}
				}

				if (!errorText1.gameObject.activeSelf) {
					availableCourses = PlayerPrefs.GetString ("Available Courses");

					if (availableCourses != "")
						availableCourses += delimeter + inputField.text;
					else
						availableCourses += inputField.text;
				
					PlayerPrefs.SetString ("Available Courses", availableCourses);

					string tempString = PlayerPrefs.GetString (tagName);

					if (tempString != "")
						tempString += delimeter + inputField.text;
					else
						tempString += inputField.text;
				
					PlayerPrefs.SetString (tagName, tempString);
					PlayerPrefs.SetString (inputField.text, "");
					PlayerPrefs.SetInt (inputField.text + " Count", 1);

					inputField.text = "";
					if (errorText1.gameObject.activeSelf)
						errorText1.gameObject.SetActive (false);
					if (errorText2.gameObject.activeSelf)
						errorText2.gameObject.SetActive (false);
					
					successNotification.gameObject.SetActive (true);
				} else
					return;
			} 
			else 
			{
				if (errorText1.gameObject.activeSelf)
					errorText1.gameObject.SetActive (false);
				if (successNotification.gameObject.activeSelf)
					successNotification.gameObject.SetActive (false);
				errorText2.gameObject.SetActive (true);
			}
		}
		else 
		{
			string tempString = PlayerPrefs.GetString (tagName);

			if (tempString != "")
				tempString += delimeter + dropdown.options[dropdown.value].text;
			else
				tempString += dropdown.options[dropdown.value].text;

			PlayerPrefs.SetString (tagName, tempString);

			if (!PlayerPrefs.HasKey (dropdown.options [dropdown.value].text)) 
			{
				PlayerPrefs.SetString (dropdown.options [dropdown.value].text, "");
				PlayerPrefs.SetInt (dropdown.options [dropdown.value].text + " Count", 1);
			}
			else 
			{
				int temp = PlayerPrefs.GetInt (dropdown.options [dropdown.value].text + " Count");
				temp++;
				PlayerPrefs.SetInt (dropdown.options [dropdown.value].text + " Count", temp);
			}
				
			if (errorText1.gameObject.activeSelf)
				errorText1.gameObject.SetActive (false);
			if (errorText2.gameObject.activeSelf)
				errorText2.gameObject.SetActive (false);
			
			successNotification.gameObject.SetActive (true);
		}
		PlayerPrefs.Save ();
		RefreshDropdown ();

	}

	public void ClearDropDown()
	{
		dropdown.ClearOptions();
		List<string> temp = new List<string> ();
		temp.Add ("Other");
		dropdown.AddOptions (temp);
		dropdown.value = 0;
	}

	public void RefreshDropdown()
	{
		ClearDropDown ();

		List<string> tempList2 = new List<string> ();
		List<string> tempList = new List<string> ();
		bool isSame = false;

		if (!PlayerPrefs.HasKey ("Available Courses"))
			PlayerPrefs.SetString ("Available Courses", availableCourses);
		else
			availableCourses = PlayerPrefs.GetString ("Available Courses");

		if (availableCourses != "") 
		{
			availableCoursesList = availableCourses.Split (delimeter).ToList<string> ();
			availableCoursesOnDH = PlayerPrefs.GetString (tagName);

			if (availableCoursesOnDH != "") 
			{
				tempList = availableCoursesOnDH.Split (delimeter).ToList<string> ();
				for (int i = 0; i < availableCoursesList.Count; ++i)
				{
					for (int j = 0; j < tempList.Count; ++j) 
					{
						if (availableCoursesList [i] == tempList [j])
							isSame = true;
					}

					if (!isSame)
						tempList2.Add (availableCoursesList [i]);
					else
						isSame = false;
				}
				dropdown.AddOptions (tempList2);
			}
			else
				dropdown.AddOptions (availableCoursesList);
		}
	}
}
