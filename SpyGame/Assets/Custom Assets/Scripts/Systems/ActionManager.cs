using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour 
{
	ArrayList actionContainer;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	 {
	
	}

	public void AddAction(Action newAction)
	{
		if(actionContainer == null)
		{
			actionContainer = new ArrayList();
		}

		actionContainer.Add(newAction);
		
	}

	public Action GetAction()
	{
		Action action = null;

		if (actionContainer != null && actionContainer.Count > 0)
		{
			action = (Action)actionContainer[0];
		}

		
		return action;
	}
}
