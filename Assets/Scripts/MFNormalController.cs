using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MFNormalController : MonoBehaviour {

	public Button editButton;
	public Button saveButton;
	public InputField gradeInputField;
	public Text courseName;
	public PointsCalculator pointsCalculator;

	private int grade;
	private string buttonName;
	// Use this for initialization
	void Awake () 
	{
		buttonName = "";
		grade = 0;
		gradeInputField.interactable = false;
		saveButton.interactable = false;
	}

	public void ChangeGradeField(GameObject clickedButton)
	{
		buttonName = clickedButton.transform.Find("Text").GetComponent<Text> ().text;
		grade = PlayerPrefs.GetInt (courseName.text + buttonName);
		gradeInputField.placeholder.GetComponent<Text> ().text = grade.ToString ();
		gradeInputField.text = gradeInputField.placeholder.GetComponent<Text> ().text;
		//Debug.Log (buttonName);
	}

	public void EditGrade()
	{
		if (gradeInputField.placeholder.GetComponent<Text> ().text != "X") 
		{
			gradeInputField.interactable = true;
			saveButton.interactable = true;
		}
	}

	public void SaveGrade ()
	{
		if (gradeInputField.text != "" && (int.Parse (gradeInputField.text) <= 100)) 
		{
			grade = int.Parse (gradeInputField.text);
			PlayerPrefs.SetInt (courseName.text + buttonName, grade);
			gradeInputField.interactable = false;
			saveButton.interactable = false;
			pointsCalculator.changeHasMade = true;
		}
	}
}
