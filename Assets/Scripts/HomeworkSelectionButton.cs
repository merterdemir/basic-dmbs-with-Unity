using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeworkSelectionButton : MonoBehaviour {

	private HomeworkNormalController normalPanelController;
	// Use this for initialization
	void Awake () {

		normalPanelController = transform.parent.transform.parent.transform.parent.GetComponent<HomeworkNormalController> ();

	}

	public void ButtonClicked()
	{
		normalPanelController.ChangeGradeField (transform.gameObject);
	}
}
