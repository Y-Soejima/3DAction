using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] GameObject iteminventory;
    [SerializeField] int itemNumber;

    /// <summary>
    /// アイテムを使う
    /// </summary>
    public virtual void Use()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// アイテムを拾う
    /// </summary>
    public void Get()
    {
        this.transform.position = iteminventory.transform.position;
    }
}
