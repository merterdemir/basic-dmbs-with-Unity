using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DeleteController : MonoBehaviour {

	public GameObject questPanel;
	public GameObject errorPanel;
	public GameObject deletePanel;
	public Text successNotation;
	public Button backButton;
	public Button deleteButton;
	public Button cancelButton;
	public TMP_Dropdown dropdown;
	public GameObject nameField;

	private string courses;
	private List<string> courseList;
	private string rectangleTag;
	private char delimeter = System.Convert.ToChar (17);

	public void OpenDeletePanel()
	{
		courses = "";
		courseList = new List<string> ();
		rectangleTag = nameField.tag;

		if (PlayerPrefs.HasKey (rectangleTag)) 
		{
			courses = PlayerPrefs.GetString (rectangleTag);

			if (courses != "") {
				courseList = courses.Split (delimeter).ToList<string> ();
				dropdown.ClearOptions ();
				dropdown.AddOptions (courseList);
				dropdown.interactable = true;
				deleteButton.interactable = true;
				successNotation.gameObject.SetActive (false);
				questPanel.SetActive (false);
				deletePanel.SetActive (true);
				errorPanel.SetActive (false);
				cancelButton.gameObject.SetActive (false);
				backButton.gameObject.SetActive (true);
				deleteButton.gameObject.SetActive (true);
			}
			else 
			{
				questPanel.SetActive (false);
				deletePanel.SetActive (false);
				errorPanel.SetActive (true);
				cancelButton.gameObject.SetActive (false);
				backButton.gameObject.SetActive (true);
				deleteButton.gameObject.SetActive (false);
			}
		}
	}
}
