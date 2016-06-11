using UnityEngine;
using System.Collections;

public class RegionManager : MonoBehaviour 
{

	ArrayList regionConainter;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	 {
	
	}

	public void AddRegion(Region region)
	{
		if (regionConainter == null) regionConainter = new ArrayList();

		regionConainter.Add(region);
	}


	public Region GetRandomRegion()
	{
		Region region = null;


		if(regionConainter != null && regionConainter.Count > 0)
		{
			int index = (int)(Random.value * regionConainter.Count);

			region = (Region)regionConainter[index];

		}

		return region;
	}

	public void CreateEventInEachRegion()
	{

		foreach (Region region in regionConainter)
		{
			region.CreateEvenFromNPCs();
		}
	}
}
