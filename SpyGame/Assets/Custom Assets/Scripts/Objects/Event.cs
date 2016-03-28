using UnityEngine;
using System.Collections;

public class Event  
{

	Action Action;
	NPC Target;
	NPC Instigator;

	public Event(Action inAction)
	{
		Action = inAction;
	}
}
