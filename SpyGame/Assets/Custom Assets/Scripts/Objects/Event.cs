using UnityEngine;
using System.Collections;


public class Event  
{

	public NPCManager NPCManager;
	
	Action action;
	NPC Target;
	NPC Instigator;

	public Event(Action inAction, NPCManager inNPCManager)
	{
		NPCManager = inNPCManager;
		action = inAction;
		CreateEventFromAction();
	}


	void CreateEventFromAction()
	{
		
		if(action == null)
		{
			Debug.Log("CreateEventFromAction action is nulll");
			return;
		}

		if(action.DoesRequireInstigator())
		{
			FindInstigator();
		}

		if(action.DoesRequireTarget() )
		{
			FindTarget();
		}


	}


	void FindTarget()
	{

		Target = NPCManager.GetTarget(Instigator);

	}



	void FindInstigator()
	{
		Instigator = NPCManager.GetInstigator();
	}


	public string GetStringDesc()
	{

		string desc = "" + System.Math.Round(Time.time, 2);
		if(Instigator != null) desc += " " + Instigator.sName;
		if(action != null) desc += " " + action.sName;
		if(Target != null) desc += " " + Target.sName;

		return desc;
	}
}
