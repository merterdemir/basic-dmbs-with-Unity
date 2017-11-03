using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidtermSelectionController : MonoBehaviour {

	private MFNormalController normalPanelController;
	// Use this for initialization
	void Awake () {

		normalPanelController = transform.parent.transform.parent.transform.parent.GetComponent<MFNormalController> ();
		
	}

	public void ButtonClicked()
	{
		normalPanelController.ChangeGradeField (transform.gameObject);
	}
}
