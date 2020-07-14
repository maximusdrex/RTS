using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class RTSObj : MonoBehaviour
{

    public HealthManager health;
    public Player player;
    public int team;
    public IAction[] actions;
    public string objName = "RTSObj";
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthManager>();
        team = player.team;
        player = Camera.main.GetComponent<Player>();
        Debug.Log("Player " + player.name);
    }

    void onSelect()
    {
        
    }

    void onDeselect()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
