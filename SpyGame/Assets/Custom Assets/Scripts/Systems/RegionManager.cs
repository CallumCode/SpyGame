using UnityEngine;
using System.Collections;

public class RegionManager : MonoBehaviour 
{

	ArrayList regionConainter;
	public EventManager eventManager;

	public	GameObject RegionTilePrefab;

	// Use this for initialization
	void Start()
	{




	}

	// Update is called once per frame
	void Update()
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


	void SpawnRegion(Vector3 pos)
	{
		GameObject newTile = Instantiate(RegionTilePrefab, pos, Quaternion.identity) as GameObject;


		Region newRegon = newTile.GetComponent<Region>();
		newRegon.regionManager = this;
		newRegon.eventManager = eventManager;
		AddRegion(newRegon);
	}




	public void SpawnMap()
	{

		float dist = 3.2f;
		SpawnRegion(Vector3.zero);

		for (float angle = 0; angle < 60 * 6; angle += 60)
		{
			Vector3 pos = Quaternion.Euler(0, 0, angle) * Vector3.up * dist;
			SpawnRegion(pos); 
		}
	}
}
