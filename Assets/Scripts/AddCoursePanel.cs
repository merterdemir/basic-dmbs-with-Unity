using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AddCoursePanel : MonoBehaviour {

	public TMP_Dropdown dropdown;
	public InputField inputField;
	public GameObject addPanel;
	public GameObject deletePanel;
	public GameObject deleteErrorPanel;
	public Text errorText1;
	public GameObject editPanel;
	public GameObject questPanel;
	public Text nameField;
	public GameObject cancelButton;

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
		tagName = transform.tag;
	}

	public void OpenEditPanel()
	{
		WriteDayxHour (tagName);
		addPanel.SetActive (false);
		deletePanel.SetActive (false);
		deleteErrorPanel.SetActive (false);
		cancelButton.SetActive (true);
		questPanel.SetActive (true);
		editPanel.SetActive (true);
		editPanel.GetComponent<RectTransform> ().SetAsLastSibling ();
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
			availableCoursesOnDH = PlayerPrefs.GetString (nameField.gameObject.tag);

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

	void WriteDayxHour(string tagName)
	{
		switch (tagName) 
		{
			case "A1":
				nameField.text = "Monday - 08:40";
				break;
			case "A2":
				nameField.text = "Monday - 09:40";
				break;
			case "A3":
				nameField.text = "Monday - 10:40";
				break;
			case "A4":
				nameField.text = "Monday - 11:40";
				break;
			case "A5":
				nameField.text = "Monday - 12:40";
				break;
			case "A6":
				nameField.text = "Monday - 13:40";
				break;
			case "A7":
				nameField.text = "Monday - 14:40";
				break;
			case "A8":
				nameField.text = "Monday - 15:40";
				break;
			case "A9":
				nameField.text = "Monday - 16:40";
				break;
			case "B1":
				nameField.text = "Tuesday - 08:40";
				break;
			case "B2":
				nameField.text = "Tuesday - 09:40";
				break;
			case "B3":
				nameField.text = "Tuesday - 10:40";
				break;
			case "B4":
				nameField.text = "Tuesday - 11:40";
				break;
			case "B5":
				nameField.text = "Tuesday - 12:40";
				break;
			case "B6":
				nameField.text = "Tuesday - 13:40";
				break;
			case "B7":
				nameField.text = "Tuesday - 14:40";
				break;
			case "B8":
				nameField.text = "Tuesday - 15:40";
				break;
			case "B9":
				nameField.text = "Tuesday - 16:40";
				break;
			case "C1":
				nameField.text = "Wednesday - 08:40";
				break;
			case "C2":
				nameField.text = "Wednesday - 09:40";
				break;
			case "C3":
				nameField.text = "Wednesday - 10:40";
				break;
			case "C4":
				nameField.text = "Wednesday - 11:40";
				break;
			case "C5":
				nameField.text = "Wednesday - 12:40";
				break;
			case "C6":
				nameField.text = "Wednesday - 13:40";
				break;
			case "C7":
				nameField.text = "Wednesday - 14:40";
				break;
			case "C8":
				nameField.text = "Wednesday - 15:40";
				break;
			case "C9":
				nameField.text = "Wednesday - 16:40";
				break;
			case "D1":
				nameField.text = "Thursday - 08:40";
				break;
			case "D2":
				nameField.text = "Thursday - 09:40";
				break;
			case "D3":
				nameField.text = "Thursday - 10:40";
				break;
			case "D4":
				nameField.text = "Thursday - 11:40";
				break;
			case "D5":
				nameField.text = "Thursday - 12:40";
				break;
			case "D6":
				nameField.text = "Thursday - 13:40";
				break;
			case "D7":
				nameField.text = "Thursday - 14:40";
				break;
			case "D8":
				nameField.text = "Thursday - 15:40";
				break;
			case "D9":
				nameField.text = "Thursday - 16:40";
				break;
			case "E1":
				nameField.text = "Friday - 08:40";
				break;
			case "E2":
				nameField.text = "Friday - 09:40";
				break;
			case "E3":
				nameField.text = "Friday - 10:40";
				break;
			case "E4":
				nameField.text = "Friday - 11:40";
				break;
			case "E5":
				nameField.text = "Friday - 12:40";
				break;
			case "E6":
				nameField.text = "Friday - 13:40";
				break;
			case "E7":
				nameField.text = "Friday - 14:40";
				break;
			case "E8":
				nameField.text = "Friday - 15:40";
				break;
			case "E9":
				nameField.text = "Friday - 16:40";
				break;
			default:
				nameField.text = "Error!!!";
				break;
		}
		nameField.gameObject.tag = tagName;
	}
}
