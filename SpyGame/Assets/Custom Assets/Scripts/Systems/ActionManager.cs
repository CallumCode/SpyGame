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
			int index = Random.Range(0, actionContainer.Count );
			action = (Action)actionContainer[index];
		}

		
		return action;
	}
}
