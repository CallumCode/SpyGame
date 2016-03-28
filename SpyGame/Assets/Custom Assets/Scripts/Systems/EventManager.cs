using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour 
{

	ArrayList eventHistory;

	ActionManager actionManager;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	 {
	
	}


	void CreateNewEvent()
	{

		Action action = actionManager.GetAction();
		Event newEvent = new Event(action);

		eventHistory.Add(newEvent);

	}
}
