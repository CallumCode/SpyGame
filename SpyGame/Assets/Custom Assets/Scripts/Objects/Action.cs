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

	public void SetRequiresInstigator()
	{
		bInstigator = true;
	}

	public void SetRequiresTarget()
	{
		bTarget = true;
	}


	public bool DoesRequireTarget()
	{
		return bTarget;
	}


	public bool DoesRequireInstigator()
	{
		return bInstigator;
	}
}
