using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWidth : MonoBehaviour {
	
	public Vector2 minSize;
	public Vector2 maxSize;

	public float widthDifference;
	public float heigthDifference;


	// Use this for initialization
	void Start () {
		Vector2 sizeDelta;
		sizeDelta.x = (float)Screen.width - widthDifference;
		sizeDelta.y = (float)Screen.height - heigthDifference;
		sizeDelta = new Vector2 (
			Mathf.Clamp (sizeDelta.x, minSize.x, maxSize.x),
			Mathf.Clamp (sizeDelta.y, minSize.y, maxSize.y)
		);

		transform.GetComponent<RectTransform> ().sizeDelta = sizeDelta;
	}

}
