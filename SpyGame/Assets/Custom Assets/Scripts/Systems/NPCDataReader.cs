using UnityEngine;
using System.Collections;
using System.Xml;

public class NPCDataReader : MonoBehaviour 
{
	const string sFactionFileTime = "NPCs.xml";

	public NPCManager NPCManager;

	// Use this for initialization
	void Start () 
	{
		ReadAllNPCs();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void ReadAllNPCs()
	{
		XmlDocument xmlDoc = new XmlDocument();
		string path = (Application.streamingAssetsPath + "/Xml/" + sFactionFileTime);
		xmlDoc.Load(path);

		xmlDoc.GetElementsByTagName("NPCs");

		XmlNodeList nodelist = xmlDoc.GetElementsByTagName("NPC");

		foreach (XmlNode node in nodelist) 
		{
			LoadNPC(node);
		}

		NPCManager.SpreadOutNPCs();
	}

	void LoadNPC(XmlNode npcNode)
	{
		NPC newNPC = new NPC();


		XmlNodeList factionChildNodes = npcNode.ChildNodes;
		foreach (XmlNode node in factionChildNodes)
		{
			if (node.Name == "Name")
			{
				LoadName(node, newNPC);
			}
		}

		NPCManager.AddNPC(newNPC);
	}

	void LoadName(XmlNode nameNode, NPC newNPC)
	{
		string name = nameNode.FirstChild.Value;
		newNPC.sName = name;
//		Debug.Log("create new NPC : " + name) ;
	}
}
