using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnterChecker : MonoBehaviour {

	public InputField usrInputField;
	public InputField pwdInputField;
	public GameObject normalText;
	public GameObject errorText;
	public Button enterButton;
	public EventSystem system;
	public GameObject changeButton;
	public GameObject quitButton;
	public GameObject changePanel;

	private string username;
	private string password;
	private EncodeDecode decoder;
	private string dummy;
	private string usrInput;
	private GameObject currentSelectedGameObject;

	// Use this for initialization
	void Awake () {
		usrInput = "";

		username = "admin";
		password = "admin";

		decoder = transform.GetComponent<EncodeDecode> ();

		username = decoder.Base64Encode (username);
		password = username;

		dummy = "User Username";
		dummy = decoder.Base64Encode (dummy);
		if (!PlayerPrefs.HasKey (dummy))
			PlayerPrefs.SetString (dummy, username);
		else
			username = PlayerPrefs.GetString (dummy);
		
		dummy = "User Password";
		dummy = decoder.Base64Encode (dummy);
		if (!PlayerPrefs.HasKey (dummy))
			PlayerPrefs.SetString (dummy, password);
		else
			password = PlayerPrefs.GetString (dummy);

		username = decoder.Base64Decode (username);
		password = decoder.Base64Decode (password);


	}

	void Update()
	{
		currentSelectedGameObject = system.currentSelectedGameObject;
		usrInput = new System.String (' ', usrInputField.text.Length);

		if (usrInputField.text != "" && usrInputField.text != usrInput)
			enterButton.interactable = true;
		else
			enterButton.interactable = false;

		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			if (currentSelectedGameObject == usrInputField.gameObject)
				system.SetSelectedGameObject (pwdInputField.gameObject, new BaseEventData (system));
			else if (currentSelectedGameObject == pwdInputField.gameObject) 
			{
				if (enterButton.interactable)
					system.SetSelectedGameObject (enterButton.gameObject, new BaseEventData (system));
				else
					system.SetSelectedGameObject (changeButton, new BaseEventData (system));
			}
			else if (currentSelectedGameObject == enterButton.gameObject)
				system.SetSelectedGameObject(changeButton, new BaseEventData(system));
			else if (currentSelectedGameObject == changeButton)
				system.SetSelectedGameObject(quitButton, new BaseEventData(system));
			else if (currentSelectedGameObject == quitButton)
				system.SetSelectedGameObject(usrInputField.gameObject, new BaseEventData(system));
			else if (!changePanel.activeSelf)
				system.SetSelectedGameObject(usrInputField.gameObject, new BaseEventData(system));
		}
			
	}

	public void ClickedEnter()
	{
		
		if ((usrInputField.text != username) || (pwdInputField.text != password)) {
			normalText.SetActive (false);
			errorText.SetActive (true);
			return;
		}
		else 
		{
			errorText.SetActive (false);
			usrInputField.text = "";
			pwdInputField.text = "";
			transform.GetComponent<LoadSceneOnClick> ().LoadSceneLast ();
		}
		
	}
	public void RefreshData(string newUsr, string newPwd )
	{
		username = newUsr;
		password = newPwd;
	}
}
