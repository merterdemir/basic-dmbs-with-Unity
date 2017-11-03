using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LabsManager : MonoBehaviour {

	public Text courseName;
	public GameObject content;
	public GameObject buttonPrefab;

	private int labCount;
	public bool goingToOpen;

	void Awake()
	{
		labCount = 0;
		goingToOpen = false;
		Redesign ();
	}

	void Update()
	{
		if (goingToOpen)
			Redesign ();
	}

	void Redesign()
	{
		if (!PlayerPrefs.HasKey (courseName.text + " Lab Count"))
			PlayerPrefs.SetInt (courseName.text + " Lab Count", labCount);
		else
			labCount = PlayerPrefs.GetInt (courseName.text + " Lab Count");

		foreach (Transform child in content.transform) 
			Destroy (child.gameObject);

		if (labCount == 0) 
		{
			GameObject temp = Instantiate (buttonPrefab, content.transform);
			temp.transform.Find ("Text").GetComponent<Text> ().text = " No labs";
			temp.GetComponent<Button> ().interactable = false;
		}
		else 
		{
			for (int i = 1; i <= labCount; ++i) {
				GameObject temp = Instantiate (buttonPrefab, content.transform);
				temp.transform.Find ("Text").GetComponent<Text> ().text = " Lab " + i.ToString ();
			}
		}
		goingToOpen = false;

	}

}
