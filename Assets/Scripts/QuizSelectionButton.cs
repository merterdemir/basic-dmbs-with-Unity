using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSelectionButton : MonoBehaviour {

	private QuizNormalController normalPanelController;
	// Use this for initialization
	void Awake () {

		normalPanelController = transform.parent.transform.parent.transform.parent.GetComponent<QuizNormalController> ();

	}

	public void ButtonClicked()
	{
		normalPanelController.ChangeGradeField (transform.gameObject);
	}
}
