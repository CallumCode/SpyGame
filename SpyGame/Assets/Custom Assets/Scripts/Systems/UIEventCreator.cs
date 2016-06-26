using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UIEventCreator : MonoBehaviour
{
    public InputField TurnInput;
    public Dropdown NPCDropDown;
    public Dropdown NPCTargetDropDown;
    public Dropdown ActionDropDown;
    public Dropdown RegionDropDown;

    public ActionManager ActionManager;
    public NPCManager NPCManager;
    public RegionManager RegionManager;
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void PopulateActions()
    {
        ActionDropDown.ClearOptions();

        ArrayList actions =  ActionManager.GetAllActons();

        List<string> options = new List<string>();

        foreach (Action action in actions)
        {
            options.Add(action.GetName());
        }

        ActionDropDown.AddOptions(options);
    }

    void PopulateNPCs()
    {
        

        NPCDropDown.ClearOptions();
        NPCTargetDropDown.ClearOptions();

        ArrayList npcs = NPCManager.GetAllNPCs();

        List<string> options = new List<string>();

        foreach (NPC npc in npcs)
        {
            options.Add(npc.GetName());
        }

        NPCTargetDropDown.AddOptions(options);
        NPCDropDown.AddOptions(options);
    }

    void  PopulateRegions()
    {
        RegionDropDown.ClearOptions();

        ArrayList regions = RegionManager.GetAllRegions();

        List<string> options = new List<string>();
        
        foreach(Region region in regions)
        {
            options.Add(region.GetName());
        }

        RegionDropDown.AddOptions(options);
    }

    void PopulateDropdowns()
    {
        PopulateActions();
        PopulateNPCs();
        PopulateRegions();
    }

    public void Toggle()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            PopulateDropdowns();
        }
    }
}
