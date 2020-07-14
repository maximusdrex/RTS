using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private float SPEED = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left shift"))
        {
            SPEED = 40;
        } else
        {
            SPEED = 20;
        }
        if (Input.GetKey("w"))
        {
            transform.position += SPEED * Time.deltaTime * new Vector3(0,0,1);
        } if (Input.GetKey("a"))
        {
            transform.position += SPEED * Time.deltaTime * new Vector3(-1, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.position += SPEED * Time.deltaTime * new Vector3(0, 0, -1);
        }
        if (Input.GetKey("d"))
        {
            transform.position += SPEED * Time.deltaTime * new Vector3(1, 0, 0);
        }
        if (Input.GetKey("q"))
        {
            transform.position += SPEED * .7f * Time.deltaTime * new Vector3(0, -1, 0);
        }
        if (Input.GetKey("e"))
        {
            transform.position += SPEED * .7f * Time.deltaTime * new Vector3(0, 1, 0);
        }
    }
}
