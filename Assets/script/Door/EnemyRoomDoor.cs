﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomDoor : MonoBehaviour
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
        if (EnemyCount.enemys == 0)
        {
            door.Play("Open");
        }
    }

    
}