using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabSelectionButton : MonoBehaviour {

	private LabNormalController normalPanelController;
	// Use this for initialization
	void Awake () {

		normalPanelController = transform.parent.transform.parent.transform.parent.GetComponent<LabNormalController> ();

	}

	public void ButtonClicked()
	{
		normalPanelController.ChangeGradeField (transform.gameObject);
	}
}
