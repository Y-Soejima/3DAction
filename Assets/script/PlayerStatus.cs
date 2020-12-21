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
    //アイテムの種類
    [SerializeField] public ItemController[] itemInventory = new ItemController[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    //各アイテムの所持数
    [SerializeField] public int[] itemCounter = new int[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    [SerializeField] public Text[] itemCounterText = new Text[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    //スキルの種類
    [SerializeField] public SkillBase[] skill = new SkillBase[System.Enum.GetValues(typeof(SkillBase.SkillList)).Length];
    //スキルパネルにセットされるスキル
    public SkillBase[] skillPanel = new SkillBase[4];
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
        itemCounterText[0].text = itemCounter[0].ToString();
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
            if (itemInventory[item.itemNumber] == null)
            {
                itemInventory[item.itemNumber] = item;
            }
            itemCounter[item.itemNumber] = item.itemCount;
        }
    }

    public void HpHeal()
    {
        currentHp += 20;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpSlider.value = (float)currentHp / (float)maxHp;
    }

    public void MpHeal()
    {
        currentMp += 20;
        mpSlider.value = (float)currentMp / (float)maxMp;
    }
}
