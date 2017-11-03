using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WTSPanelController : MonoBehaviour {

	public Text courseName;
	public GameObject infoPanel;
	public GameObject wtsPanel;

	public GameObject mfGridPanel;
	public GameObject mfPanel;
	public GameObject mfFirstTimePanel;
	public GameObject mfNormalPanel;

	public GameObject quizGridPanel;
	public GameObject quizPanel;
	public GameObject quizFirstTimePanel;
	public GameObject quizNormalPanel;

	public GameObject labGridPanel;
	public GameObject labPanel;
	public GameObject labFirstTimePanel;
	public GameObject labNormalPanel;

	public GameObject homeworkGridPanel;
	public GameObject homeworkPanel;
	public GameObject homeworkFirstTimePanel;
	public GameObject homeworkNormalPanel;

	public void OpenExamsPanel()
	{
		wtsPanel.SetActive (false);
		infoPanel.SetActive (true);
		mfPanel.SetActive (true);

		if (PlayerPrefs.HasKey (courseName.text + " Final") ||
		    PlayerPrefs.HasKey (courseName.text + " Midterm Count"))
		{
			mfNormalPanel.SetActive (true);
			mfFirstTimePanel.SetActive (false);
			mfGridPanel.GetComponent<ExamsManager> ().goingToOpen = true;
		}
		else 
		{
			mfNormalPanel.SetActive (false);
			mfFirstTimePanel.SetActive (true);
		}
	}
	public void OpenQuizesPanel()
	{
		wtsPanel.SetActive (false);
		infoPanel.SetActive (true);
		quizPanel.SetActive (true);

		if (PlayerPrefs.HasKey (courseName.text + " Quiz Count"))
		{
			quizNormalPanel.SetActive (true);
			quizFirstTimePanel.SetActive (false);
			quizGridPanel.GetComponent<QuizesManager> ().goingToOpen = true;
		}
		else 
		{
			quizNormalPanel.SetActive (false);
			quizFirstTimePanel.SetActive (true);
		}
	}
	public void OpenLabsPanel()
	{
		wtsPanel.SetActive (false);
		infoPanel.SetActive (true);
		labPanel.SetActive (true);

		if (PlayerPrefs.HasKey (courseName.text + " Lab Count"))
		{
			labNormalPanel.SetActive (true);
			labFirstTimePanel.SetActive (false);
			labGridPanel.GetComponent<LabsManager> ().goingToOpen = true;
		}
		else 
		{
			labNormalPanel.SetActive (false);
			labFirstTimePanel.SetActive (true);
		}
	}
	public void OpenHomeworksPanel()
	{
		wtsPanel.SetActive (false);
		infoPanel.SetActive (true);
		homeworkPanel.SetActive (true);

		if (PlayerPrefs.HasKey (courseName.text + " Homework Count"))
		{
			homeworkNormalPanel.SetActive (true);
			homeworkFirstTimePanel.SetActive (false);
			homeworkGridPanel.GetComponent<HomeworksManager> ().goingToOpen = true;
		}
		else 
		{
			homeworkNormalPanel.SetActive (false);
			homeworkFirstTimePanel.SetActive (true);
		}
	}
}
