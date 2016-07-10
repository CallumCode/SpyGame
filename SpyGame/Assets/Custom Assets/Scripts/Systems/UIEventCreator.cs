using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UIEventCreator : MonoBehaviour
{
	public InputField TurnInput;
	public Dropdown NPCInstigatorDropDown;
	public Dropdown NPCTargetDropDown;
	public Dropdown ActionDropDown;
	public Dropdown RegionDropDown;

	public ActionManager ActionManager;
	public NPCManager NPCManager;
	public RegionManager RegionManager;
	public EventManager EventManager;
	public PlayerManager PlayerManager;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void PopulateActions()
	{
		ActionDropDown.ClearOptions();

		ArrayList actions = ActionManager.GetAllActons();

		List<string> options = new List<string>();

		foreach (Action action in actions)
		{
			options.Add(action.GetName());
		}

		ActionDropDown.AddOptions(options);
	}

	void PopulateNPCs()
	{


		NPCInstigatorDropDown.ClearOptions();
		NPCTargetDropDown.ClearOptions();

		ArrayList npcs = NPCManager.GetAllNPCs();

		List<string> options = new List<string>();

		foreach (NPC npc in npcs)
		{
			options.Add(npc.GetName());
		}

		NPCTargetDropDown.AddOptions(options);
		NPCInstigatorDropDown.AddOptions(options);
	}

	void PopulateRegions()
	{
		RegionDropDown.ClearOptions();

		ArrayList regions = RegionManager.GetAllRegions();

		List<string> options = new List<string>();

		foreach (Region region in regions)
		{
			options.Add(region.GetName());
		}

		RegionDropDown.AddOptions(options);
	}

	void PopulateDropdowns()
	{
		PopulateActions();
		PopulateNPCs();
		PopulateRegions();
	}

	public void Toggle()
	{
		if (gameObject.activeSelf)
		{
			gameObject.SetActive(false);

 			Camera.main.transform.forward = Vector3.forward;
		}
		else
		{
 			Camera.main.transform.forward = Vector3.up;

			gameObject.SetActive(true);
			PopulateDropdowns();
		}
	}


public	void CreatEventFromDropDowns()
	{

		int correctCount = 0;
		int wrongCount = 0;

		int bestGuess = 0;
		int bestWrong = 0;

		ArrayList simularEvents = new ArrayList();

		ArrayList eventHistory = EventManager.GetEventHistory();
		if (eventHistory != null)
		{
			Action action = null;
			ArrayList actions = ActionManager.GetAllActons();
			if (actions != null)
			{
				action = (Action)actions[ActionDropDown.value];

			}

			NPC npcTarget = null;
			NPC npcInstigator = null;
			ArrayList npcs = NPCManager.GetAllNPCs();
			if (npcs != null)
			{
				npcTarget = (NPC)npcs[NPCTargetDropDown.value];
				npcInstigator = (NPC)npcs[NPCInstigatorDropDown.value];
			}
			
			Debug.Log(" Checking " + eventHistory.Count);


			foreach (Event anEvent in eventHistory)
			{
				correctCount = 0;
				wrongCount = 0;
				int compare = 0;

				compare = anEvent.CompaireAction(action);
				correctCount += Mathf.Max(0, compare);
				wrongCount += Mathf.Min(0, compare);


				compare = anEvent.CompareNPCInstigator(npcInstigator);
				correctCount += Mathf.Max(0, compare);
				wrongCount += Mathf.Min(0, compare);

				compare = anEvent.CompareNPCTarget(npcTarget);
				correctCount += Mathf.Max(0, compare);
				wrongCount += Mathf.Min(0, compare);


				if (correctCount > bestGuess)
				{
					simularEvents.Clear();

					simularEvents.Add(anEvent);
					bestGuess = correctCount;
					bestWrong = Mathf.Abs(wrongCount);
				}
				else if (correctCount == bestGuess)
				{
					simularEvents.Add(anEvent);
				}
			}


		}


		PlayerManager.SellHasBeenMade(bestGuess,bestWrong);

		// Here we remove the event (or events ) that is cloesest to the guess
		if ( simularEvents.Count > 0) 
		{
			Debug.Log("Sold  Event");


			foreach (Event anEvent in simularEvents)
			{
				Debug.Log("removed "  + anEvent.GetStringDesc() );
				eventHistory.Remove(anEvent);
			}
		}
	}

}
