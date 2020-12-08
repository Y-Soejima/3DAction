using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerBase: MonoBehaviour
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

        
    }

    public void Open()
    {
        if (door)
        door.Play("Open");
    }
}
