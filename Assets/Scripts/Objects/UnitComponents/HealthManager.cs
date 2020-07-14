using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int initialHP = -1;
    public int AC = 1;
    [SerializeField]
    public float hp;
    public Image image;

    void Start()
    {
        hp = initialHP;
    }

    public bool Hit(float HP, int AP)
    {
        if(AP > AC)
        {
            damage(HP, AP);
            return true;
        } else
        {
            return false;
        }
    }

    private void damage(float HP, int AP)
    {
        if(HP >= hp)
        {
            Destroy(gameObject);
        } else
        {
            hp -= HP;
            transform.Find("Canvas/Full").GetComponent<Image>().fillAmount = hp / initialHP;
        }
    }

}
