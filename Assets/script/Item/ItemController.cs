using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] Vector3 iteminventory = new Vector3(0, 0, 0);
    [SerializeField] public int itemNumber; //アイテムの固有番号
    [SerializeField] public int itemCount = 0;　//アイテム所持数
    [SerializeField] public string itemInformation; //アイテムの説明
    [SerializeField] public Sprite image;
    [SerializeField] public bool get = false;
    /// <summary>
    /// アイテム一覧
    /// </summary>
    public enum ItemList
    {
        hpHeal,
        mpHeal,
    };

    private void Start()
    {
        //panel.gameObject.SetActive(false);
    }
    /// <summary>
    /// アイテムを使う
    /// </summary>
    public virtual void Use(ItemController item)
    {
        var number = System.Enum.GetNames(typeof(ItemController.ItemList)).Length;
        for (int i = 0; i < number; i++)
        {
            if (item.itemNumber == i)
            {
                itemCount--;
            }
            if (item.itemCount == 0)
            {
                DestroyImmediate(item.gameObject);
            }
        }
    }

    /// <summary>
    /// アイテムを拾う
    /// </summary>
    public void Get(ItemController item)
    {
        if (item.get == false)
        {
            item.get = true;
            //panel.gameObject.SetActive(true);
        }
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
