using UnityEngine;
using System.Collections;
using System;

public class Region : MonoBehaviour
{
	public EventManager eventManager;
	public RegionManager regionManager;
	
	 
	public   Sprite[] regionSprites;
	//
	public string sName;
	public int depth;
	public GameObject[] neighbours;

	//
	public string sNamesNPCinRegion;



	public enum DensityType {
		town,
		village,
		country,
		count
	};

	public DensityType eDensityType;


	ArrayList npcsInRegion;

	ArrayList localEventHistory;


	public bool UINeedsUpdate;


	
	void Awake()
	{

		sName = "Region Name " + Math.Round( UnityEngine.Random.value * 100 ,1);

		int type = UnityEngine.Random.Range(0 , (int)DensityType.count);

		eDensityType = (DensityType)type;
		if(type >= 0 && type < (int) DensityType.count)	GetComponent<SpriteRenderer>().sprite = regionSprites[type];

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void AddNpcToRegion(NPC npc)
	{
		if (npcsInRegion == null) npcsInRegion = new ArrayList();
		npcsInRegion.Add(npc);

		sNamesNPCinRegion += "\n" + npc.sName;

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
			UINeedsUpdate = true;
		}

	}

}
