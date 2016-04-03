using UnityEngine;
using System.Collections;
using System.Xml;

public class ActionDataReader : MonoBehaviour
 
{
	const string sActionFileName = "ACtions.xml";

	public ActionManager ActionManager;

	// Use this for initialization
	void Start()
	{
		ReadAllActions();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void ReadAllActions()
	{
		XmlDocument xmlDoc = new XmlDocument();
		string path = (Application.streamingAssetsPath + "/Xml/" + sActionFileName);
		xmlDoc.Load(path);

		xmlDoc.GetElementsByTagName("Actions");

		XmlNodeList nodelist = xmlDoc.GetElementsByTagName("Action");

		foreach (XmlNode node in nodelist)
		{
			LoadAction(node);
		}
	}

	void LoadAction(XmlNode npcNode)
	{
		Action newAction = new Action();
		
		XmlNodeList factionChildNodes = npcNode.ChildNodes;
		foreach (XmlNode node in factionChildNodes)
		{
			if (node.Name == "Name")
			{
				LoadName(node, newAction);
			}

			if (node.Name == "Requires")
			{
				LoadRequirement(node, newAction);
			}
		}

		ActionManager.AddAction(newAction);
	}

	void LoadName(XmlNode nameNode, Action newAction)
	{
		string name = nameNode.FirstChild.Value;
		newAction.sName = name;
		Debug.Log("create new Action: " + name);
	}


	void LoadRequirement(XmlNode nameNode, Action newAction)
	{
		if (nameNode.FirstChild.Value == "Instigator")
		{
			newAction.SetRequiresInstigator();
		}
		if (nameNode.FirstChild.Value == "Target")
		{
			newAction.SetRequiresTarget();
		}


	}
}
