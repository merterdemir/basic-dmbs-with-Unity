using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteEditting : MonoBehaviour, IPointerClickHandler {

	public InputField inputField;
	public EventSystem eventSystem;

	string stringEdit = "";

	public void OnValueChanged()
	{
		if (!Input.GetKeyDown(KeyCode.Escape))
		{
			stringEdit = inputField.text;
		}
	}

	public void OnEndEdit()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			inputField.text = stringEdit;
		}
	}

	public void OnPointerClick(PointerEventData eventdata)
	{
		eventSystem.SetSelectedGameObject (inputField.gameObject);
	}

	public void ClearText()
	{
		inputField.text = "";
	}
}
