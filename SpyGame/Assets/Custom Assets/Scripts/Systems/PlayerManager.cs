using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public UIManager UIManager;

	float maxMoneyGain = 100;
	float maxReputationChange = 100;

	float money = 1000;
	float reputation = 100;

	// Use this for initialization
	void Start()
	{
		UpdateUI(money, reputation);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SellHasBeenMade(int correct, int wrong)
	{
		float fraction = 0;
		if (correct > 0) fraction = 1;


		if (wrong > 0)
		{
			fraction = (float)correct / (float) (correct + wrong);
		}
		
		float moneyChange = maxMoneyGain * fraction;
		money += moneyChange;
		float reputationChange = (fraction - 0.5f) * maxReputationChange * 2;
		reputation += reputationChange;
		Debug.Log("fraction " + fraction +  " Correct "  + correct + "Wrong " + wrong + " moneyChange " + moneyChange + " reputationChange " + reputationChange);

		UpdateUI(moneyChange , reputationChange);

	}


	void UpdateUI(float moneyChange, float repChange )
	{
		UIManager.SetMoney((int)money , (int) moneyChange);
		UIManager.SetReputation(reputation , repChange);
	}
}
