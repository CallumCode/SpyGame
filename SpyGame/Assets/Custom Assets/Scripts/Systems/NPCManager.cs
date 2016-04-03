using UnityEngine;
using System.Collections;

public class NPCManager : MonoBehaviour
{
	ArrayList npcContainer;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void AddNPC(NPC npc)
	{
		if(npcContainer == null)
		{
			npcContainer = new ArrayList();
		}


		npc.iId = npcContainer.Count;

		npcContainer.Add(npc);
	}


	public NPC GetTarget(NPC subject)
	{
		NPC target = null;

		if (npcContainer != null && npcContainer.Count > 1)
		{
			int index = Random.Range(0, npcContainer.Count);
			target = (NPC)npcContainer[index];

			if (target.iId == subject.iId) 
			{
				target = GetTarget(subject);
			}

		}
		return target;
	}


	public NPC GetInstigator()
	{
		NPC instigator = null;

		if (npcContainer != null && npcContainer.Count > 0)
		{
			int index = Random.Range(0, npcContainer.Count);
			instigator = (NPC)npcContainer[index];
		}
		return instigator;
	}
}
