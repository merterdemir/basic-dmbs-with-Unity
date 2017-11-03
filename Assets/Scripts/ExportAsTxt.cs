using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ExportAsTxt : MonoBehaviour {

	public GameObject exportButton;
	public NotesManager notesManager;
	public Text title;
	private string noteName;
	private string path;
	private string note;
	public string noteID;
	private string date;
	private string hour;

	void Start () {
		path = "";
		noteName = "";
		exportButton.SetActive (true);
	}

	public void Main() 
	{
		path = Path.GetFullPath(".");
		date = "";
		hour = "";
		Debug.Log (path);
		if (title.text.Substring (1) != "Note Name") {
			noteName = title.text.Substring (1).Split(' ')[0];
			foreach (string entry in title.text.Substring (1).Split(' ')[1].Split('/'))
				date += "_" + entry;
			foreach (string entry in title.text.Substring (1).Split(' ')[2].Split(':'))
				hour += "-" + entry;
			note = PlayerPrefs.GetString ("Note " + noteID);
			if (!Directory.Exists (path + "/Notes"))
				Directory.CreateDirectory (path + "/Notes");
			path += "/Notes/" + noteName + date + hour + ".txt";
			if (!File.Exists (path)) {
				// Create a file to write to.
				using (StreamWriter sw = File.CreateText (path)) {
					sw.WriteLine (note);
				}	
			}
			else 
			{
				File.Delete (path);
				using (StreamWriter sw = File.CreateText (path)) {
					sw.WriteLine (note);
				}
			}
		}
	}
}
