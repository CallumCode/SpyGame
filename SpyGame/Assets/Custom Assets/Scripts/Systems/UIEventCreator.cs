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

			ArrayList regions = RegionManager.GetAllRegions();
			Region region = null;
			if(regions != null)
			{
				region = (Region)regions[RegionDropDown.value];
			}

			Debug.Log(" Checking " + eventHistory.Count);


			int actionCorrect = 0;
			int instagatorCorrect = 0;
			int targetCorrect = 0;
			int turnCorrect = 0;
			int regionCorrect = 0;

			foreach (Event anEvent in eventHistory)
			{
				correctCount = 0;
				wrongCount = 0;
 
				actionCorrect = 0;
				instagatorCorrect = 0;
				targetCorrect = 0;
				turnCorrect = 0;
				regionCorrect = 0;


				// Check if we guess the right action
				actionCorrect = anEvent.CompaireAction(action);
				correctCount += Mathf.Max(0, actionCorrect);
				wrongCount += Mathf.Min(0, actionCorrect);

				// Check if npc who did it was guessed 
				instagatorCorrect = anEvent.CompareNPCInstigator(npcInstigator);
				correctCount += Mathf.Max(0, instagatorCorrect);
				wrongCount += Mathf.Min(0, instagatorCorrect);

				// Check if target npc was guessed 
				targetCorrect = anEvent.CompareNPCTarget(npcTarget);
				correctCount += Mathf.Max(0, targetCorrect);
				wrongCount += Mathf.Min(0, targetCorrect);

				// Check if exact turn was guesed - change to range later
				int inputTurnInt = Convert.ToInt32( TurnInput.text);
				turnCorrect = anEvent.CompaureStartTurn(inputTurnInt);
				correctCount += Mathf.Max(0, turnCorrect);
				wrongCount += Mathf.Min(0, turnCorrect);

				// Check if correct locaiton was guessed
				regionCorrect = anEvent.CompaureRegion(region);
				correctCount += Mathf.Max(0, regionCorrect);
				wrongCount += Mathf.Min(0, regionCorrect);

				if (correctCount > bestGuess)
				{
					simularEvents.Clear();

					simularEvents.Add(anEvent);
					bestGuess = correctCount;
					bestWrong = Mathf.Abs(wrongCount);
					//Debug.Log("new best actionCorrect " + actionCorrect + " instagatorCorrect " + instagatorCorrect);
					//Debug.Log("targetCorrect " +  targetCorrect + " turnCorrect " + turnCorrect + " regionCorrect " +regionCorrect);
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
