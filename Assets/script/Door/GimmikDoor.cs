using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmikDoor : DoorControllerBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchController sc = SwitchController.FindObjectOfType<SwitchController>();
        if (sc.gimmickTrigger1 == true)
        {
            base.Open();
        }
    }
}
