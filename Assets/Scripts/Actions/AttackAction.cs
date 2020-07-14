using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : IAction
{
    private Weapon weapon;
    public AttackAction(Weapon wep)
    {
        weapon = wep;
    }
    public string getName()
    {
        return "Fire Weapon";
    }

    public void runAction()
    {
        ClickHandler.Instance.cancelPreviousClick();
        ClickHandler.RightClick += aa_onRightClick;
        ClickHandler.CancelClick += aa_onCancelClick;
    }

    public void aa_onRightClick(object sender, EventArgs e)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            RTSObj sel = objectHit.GetComponentInParent<RTSObj>();
            if(sel != null)
            {
                weapon.Fire(sel);
            }
        }
    }

    public void aa_onCancelClick(object sender, EventArgs e)
    {
        ClickHandler.RightClick -= aa_onRightClick;
        ClickHandler.CancelClick -= aa_onRightClick;
    }
}
