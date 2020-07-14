using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRallyPointAction : IAction
{
    private Building parentBuilding;

    public MoveRallyPointAction(Building parent)
    {
        parentBuilding = parent;
    }

    public string getName()
    {
        return ("Move Rally");
    }

    public void runAction()
    {
        ClickHandler.LeftClick += mr_LeftClick;
        ClickHandler.CancelClick += mr_LeftClick;
    }

    public void mr_LeftClick(object sender, EventArgs e)
    {
        Transform rally = parentBuilding.transform.Find("RallyPoint");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50f))
        {
            rally.position = hit.point;
        }
        ClickHandler.LeftClick -= mr_LeftClick;
        ClickHandler.CancelClick -= mr_CancelClick;
    }

    public void mr_CancelClick(object sender, EventArgs e)
    {
        ClickHandler.LeftClick -= mr_LeftClick;
        ClickHandler.CancelClick -= mr_CancelClick;
    }

}
