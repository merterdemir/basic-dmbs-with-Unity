using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditTextVisibility : MonoBehaviour {

	public GameObject editText;
	public GameObject normalText;

	// Update is called once per frame
	void Update () {
		normalText.SetActive (!editText.activeSelf);
	}
}
