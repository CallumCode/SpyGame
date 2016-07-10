using UnityEngine;
using System.Collections;


public class Event  
{

	public NPCManager NPCManager;
	ActionManager actionManager;
	Action action;
	NPC Target;
	NPC Instigator;
	Region Location;

	public Event(Action inAction, NPCManager inNPCManager)
	{
		NPCManager = inNPCManager;
		action = inAction;
		CreateEventFromAction();
	}


	public Event(NPC inInstigator, ArrayList npcsInRegion , ActionManager inActionManager, Region inLocation)
	{
 		Instigator = inInstigator;
		Location = inLocation;
		actionManager = inActionManager;
		CreateEventFromInstigator(npcsInRegion);

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

	void CreateEventFromInstigator(ArrayList npcsInRegion )
	{
		action = actionManager.GetAction();

		if (action.DoesRequireInstigator() == false)
		{
			Debug.Log("CreateEventFromInstigator but does not require one ");
		}

		if (action.DoesRequireTarget())
		{
			npcsInRegion.Remove(Instigator);

			float count = npcsInRegion.Count;
			int targetIndex = (int)(Random.value * count);
			Target = (NPC)npcsInRegion[targetIndex];

			npcsInRegion.Add(Instigator);
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
		if (Location != null) desc += " " + Location.sName;

		desc += "\n";
		return desc;
	}

	public void SetLocation(Region startLoccation)
	{
		Location = startLoccation;
	}


	// Geters

		
	//Compare Functions
	public int CompaireAction(Action  inAction)
	{
		if (action == null) return 0;

		if (inAction != null && action.sName == inAction.sName) return 1;
		
		return -1;
	}

	public int CompareNPCTarget(NPC inNPC)
	{
		if (Target == null) return 0;

		if (inNPC!= null && inNPC.sName == Target.sName) return 1;
		return -1;
	}

	public int CompareNPCInstigator(NPC inNPC)
	{
		if (Instigator == null) return 0;

		if (inNPC != null && inNPC.sName == Instigator.sName) return 1;
		return -1;
	}
}
