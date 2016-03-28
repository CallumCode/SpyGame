using UnityEngine;
using System.Collections;
using System.Xml;

public class FactionDataReader : MonoBehaviour
{
	const string sFactionFileTime = "Factions.xml";

	public FactionsManager FactionsManager;

	// Use this for initialization
	void Start()
	{
		ReadAllFactions();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void ReadAllFactions()
	{
		XmlDocument xmlDoc = new XmlDocument();
		string path = (Application.dataPath + "/Custom Assets/Xml/" + sFactionFileTime);
		xmlDoc.Load(path);

		xmlDoc.GetElementsByTagName("Faction");

		XmlNodeList nodelist = xmlDoc.GetElementsByTagName("Faction");// get all <faction> nodes

		foreach (XmlNode node in nodelist) // for each <faction> node
		{
			LoadAFaction(node);
		}
	}

	void LoadAFaction(XmlNode factionNode)
	{
		Faction newFaction = new Faction();

 		XmlNodeList factionChildNodes = factionNode.ChildNodes;
		foreach (XmlNode node in factionChildNodes)
		{
			if (node.Name == "Name")
			{
				LoadName(node, newFaction);
			}
		}

		FactionsManager.AddFaction(newFaction);
	}

	void LoadName(XmlNode nameNode, Faction newFaction)
	{
		string name = nameNode.FirstChild.Value;
		newFaction.sName = name;
		Debug.Log("create new faction : " + name);
	}
}
