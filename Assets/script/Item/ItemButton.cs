﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] Text information;
    [SerializeField] int itemNumber;
    [SerializeField] ItemController itemInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemInventory = PlayerStatus.FindObjectOfType<PlayerStatus>().itemInventory[itemNumber];
    }

    public void OnSelected()
    {
        information.text = itemInventory.itemInformation;
    }

    public void DeSelected()
    {
        information.text = "";
    }

    public void ItemUse()
    {
        if (itemInventory)
        {
            itemInventory.Use();
            PlayerStatus.FindObjectOfType<PlayerStatus>().itemCounter[itemNumber] = itemInventory.itemCount;
        }
    }
}
