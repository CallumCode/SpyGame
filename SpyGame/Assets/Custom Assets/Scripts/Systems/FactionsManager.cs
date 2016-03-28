using UnityEngine;
using System.Collections;

public class FactionsManager : MonoBehaviour
{

	  ArrayList factionsContainer;


	// Use this for initialization
	void Start()
	{
		factionsContainer = new ArrayList();
	}

	// Update is called once per frame
	void Update()
	{

	}

	ArrayList GetContainer()
	{
		return factionsContainer;
	}

	
	public void AddFaction(Faction inFaction)
	{
		if(factionsContainer == null)
		{
			factionsContainer = new ArrayList();
		}

		factionsContainer.Add(inFaction);
	}
}
