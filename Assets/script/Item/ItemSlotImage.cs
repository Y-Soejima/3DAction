using System.Collections;
using System.Collections.Generic;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.itemSlot != null)
        {
            image.sprite = ps.itemSlot.image;
            itemCountText.text = ps.itemSlot.itemCount.ToString();
        }
        else
        {
            image.sprite = null;
            itemCountText.text = "";
        }
    }
}
