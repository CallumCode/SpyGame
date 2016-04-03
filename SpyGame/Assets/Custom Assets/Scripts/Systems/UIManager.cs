using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Text EventHistory;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	 {
	
	}

	public void NewEvent(string eventDesc)
	{

		EventHistory.text += "\n" + eventDesc;
	}
}
