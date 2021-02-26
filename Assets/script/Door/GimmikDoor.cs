using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmikDoor : MonoBehaviour
{
    SwitchController sc;
    Animator door;
    // Start is called before the first frame update
    void Start()
    {
        sc = FindObjectOfType<SwitchController>();
        door = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sc.gimmickTrigger1 == true)
        {
            Open();
        }
    }

    void Open()
    {
        door.Play("Open");
    }
}
