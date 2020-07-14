using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private float time = 5;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit Obj: " + collision.gameObject.name);
        RTSObj hit1 = collision.gameObject.GetComponent<RTSObj>();
        RTSObj hit = collision.gameObject.GetComponentInParent<RTSObj>();
        if (hit != null)
        {
            hit.GetComponent<HealthManager>().Hit(1, 1);
        } else if (hit1 != null)
        {
            hit.GetComponent<HealthManager>().Hit(1, 1);
        }
        GameObject.Destroy(gameObject);
    }
}
