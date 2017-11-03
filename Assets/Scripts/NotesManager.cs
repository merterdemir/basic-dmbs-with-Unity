using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Access to UI items
using System.Linq; //For ToList<>()

public class NotesManager : MonoBehaviour {

	public GameObject content;
	public GameObject notesButtonPrefab;
	public InputField noteHeader;
	public InputField infoIF;
	public Text infoPanelNoteTitle;
	public GameObject addPanel;
	public Button addButton;
	public GameObject exportButton;

	private List<string> noteNames;
	private int noteCount;
	private int totalNoteCount;
	private string noteNamesPP;

	private bool changeHasMade;
	private char delimeter;
	private char secondDelimeter;
	private string emptyNoteName;

	public string noteID;
	public string chosenNote;
	public int chosenNoteIndex;


	// Use this for initialization
	void Awake ()
	{
		noteID = "";
		chosenNote = "";
		chosenNoteIndex = -1;
		changeHasMade = false;
		noteNames = new List<string> ();
		noteNamesPP = "";
		totalNoteCount = 0;
		noteCount = 0;
		delimeter = System.Convert.ToChar (17);
		secondDelimeter = System.Convert.ToChar (18);
		//Debug.Log (delimeter);

		/*for (int i = 1; i < 7; i++) {
			if (PlayerPrefs.HasKey ("Note " + i.ToString ()))
				PlayerPrefs.DeleteKey ("Note " + i.ToString ());
		}
		PlayerPrefs.SetString ("Note Headers", "");
		PlayerPrefs.SetInt ("Note Count", 0);*/
		if (!PlayerPrefs.HasKey ("Total Notes"))
			PlayerPrefs.SetInt ("Total Notes", totalNoteCount);
		else
			totalNoteCount = PlayerPrefs.GetInt ("Total Notes");
		
		RefreshNotes ();
	}

	void Update()
	{
		if (changeHasMade)
			RefreshNotes ();
		if (noteCount != 0) 
		{
			if (chosenNoteIndex != -1)
				exportButton.SetActive (true);
			else 
				exportButton.SetActive (false);

		}
		else
			exportButton.SetActive (false);
		
	}

	public void AddNote()
	{
		emptyNoteName = new System.String (' ', noteHeader.text.Length);
		if (noteHeader.text != "" && noteHeader.text != emptyNoteName) 
		{
			noteCount = PlayerPrefs.GetInt ("Note Count");
			noteNamesPP = PlayerPrefs.GetString ("Note Headers");
			totalNoteCount++;

			if (noteCount == 0)
				noteNamesPP += noteHeader.text + " " + System.DateTime.Now.ToString() + secondDelimeter.ToString() + totalNoteCount.ToString();
			else
				noteNamesPP += delimeter.ToString() + noteHeader.text + " " + System.DateTime.Now.ToString() + secondDelimeter.ToString() + totalNoteCount.ToString();
			noteCount++;

			PlayerPrefs.SetInt ("Note Count", noteCount);
			PlayerPrefs.SetString ("Note Headers", noteNamesPP);
			PlayerPrefs.SetInt ("Total Notes", totalNoteCount);

			foreach (GameObject entry in GameObject.FindGameObjectsWithTag("Entry Button"))
				Destroy (entry);

			changeHasMade = true;
			noteHeader.text = "";
			addButton.GetComponent<Image>().color = Color.white;
			addPanel.SetActive (false);
		}
		else
			addButton.GetComponent<Image>().color = Color.red;

	}

	public void DeleteNote()
	{
		noteCount = PlayerPrefs.GetInt ("Note Count");
		noteNamesPP = PlayerPrefs.GetString ("Note Headers");
		if (noteCount != 0 && chosenNoteIndex != -1) 
		{
			noteNames = new List<string> ();
			noteNames = noteNamesPP.Split (delimeter).ToList<string>();
			noteNamesPP = "";

			for (int i = 0; i < noteNames.Count; i++) {
				if (i != chosenNoteIndex) 
				{
					if (i == 0 || (chosenNoteIndex == 0 && i == 1))
						noteNamesPP += noteNames [i];
					else
						noteNamesPP += delimeter.ToString () + noteNames [i];
				}
				else 
				{
					if (noteID != "" && PlayerPrefs.HasKey("Note " + noteID))
						PlayerPrefs.DeleteKey ("Note " + noteID);
					infoIF.placeholder.GetComponent<Text>().text = "Enter text...";
					infoIF.text = "";
					infoPanelNoteTitle.text = " Note Name";
				}
			}
			noteCount--;

			PlayerPrefs.SetInt ("Note Count", noteCount);
			PlayerPrefs.SetString ("Note Headers", noteNamesPP);

			foreach (GameObject entry in GameObject.FindGameObjectsWithTag("Entry Button"))
				Destroy (entry);
			
			changeHasMade = true;
			chosenNoteIndex = -1;
			noteID = "";
		}
	}

	public void SaveNote()
	{
		noteCount = PlayerPrefs.GetInt ("Note Count");
		if (noteCount != 0 && chosenNoteIndex != -1) 
		{
			if (PlayerPrefs.HasKey ("Note " + noteID))
				PlayerPrefs.SetString ("Note " + noteID, infoIF.text);
		}
	}

	public void EditNote()
	{
		noteCount = PlayerPrefs.GetInt ("Note Count");
		if (noteCount != 0 && chosenNoteIndex != -1) 
		{
			infoIF.ActivateInputField ();
			infoIF.readOnly = false;
			infoIF.interactable = true;
		}
	}

	void RefreshNotes()
	{

		if (!PlayerPrefs.HasKey ("Note Count"))
			PlayerPrefs.SetInt ("Note Count", noteCount);
		else
			noteCount = PlayerPrefs.GetInt ("Note Count");


		if (!PlayerPrefs.HasKey ("Note Headers")) 
			PlayerPrefs.SetString ("Note Headers", noteNamesPP);
		else 
		{
			noteNamesPP = PlayerPrefs.GetString ("Note Headers");
			noteNames = noteNamesPP.Split (delimeter).ToList<string>();
		}

		if (noteCount == 0) 
		{
			chosenNoteIndex = -1;
			GameObject none = Instantiate (notesButtonPrefab, content.transform);
			none.transform.Find ("Text").GetComponent<Text> ().text = "\tNo entry";
			none.GetComponent<Button> ().interactable = false;
		} 
		else 
		{
			List<string> tempList = new List<string> ();

			for (int i = noteNames.Count - 1; i >= 0 ; --i) 
			{
				GameObject tempNote = Instantiate (notesButtonPrefab, content.transform);
				tempList = noteNames [i].Split (secondDelimeter).ToList<string> ();

				noteID = tempList [1];
				tempNote.gameObject.GetComponent<ButtonManager> ().noteID = noteID;
				tempNote.gameObject.GetComponent<ButtonManager> ().index = i;

				tempNote.transform.Find ("Text").GetComponent<Text> ().text = "\t" + tempList[0];

			}	
		}
		changeHasMade = false;
	}
}
