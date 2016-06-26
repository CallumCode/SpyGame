using UnityEngine;
using System.Collections;
using System;

public class NPC 
{

	public  int iId;
	public string sName;


	public NPC()
	{
		iId = -1;
		sName = "Uknown";
	}

    public string GetName()
    {
        return sName;
    }
}
