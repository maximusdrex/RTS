using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConstructAction : IAction
{
    private Player player;
    public ConstructAction(Player p)
    {
        player = p;
    }
    public string getName()
    {
        return "Construct Building";
    }

    public void runAction()
    {
        ClickHandler.Instance.cancelPreviousClick();
        ClickHandler.LeftClick += ca_onLeftClick;
        ClickHandler.CancelClick += ca_onCancelClick;
    }

    public void ca_onLeftClick(object sender, EventArgs e)
    {
        GameObject Building = (GameObject)Resources.Load("Building");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Building.transform.position = hit.point;
            Building = GameObject.Instantiate(Building);
            Building.GetComponent<Building>().player = player;
        }
        ClickHandler.LeftClick -= ca_onLeftClick;
        ClickHandler.CancelClick -= ca_onCancelClick;

    }

    public void ca_onCancelClick(object sender, EventArgs e)
    {
        ClickHandler.LeftClick -= ca_onLeftClick;
        ClickHandler.CancelClick -= ca_onCancelClick;
    }
}
