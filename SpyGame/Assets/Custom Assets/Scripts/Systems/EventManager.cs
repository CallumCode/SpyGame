using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
	public UIManager UIManager;

	ArrayList eventHistory;

	public ActionManager actionManager;

	public NPCManager NPCManager;



	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	/*
	void CreateNewEvent()
	{
		if (eventHistory == null) eventHistory = new ArrayList();

		Action action = actionManager.GetAction();
		Event newEvent = new Event(action , NPCManager);

		UIManager.NewEvent(newEvent.GetStringDesc());
		eventHistory.Add(newEvent);

	}*/

	public	Event CreatNewEventFromNPC(NPC instigator , ArrayList npcsInRegion , Region inLocation)
	{
		Event newEvent = null;
		
		newEvent = new Event(instigator, npcsInRegion , actionManager , inLocation);
		UIManager.NewEvent(newEvent.GetStringDesc());

		if (eventHistory == null) eventHistory = new ArrayList();

		eventHistory.Add(newEvent);

		return newEvent;
	}


	public ArrayList GetEventHistory()
	{
		return eventHistory;
	}
}
