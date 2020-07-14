using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAction : IAction
{
    private Building parentBuilding;
    private GameObject buildTarget;
    public BuildAction(Building parent, GameObject target)
    {
        parentBuilding = parent;
        buildTarget = target;
    }
    public string getName()
    {
        return ("Build " + buildTarget.name);
    }

    public void runAction() 
    {
        Debug.Log("Building Unit");
        GameObject newUnit = GameObject.Instantiate(buildTarget);
        newUnit.transform.position = parentBuilding.transform.Find("SpawnPoint").position;
        newUnit.GetComponent<Unit>().player = parentBuilding.player;
        //newUnit.GetComponent<Unit>().moveTo(parentBuilding.transform.Find("RallyPoint").position);
    }
}
