using UnityEngine;
using System.Collections;

public class Region : MonoBehaviour
{
	public RegionManager regionManager;
	public string sName;
	public string sNamesNPCinRegion;


	public enum DensityType { City, town, village, country, road };

	public DensityType eDensityType;


	ArrayList npcsInRegion;

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


	
}
