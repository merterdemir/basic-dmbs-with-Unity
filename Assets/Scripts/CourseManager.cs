using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Access to UI items
using System.Linq; //For ToList<>()

public class CourseManager : MonoBehaviour {

	public GameObject content;
	public GameObject courseButtonPrefab;
	public Text dayLabel;
	public CheckCollision checkCollision;

	private char delimeter;
	private int courseCount;
	private string courses;
	private string checkCourses;
	private string rectangleTag;
	private List<string> courseList;
	private bool changeHasMade;

	private Button courseButton;
	public GameObject infoPanel;
	public Text courseCodeLabel;

	private string courseCode;

	// Use this for initialization
	void Start () {
		courseCount = 0;
		checkCourses = "";
		courses = "";
		courseList = new List<string> ();

		rectangleTag = transform.tag;
		delimeter = System.Convert.ToChar (17);
		changeHasMade = false;
		RefreshCourses ();
		//PlayerPrefs.DeleteAll ();
	}

	// Update is called once per frame
	void Update () {
		if (changeHasMade)
			RefreshCourses ();
		if (PlayerPrefs.GetString(rectangleTag) != checkCourses)
			DestroyAll ();
		if (isClicked ())
			OpenInfoPanel ();
	}

	public void OpenInfoPanel()
	{
		
		courseCode = "";
		courseButton.gameObject.GetComponent<CourseInfoButton> ().selected = false;
		courseCode = courseButton.transform.Find("Text").gameObject.
					GetComponent<Text> ().text;
		courseCodeLabel.text = courseCode;
		infoPanel.SetActive (true);
		infoPanel.transform.SetAsLastSibling ();
	}

	private bool isClicked()
	{
		foreach (Transform child in transform) 
		{
			if (child.GetComponent<CourseInfoButton> ().selected) 
			{
				courseButton = child.GetComponent<Button> ();
				return true;
			}
		}	
		return false;
	}

	public void RefreshCourses()
	{
		courses = "";
		if (!PlayerPrefs.HasKey (rectangleTag))
			PlayerPrefs.SetString (rectangleTag, courses);
		else
			courses = PlayerPrefs.GetString (rectangleTag);

		checkCourses = courses;

		courseList = courses.Split (delimeter).ToList<string> ();

		if (courseList.Count == 1 && courseList [0] == "")
			courseCount = 0;
		else
			courseCount = courseList.Count;

		if (courseCount > 0) 
		{
			for (int i = 0; i < courseList.Count; ++i) 
			{
				if (courseList [i] != "")
				{
					GameObject tempCourse = Instantiate (courseButtonPrefab, content.transform);
					tempCourse.transform.Find ("Text").GetComponent<Text> ().text = courseList [i];
				}
			}
		}
		changeHasMade = false;
		checkCollision.changeHasMade = true;
	}

	void DestroyAll()
	{
		foreach (Transform child in transform)
			Destroy (child.gameObject);
		changeHasMade = true;
	}
}
