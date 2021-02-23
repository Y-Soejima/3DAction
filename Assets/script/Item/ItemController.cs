﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] Vector3 iteminventory = new Vector3(-8, -7, 24);
    [SerializeField] public int itemNumber; //アイテムの固有番号
    [SerializeField] public int itemCount = 0;　//アイテム所持数
    [SerializeField] public string itemInformation; //アイテムの説明

    /// <summary>
    /// アイテム一覧
    /// </summary>
    public enum ItemList
    {
        hpHeal,
        mpHeal,
    };
    /// <summary>
    /// アイテムを使う
    /// </summary>
    public virtual void Use()
    {
        itemCount--;
        if (itemCount == 0)
        {
            DestroyImmediate(this.gameObject);
        }
    }

    /// <summary>
    /// アイテムを拾う
    /// </summary>
    public void Get(ItemController item)
    {
        var number = System.Enum.GetNames(typeof(ItemController.ItemList)).Length;
        for (int i = 0; i < number; i++)
        {
            if (item.itemNumber == i)
            {
                this.transform.position = iteminventory;
                itemCount++;
            }
        }
    }
}
