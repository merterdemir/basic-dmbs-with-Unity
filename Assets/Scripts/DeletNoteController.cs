using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DeletNoteController : MonoBehaviour {

	public GameObject error1Panel;
	public GameObject error2Panel;
	public GameObject checkPanel;
	public NotesManager notesManager;
	private int noteCount;

	void Start () {
		
		noteCount = 0;
	}

	public void CheckDelete()
	{

		if (PlayerPrefs.HasKey ("Note Count"))
			noteCount = PlayerPrefs.GetInt ("Note Count");

		if (noteCount != 0) 
		{
			if (notesManager.chosenNoteIndex != -1) 
			{
				checkPanel.SetActive (true);
				if (error1Panel.activeSelf)
					error1Panel.SetActive (false);
				if (error2Panel.activeSelf)
					error2Panel.SetActive (false);
				checkPanel.transform.SetAsLastSibling ();
			}
			else 
			{
				error2Panel.SetActive (true);
				if (checkPanel.activeSelf)
					checkPanel.SetActive (false);
				if (error1Panel.activeSelf)
					error1Panel.SetActive (false);
				error2Panel.transform.SetAsLastSibling ();
			}
		}
		else 
		{
			error1Panel.SetActive (true);
			if (checkPanel.activeSelf)
				checkPanel.SetActive (false);
			if (error2Panel.activeSelf)
				error2Panel.SetActive (false);
			error1Panel.transform.SetAsLastSibling ();
		}

	}
}
