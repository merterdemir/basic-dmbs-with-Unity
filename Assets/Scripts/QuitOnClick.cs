using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

	private float delay = 0.6f;


	public void Quit()
	{
		Invoke("AfterDelay", delay);
	}

	void AfterDelay()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
