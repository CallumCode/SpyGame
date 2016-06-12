using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIRegion : MonoBehaviour
{

	public Text RegionName;
	public Text RegionType;
	public Text NpcsInRegion;

	public Text EventHistoryinRegion;
	public Text EventHistoryTitle;

	Region region;

	// Use this for initializationv
	void Start()
	{
		HideInfo();
	}

	// Update is called once per frame
	void Update()
	{

		if (region && region.UINeedsUpdate)
		{
			RefreshUI();
		}

	}

	public void SetRegion(Region inRegion)
	{
		region = inRegion;
		RefreshUI();
	}

	void HideInfo()
	{
		RegionName.text = "";
		RegionType.text = "";
		NpcsInRegion.text = "";
		EventHistoryinRegion.text = "";
		EventHistoryTitle.text = "";
	}

	void ShowrRgionType(Region.DensityType type)
	{

		switch (type)
		{
			//case Region.DensityType.City:
				//RegionType.text = "City";
				//break;
			case Region.DensityType.country:
				RegionType.text = "country";
				break;
			//case Region.DensityType.road:
			//	RegionType.text = "road";
				//break;
			case Region.DensityType.town:
				RegionType.text = "town";
				break;
			case Region.DensityType.village:
				RegionType.text = "village";
				break;
		}
	}


	void RefreshUI()
	{
		if (region != null )
		{
			RegionName.text = region.sName;

			NpcsInRegion.text = region.sNamesNPCinRegion;

			ShowrRgionType(region.eDensityType);

			EventHistoryinRegion.text = "";
			EventHistoryinRegion.text = region.GetAllEventDesc();

			region.UINeedsUpdate = false;

			EventHistoryTitle.text = "Local History"; //TODO hide it 

		}
		else
		{
			HideInfo();
		}
	}
}
