using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
	public UIManager UIManager;
	public RegionManager RegionManager;
	int turn =0;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public int GetTurn()
	{
		return turn;
	}

	public void NextTurn()
	{
		turn++;

		UIManager.SetTurn(turn);
		RegionManager.CreateEventInEachRegion();
	}
}
