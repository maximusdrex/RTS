using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    private Player player;
    private Unit unit;
    [SerializeField]
    private RTSObj target;
    public Weapon[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        weapons = new Weapon[] { new Weapon(1, 1, 1, 100, unit)};
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            
            foreach(Weapon weapon in weapons)
            {
                if (weapon.coolTime <= 0 && Vector3.Distance(transform.position, target.transform.position) < weapon.range)
                {
                    Debug.Log("Weapon firing");
                    weapon.Fire(target);
                }
            }
        }
        foreach (Weapon weapon in weapons)
        {
            if(weapon.coolTime > 0)
            {
                weapon.coolTime -= Time.deltaTime;
            } else if(weapon.coolTime < 0)
            {
                weapon.coolTime = 0;
            }
        }
    }

    public bool setTarget(RTSObj enemy)
    {
        target = enemy;
        return true;
    }
}
