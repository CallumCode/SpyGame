using UnityEngine;
using System.Collections;
using System;

public class Region : MonoBehaviour
{
	public EventManager eventManager;
	public RegionManager regionManager;
	public string sName;
	public string sNamesNPCinRegion;


	public enum DensityType { City, town, village, country, road };

	public DensityType eDensityType;


	ArrayList npcsInRegion;

	ArrayList localEventHistory;

	// Use this for initialization
	void Start()
	{
		regionManager.AddRegion(this);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void AddNpcToRegion(NPC npc)
	{
		if (npcsInRegion == null) npcsInRegion = new ArrayList();
		npcsInRegion.Add(npc);

		sNamesNPCinRegion += " " + npc.sName;

		Debug.Log(npc.sName + " arrived in " + sName);
	}

	public string GetAllEventDesc()
	{
		string desc = "";

		if(localEventHistory!= null)
		{
			foreach(Event theEvent in localEventHistory)
			{
				desc += theEvent.GetStringDesc();
			}
		}

		return desc;
	}

	public void CreateEvenFromNPCs()
	{
		if (npcsInRegion == null) return;

		float count = npcsInRegion.Count;
		if (count < 2) return;

		int instigatorIndex = (int)(UnityEngine.Random.value * count);

		NPC instigator = (NPC) npcsInRegion[instigatorIndex];
		if (instigator == null) return;

		Event theEvent =  eventManager.CreatNewEventFromNPC(instigator , npcsInRegion , this);
		
		if (theEvent != null)
		{
			if (localEventHistory == null) localEventHistory = new ArrayList();
			localEventHistory.Add(theEvent);
		}

	}
}
