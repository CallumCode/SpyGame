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
}
