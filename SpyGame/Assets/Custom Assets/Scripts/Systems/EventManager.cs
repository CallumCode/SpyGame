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
		if (Input.GetKeyDown(KeyCode.Space) )
		{
			CreateNewEvent();
		}
	}


	void CreateNewEvent()
	{
		if (eventHistory == null) eventHistory = new ArrayList();

		Action action = actionManager.GetAction();
		Event newEvent = new Event(action , NPCManager);

		UIManager.NewEvent(newEvent.GetStringDesc());
		eventHistory.Add(newEvent);

	}
}
