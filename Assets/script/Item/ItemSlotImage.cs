using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotImage : MonoBehaviour
{
    PlayerStatus ps;
    Image image;
    Text itemCountText;
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStatus>();
        image = GetComponent<Image>();
        itemCountText = GetComponentInChildren<Text>();
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.itemSlot.itemCount != 0 || ps.itemSlot != null)
        {
            //this.gameObject.SetActive(true);
            image.sprite = ps.itemSlot.image;
            itemCountText.text = ps.itemSlot.itemCount.ToString();
        }
        else
        {
            //this.gameObject.SetActive(false);
            image.sprite = null;
            itemCountText.text = "";
        }
    }
}
