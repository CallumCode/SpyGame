using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIRegion : MonoBehaviour
{

	public Text RegionName;
	public Text RegionType;
	public Text NpcsInRegion;



	// Use this for initializationv
	void Start()
	{
		HideInfo();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetRegion(Region inRegion)
	{
		if(inRegion)
		{
			RegionName.text = inRegion.sName;

			NpcsInRegion.text = inRegion.sNamesNPCinRegion;

			ShowrRgionType(inRegion.eDensityType);
		}
		else
		{
			HideInfo();
		}

	}

	void HideInfo()
	{
		RegionName.text = "";
		RegionType.text = "";
		NpcsInRegion.text = "";
	}

	void ShowrRgionType(Region.DensityType type)
	{

		switch (type)
		{
			case Region.DensityType.City:
				RegionType.text = "City";
				break;
			case Region.DensityType.country:
				RegionType.text = "country";
				break;
			case Region.DensityType.road:
				RegionType.text = "road";
				break;
			case Region.DensityType.town:
				RegionType.text = "town";
				break;
			case Region.DensityType.village:
				RegionType.text = "village";
				break;
		}
	}
}
