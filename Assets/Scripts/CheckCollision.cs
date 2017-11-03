using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CheckCollision : MonoBehaviour {

	private char delimeter;
	private int courseCount;
	private string courses;
	private string dayTag;
	private List<string> courseList;
	private Color standartLabelColor;

	public bool changeHasMade;
	private bool collisionExists;
	public bool clearSignal;

	// Use this for initialization
	void Start () {
		courseCount = 0;
		courses = "";
		courseList = new List<string> ();
		dayTag = transform.tag;
		standartLabelColor = new Color((float)50/255, (float)50/255, (float)50/255, 1);
		delimeter = System.Convert.ToChar (17);
		changeHasMade = false;
		collisionExists = false;
		clearSignal = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (changeHasMade)
			CollisionCheck ();
	}

	void CollisionCheck()
	{

		for (int i = 1; i < 10; ++i) 
		{
			courses = "";

			if (!PlayerPrefs.HasKey (dayTag + i.ToString ()))
				PlayerPrefs.SetString (dayTag + i.ToString (), courses);
			else
				courses = PlayerPrefs.GetString (dayTag + i.ToString ());
			
			courseList = courses.Split (delimeter).ToList<string> ();

			if (courseList.Count == 1 && courseList [0] == "")
				courseCount = 0;
			else
				courseCount = courseList.Count;

			if (courseCount > 1) 
			{
				collisionExists = true;
				break;
			}

		}

		if (collisionExists)
			transform.GetComponent<Text> ().color = Color.red;
		else
			transform.GetComponent<Text> ().color = standartLabelColor;
		
		changeHasMade = false;
	}
	public void ClearColor()
	{
		collisionExists = false;
		transform.GetComponent<Text> ().color = standartLabelColor;
		changeHasMade = true;
	}
}
