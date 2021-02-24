using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotImage : MonoBehaviour
{
    PlayerStatus ps;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStatus>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.itemSlot != null)
        {
            image.sprite = ps.itemSlot.image;
        }
    }
}
