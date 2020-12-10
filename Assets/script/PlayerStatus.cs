using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] int maxHp = 100; // 最大HP
    [SerializeField] int currentHp; //現在のHP
    [SerializeField] int maxMp = 100; //最大MP
    [SerializeField] int currentMp; // 現在のMP
    [SerializeField] Slider hpSlider; //HPバー
    [SerializeField] Slider mpSlider; //MPバー
    [SerializeField] ItemController[] itemInventory;
    
    void Start()
    {
        hpSlider.value = 1;
        mpSlider.value = 1;
        currentHp = maxHp;
        currentMp = maxMp;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int damage = Random.Range(10, 30);
            Debug.Log("Damage:" + damage);
            currentHp -= damage;
            hpSlider.value = (float)currentHp / (float)maxHp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            ItemController item = other.gameObject.GetComponent<ItemController>();
            item.Get(item);
        }
    }


    public void HpHeal()
    {
        currentHp += 20;
        hpSlider.value = (float)currentHp / (float)maxHp;
    }

    public void MpHeal()
    {
        currentMp += 20;
        mpSlider.value = (float)currentMp / (float)maxMp;
    }
}
