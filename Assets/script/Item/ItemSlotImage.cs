using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotImage : MonoBehaviour
{
    [SerializeField] Image itemImage;
    PlayerStatus ps;
    Text itemCountText;
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStatus>();
        //itemImage = GetComponentInChildren<Image>();
        itemCountText = GetComponentInChildren<Text>();
        itemImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.itemSlot != null)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = ps.itemSlot.image;
            itemCountText.text = ps.itemSlot.itemCount.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            itemImage.sprite = null;
            itemCountText.text = "";
        }
    }
}
