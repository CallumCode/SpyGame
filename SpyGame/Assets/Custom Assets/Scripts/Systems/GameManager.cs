using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public ActionDataReader ActionDataReader;
	public FactionDataReader FactionDataReader;
	public NPCDataReader NPCDataReader;


	public NPCManager NPCManager;
	public RegionManager RegionManager;
	// Use this for initialization
	void Start () 
	{
		ReadData();

		RegionManager.SpawnMap();


		NPCManager.SpreadOutNPCs();

	}

	// Update is called once per frame
	void Update ()
	 {
	
	}


	void ReadData()
	{
		ActionDataReader.ReadAllActions();
		FactionDataReader.ReadAllFactions();
		NPCDataReader.ReadAllNPCs();

	}
}
