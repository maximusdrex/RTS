using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : RTSObj
{
    // Start is called before the first frame update
    public GameObject buildTarget;
    private void Start()
    {
        actions = new IAction[] { new BuildAction(this, buildTarget), new MoveRallyPointAction(this)};
        objName = "Building";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
