using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AddPanelController : MonoBehaviour {

	public TMP_Dropdown dropdown;
	public InputField inputField;
	public GameObject nameField;

	private string availableCourses;
	private List<string> availableCoursesList;
	private string availableCoursesOnDH;

	private char delimeter;
	private string tagName;

	// Use this for initialization
	void Start () {
		
		delimeter = System.Convert.ToChar (17);
		availableCourses = "";
		availableCoursesList = new List<string> ();
		tagName = nameField.tag;
		RefreshDropdown ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (dropdown.value != 0) 
		{
			inputField.DeactivateInputField ();
			inputField.interactable = false;
			inputField.readOnly = true;
		}
		else 
		{
			inputField.ActivateInputField ();
			inputField.interactable = true;
			inputField.readOnly = false;
		}
	}
	public void ClearDropDown()
	{
		dropdown.ClearOptions();
		List<string> temp = new List<string> ();
		temp.Add ("Other");
		dropdown.AddOptions (temp);
		dropdown.value = 0;
	}

	void RefreshDropdown()
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
