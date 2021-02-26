using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour
{
    [SerializeField] GameObject itemWindow;
    [SerializeField] Text information;
    [SerializeField] int itemNumber;
    [SerializeField] ItemController itemInventory;
    [SerializeField] AudioClip submitSound;
    [SerializeField] AudioClip serectSound;
    AudioSource buttonSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        buttonSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        itemInventory = PlayerStatus.FindObjectOfType<PlayerStatus>().itemInventory[itemNumber];
    }

    public void OnSelected()
    {
        buttonSoundSource.PlayOneShot(serectSound);
        information.text = itemInventory.itemInformation;
    }

    public void DeSelected()
    {
        information.text = "";
    }

    public void ItemUse()
    {
        buttonSoundSource.PlayOneShot(submitSound);
        if (itemInventory)
        {
            itemInventory.Use(itemInventory);
            PlayerStatus.FindObjectOfType<PlayerStatus>().itemCounter[itemNumber] = itemInventory.itemCount;
            if (itemInventory.itemCount == 0)
            {
                EventSystem.current.SetSelectedGameObject(itemWindow);
            }
        }
    }
}
