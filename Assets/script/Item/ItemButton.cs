using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] Text information;
    [SerializeField] ItemController item;
    [SerializeField] int itemNumber;
    ItemController itemInventory;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<ItemController>();
        itemInventory = PlayerStatus.FindObjectOfType<PlayerStatus>().itemInventory[itemNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelected()
    {
        information.text = item.itemInformation;
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
