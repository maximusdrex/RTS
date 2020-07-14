using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    private ActionBar actBar;
    void Start()
    {
        player = GetComponent<Player>();
        actBar = GetComponentInChildren<ActionBar>();
        //ClickHandler.LeftClick += sl_LeftClick;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(-1) && !ClickHandler.LeftClickSub())
        {
            RaycastHit hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                RTSObj sel = objectHit.GetComponentInParent<RTSObj>();
                if (sel != null)
                {
                    Debug.Log(sel.gameObject.name);
                    if (player.selected != null)
                    {
                        deSelect();
                    }
                    select(sel);
                } else
                {
                    Debug.Log("Not an RTS obj: " + objectHit.name);
                    //Debug.Log(hit.point.ToString());
                    deSelect();
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && !ClickHandler.RightClickSub())
        {
            if (player.selected != null)
            {
                RaycastHit hit;
                Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    RTSObj sel = objectHit.GetComponentInParent<RTSObj>();
                    if (sel != null)
                    {
                        Debug.Log("Right Clicked on Obj");
                        if(sel.team != player.team)
                        {
                            player.selected.GetComponent<WeaponsManager>().setTarget(sel);
                            Debug.Log("Targeting: " + sel.name);
                        }
                    }
                    else if (player.selected is IMovable)
                    {
                        IMovable unit = (IMovable)player.selected;
                        unit.moveTo(hit.point);
                        Debug.Log("Moving to" + hit.point.ToString());
                    }
                }                
            }
        }
    }

    public void sl_LeftClick(object sender, EventArgs e)
    {
        Debug.Log("LeftClick event received");
    }

    private void deSelect()
    {
        //player.selected.GetComponent<Renderer>().material.color = player.selected.player.TeamColor;
        player.selected = null;
        actBar.onSelectionChanged();
    }
    private void select(RTSObj newObj)
    {
        player.selected = newObj;
        //newObj.GetComponent<Renderer>().material.color = Color.red;
        actBar.onSelectionChanged();

    }

    
}
