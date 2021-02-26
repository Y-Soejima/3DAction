using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoxController : MonoBehaviour
{
    //アイテムを格納する
    [SerializeField] GameObject[] treasure;
    //アイテムを出現させる場所
    [SerializeField] Transform itemPop;
    public bool isOpen = false;
    //public GameObject popItem;
    Animator open;
    [SerializeField] public GameObject text;
    

    private void Start()
    {
        open = GetComponentInChildren<Animator>();
        text.SetActive(false);
        
    }

    private void Update()
    {
        text.transform.forward = Camera.main.transform.forward;
    }
    
    /// <summary>
    /// 宝箱を開けたときランダムにアイテムを出現させる
    /// </summary>
    public void BoxOpen()
    {
        if (itemPop)
        {
            open.Play("BoxOpen");
            Instantiate(treasure[RandomPop(treasure)], itemPop);
            isOpen = true;
        }
    }

    /// <summary>
    /// 配列に格納したアイテムのインデックス番号をランダムに返す
    /// </summary>
    /// <param name="Item">アイテムを格納した配列</param>
    /// <returns>配列内のインデックス番号</returns>
    int RandomPop(GameObject[] item)
    {
        return Random.Range(0, item.Length);
    }

    
}
