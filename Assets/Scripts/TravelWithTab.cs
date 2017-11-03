using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TravelWithTab : MonoBehaviour {

	public EventSystem system;
	public List<GameObject> objects;

	private int size, counter;
	private GameObject currentSelectedGameObject;

	void Awake()
	{
		size = objects.Count;
		counter = 0;
	}
	// Update is called once per frame
	void Update () {

		currentSelectedGameObject = system.currentSelectedGameObject;

		if (Input.GetKeyDown (KeyCode.Tab)) 
		{
			if (objects [counter] != null) 
			{
				if (currentSelectedGameObject == objects [counter]) 
				{
					if (counter != size - 1)
						counter++;
					else
						counter = 0;
				}
				else
					counter = 0;

				system.SetSelectedGameObject (objects [counter]);
			}
			
		}
		
	}
}
