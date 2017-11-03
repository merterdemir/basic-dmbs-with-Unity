using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public Text buttonText;
	private ExportAsTxt exportAsTxt;

	/* Used in Notes Section */
	private NotesManager notesManager;
	public int index;
	public string noteID;
	public string note;
	/* --------------------- */

	/* Used in Course Section */

	/* --------------------- */

	void Awake () {
		
		note = "";
		notesManager = gameObject.GetComponentInParent<NotesManager>();
		exportAsTxt = transform.parent.transform.parent.transform.parent.transform.parent.transform.
			Find ("InfoPanelForHeaders").transform.Find ("ExportButton").GetComponent<ExportAsTxt> ();
		
	}

	public void NoteSelected()
	{
		notesManager.chosenNoteIndex = index;
		notesManager.chosenNote = buttonText.text;
		notesManager.noteID = noteID;
		exportAsTxt.noteID = noteID;

		if (!PlayerPrefs.HasKey ("Note " + noteID))
			PlayerPrefs.SetString ("Note " + noteID, note);
		else
			note = PlayerPrefs.GetString ("Note " + noteID);

		if (note != "") {
			notesManager.infoIF.placeholder.GetComponent<Text>().text = note;
			notesManager.infoIF.text = note;
			notesManager.infoPanelNoteTitle.text = " " + buttonText.text.Substring(1);
		} 
		else 
		{
			notesManager.infoIF.placeholder.GetComponent<Text>().text = "Enter text...";
			notesManager.infoIF.text = note;
			notesManager.infoPanelNoteTitle.text = " " + buttonText.text.Substring(1);
		}
	}
}
