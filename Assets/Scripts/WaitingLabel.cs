using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingLabel : MonoBehaviour {

	public Text waitingLabel;

	private string phase1;
	private string phase2;
	private string phase3;

	private float timer;

	void Awake () {
		phase1 = "Waiting for your choice.";
		phase2 = "Waiting for your choice..";
		phase3 = "Waiting for your choice...";

		timer = 3f;
	}
	
	// Update is called once per frame
	void Update () {

		if (timer <= 3 && timer >= 2) 
		{
			waitingLabel.text = phase1;
			timer -= Time.deltaTime;			
		} 
		else if (timer < 2 && timer >= 1) 
		{
			waitingLabel.text = phase2;
			timer -= Time.deltaTime;
		} 
		else if (timer < 1 && timer >= 0)
		{
			waitingLabel.text = phase3;
			timer -= Time.deltaTime;
		}
		else
			timer = 3f;
	}
}
