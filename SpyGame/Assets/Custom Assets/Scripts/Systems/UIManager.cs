using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Text EventHistory;

	public UIRegion UIRegion;


	public Text money;
	public Text moneyChange;
	public Text reputation;
	public Text reputationChange;

	string initialMoney;
	string initialReputation;
 

	// Use this for initialization
	void Awake()
	{
		initialMoney = money.text;
		initialReputation = reputation.text;
	}

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	 {
 	}
 

	public void NewEvent(string eventDesc)
	{

		EventHistory.text += "" + eventDesc;
	}


	public void RegionSelected(Region region)
	{
		UIRegion.SetRegion(region);
	}

	public void SetMoney(int amount , int change)
	{
		money.text = initialMoney + amount;

		if(change != 0)
		{
			moneyChange.text = change.ToString();
			moneyChange.CrossFadeAlpha(1, 0.0f, false);
			moneyChange.CrossFadeAlpha(0.0f, 1.0f, false);

		}

	}

	public void SetReputation(float amount, float change)
	{
		reputation.text = initialReputation + amount;

		if (change != 0)
		{
			reputationChange.text = change.ToString();
			reputationChange.CrossFadeAlpha(1, 0.0f, false);
			reputationChange.CrossFadeAlpha(0.0f, 1.0f, false);
		}
	}
}
