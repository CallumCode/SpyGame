using UnityEngine;
using System.Collections;

public class Action
{
	public string sName;


	bool bInstigator = false ;
	bool bTarget = false;


	public Action()
	{

	}

	public void RequiresInstigator()
	{
		bInstigator = true;
	}

	public void RequiresTarget()
	{
		bTarget = true;
	}
}
