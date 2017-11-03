using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class BackButtonController : MonoBehaviour {

	public GameObject questPanel;
	public GameObject deleteErrorPanel;
	public GameObject addPanel;
	public GameObject deletePanel;
	public GameObject successNotification;
	public Button deleteButton;
	public Button addButton;
	public Button cancelButton;

	public void GoBack()
	{
		if (addPanel.activeSelf) 
		{
			if (successNotification.activeSelf)
				successNotification.SetActive (false);
			addPanel.SetActive (false);
			questPanel.SetActive (true);
			addButton.gameObject.SetActive (false);
			cancelButton.gameObject.SetActive (true);
			transform.gameObject.SetActive (false);
		}
		else if (deletePanel.activeSelf) 
		{
			deletePanel.SetActive (false);
			questPanel.SetActive (true);
			deleteButton.gameObject.SetActive (false);
			cancelButton.gameObject.SetActive (true);
			transform.gameObject.SetActive (false);
		}
		else if (deleteErrorPanel.activeSelf) 
		{
			deleteErrorPanel.SetActive (false);
			questPanel.SetActive (true);
			cancelButton.gameObject.SetActive (true);
			transform.gameObject.SetActive (false);
		}
	}
}
