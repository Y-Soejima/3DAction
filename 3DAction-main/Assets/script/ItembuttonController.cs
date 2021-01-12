using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItembuttonController : MonoBehaviour
{
    [SerializeField] Button[] itemButton;
    PlayerStatus ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = PlayerStatus.FindObjectOfType<PlayerStatus>();
        foreach (var button in itemButton)
        {
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemButton.Length; i++)
        {
            if (ps.itemCounter[i] == 0)
            {
                itemButton[i].interactable = false;
            }
            else
            {
                itemButton[i].interactable = true;
            }
        }
    }
}
