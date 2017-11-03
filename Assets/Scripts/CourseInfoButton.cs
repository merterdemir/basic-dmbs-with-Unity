using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourseInfoButton : MonoBehaviour {

	public bool selected;
	// Use this for initialization
	void Start () {
		selected = false;
	}

	public void ClickOnButton()
	{
		selected = true;
	}
}
