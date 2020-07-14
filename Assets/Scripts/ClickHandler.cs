using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    public static ClickHandler Instance { get; private set; }

    public static event EventHandler LeftClick;
    public static event EventHandler RightClick;
    public static event EventHandler CancelClick;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(-1))
        {
            if (LeftClick != null)
            {
                LeftClick.Invoke(this, EventArgs.Empty);
            } else
            {
                
            }
        }

        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject(-1))
        {
            if (RightClick != null)
            {
                RightClick.Invoke(this, EventArgs.Empty);
            }
            else
            {

            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CancelClick?.Invoke(this, EventArgs.Empty);
        }
    }

    public static bool LeftClickSub()
    {
        return LeftClick != null;
    }
    public static bool RightClickSub()
    {
        return RightClick != null;
    }

    public void cancelPreviousClick()
    {
        CancelClick?.Invoke(this, EventArgs.Empty);
    }
}
