using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController: MonoBehaviour
{
    Animator door;
    
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        SwitchController sc = SwitchController.FindObjectOfType<SwitchController>();
        if (sc.gimmickTrigger1 == true && door)
        {
            door.Play("Open");
        }
    }
}
