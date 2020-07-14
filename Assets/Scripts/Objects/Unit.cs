using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WeaponsManager))]
[RequireComponent(typeof(NavMeshAgent))]

public class Unit : RTSObj, IMovable
{
    // Start is called before the first frame update
    private NavMeshAgent navAgent;
    private WeaponsManager weapons;

    void Start()
    {
        weapons = GetComponent<WeaponsManager>();
        //player = Camera.main.GetComponent<Player>();
        Debug.Log("Player " + player.pname);
        navAgent = GetComponent<NavMeshAgent>();
        objName = "Unit";
        //GetComponent<Renderer>().material.color = player.TeamColor;
        IAction[] unitActions = new IAction[weapons.weapons.Length];
        for(int i = 0; i < weapons.weapons.Length; i++)
        {
            unitActions[i] = new AttackAction(weapons.weapons[i]);
        }
        actions = unitActions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveTo(Vector3 pos)
    {
        navAgent.SetDestination(pos);
    }
}
