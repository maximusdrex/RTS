using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public readonly float tps;
    public readonly float HP;
    public readonly int AP;
    public readonly float range;
    private float force = 100;
    private Unit unit;
    public float coolTime;
    public Weapon(float damage, int armorPen, float cooldown, float r, Unit parent)
    {
        HP = damage;
        AP = armorPen;
        tps = cooldown;
        range = r;
        unit = parent;
    }

    public void Fire(RTSObj target)
    {
        coolTime = tps;

        GameObject shell = GameObject.Instantiate(Resources.Load<GameObject>("Shell"));
        Transform cannon = unit.transform.Find("Tank/Turret_Container/FirePos");
        Vector3 newpos = cannon.position;
        shell.transform.position = newpos;
        shell.transform.LookAt(target.transform);
        Vector3 direction = target.transform.position - shell.transform.position;
        direction = direction.normalized * force;
        shell.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
    }
}
