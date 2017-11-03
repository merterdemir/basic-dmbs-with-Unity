using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeUserSettings : MonoBehaviour {

	public InputField usrInputField;
	public InputField oldPwdInputField;
	public InputField newPwdInputField;
	public GameObject changePanel;
	public EnterChecker enterChecker;
	public EventSystem system;
	public GameObject cancelButton;

	private string oldUsername;
	private string newUsername;
	private string oldPassword;
	private string newPassword;
	private string dummy;
	private string usrInput;
	private EncodeDecode decoder;
	private GameObject currentSelectedGameObject;


	// Use this for initialization
	void Awake () {
		
		usrInput = "";
		dummy = "";
		oldUsername = "";
		newUsername = "";
		oldPassword = "";
		newPassword = "";
		decoder = transform.GetComponent<EncodeDecode> ();

		dummy = "User Username";
		dummy = decoder.Base64Encode (dummy);
		if (PlayerPrefs.HasKey (dummy))
			oldUsername = PlayerPrefs.GetString (dummy);
		oldUsername = decoder.Base64Decode (oldUsername);

		dummy = "User Password";
		dummy = decoder.Base64Encode (dummy);
		if (PlayerPrefs.HasKey (dummy))
			oldPassword = PlayerPrefs.GetString (dummy);
		oldPassword = decoder.Base64Decode (oldPassword);


	}
	void Update()
	{
		currentSelectedGameObject = system.currentSelectedGameObject;
		usrInput = new System.String (' ', usrInputField.text.Length);
		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			if (currentSelectedGameObject == usrInputField.gameObject)
				system.SetSelectedGameObject (oldPwdInputField.gameObject, new BaseEventData (system));
			else if (currentSelectedGameObject == oldPwdInputField.gameObject)
				system.SetSelectedGameObject (newPwdInputField.gameObject, new BaseEventData (system));
			else if (currentSelectedGameObject == newPwdInputField.gameObject)
				system.SetSelectedGameObject (cancelButton, new BaseEventData (system));
			else if (currentSelectedGameObject == cancelButton)
				system.SetSelectedGameObject (gameObject, new BaseEventData (system));
			else if (currentSelectedGameObject == gameObject)
				system.SetSelectedGameObject (usrInputField.gameObject, new BaseEventData (system));
			else if (changePanel.activeSelf)
				system.SetSelectedGameObject (usrInputField.gameObject, new BaseEventData (system));
		}
	}

	public void ClickedChange()
	{
		if (usrInputField.text != "" && usrInputField.text != usrInput)
		{
			if (oldPassword != oldPwdInputField.text)
				oldPwdInputField.transform.Find ("Text").GetComponent<Text> ().color = Color.red;
			else 
			{
				oldPwdInputField.transform.Find ("Text").GetComponent<Text> ().color = new Color((float) 50/255, (float) 50/255, (float)50/255, 1f);
				newUsername = usrInputField.text;
				newPassword = newPwdInputField.text;

				enterChecker.RefreshData (newUsername, newPassword);

				newUsername = decoder.Base64Encode (newUsername);
				newPassword = decoder.Base64Encode (newPassword);

				dummy = "User Username";
				dummy = decoder.Base64Encode (dummy);
				if (PlayerPrefs.HasKey (dummy))
					PlayerPrefs.SetString (dummy, newUsername);

				dummy = "User Password";
				dummy = decoder.Base64Encode (dummy);
				if (PlayerPrefs.HasKey (dummy))
					PlayerPrefs.SetString (dummy, newPassword);

				changePanel.SetActive (false);

			}
		}
		else 
		{
			if (oldPassword != oldPwdInputField.text)
				oldPwdInputField.transform.Find ("Text").GetComponent<Text> ().color = Color.red;
			else
			{
				oldPwdInputField.transform.Find ("Text").GetComponent<Text> ().color = new Color ((float)50 / 255, (float)50 / 255, (float)50 / 255, 1f);
				newPassword = newPwdInputField.text;

				enterChecker.RefreshData (oldUsername, newPassword);

				newPassword = decoder.Base64Encode (newPassword);

				dummy = "User Password";
				dummy = decoder.Base64Encode (dummy);
				if (PlayerPrefs.HasKey (dummy))
					PlayerPrefs.SetString (dummy, newPassword);

				changePanel.SetActive (false);
			}
		}
	}
}
