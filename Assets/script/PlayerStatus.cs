using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStatus : MonoBehaviour
{
    [SerializeField] int maxHp = 100; // 最大HP
    [SerializeField] int currentHp; //現在のHP
    [SerializeField] public int maxMp = 100; //最大MP
    [SerializeField] public int currentMp; // 現在のMP
    [SerializeField] Slider hpSlider; //HPバー
    [SerializeField] public Slider mpSlider; //MPバー
    [SerializeField] int attackPower = 20; //攻撃力
    //アイテムの種類
    [SerializeField] public ItemController[] itemInventory = new ItemController[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    //各アイテムの所持数
    [SerializeField] public int[] itemCounter = new int[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    [SerializeField] public Text[] itemCounterText = new Text[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    //スキルの種類
    [SerializeField] public SkillBase[] skill = new SkillBase[System.Enum.GetValues(typeof(SkillBase.SkillList)).Length];
    //スキルパネルにセットするスキル
    public SkillBase[] skillPanel = new SkillBase[4];
    public AnimatorClipInfo[] animatorClipInfos;
    CharactorControllerRb cc;
    void Start()
    {
        hpSlider.value = 1;
        mpSlider.value = 1;
        currentHp = maxHp;
        currentMp = maxMp;
        cc = FindObjectOfType<CharactorControllerRb>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemCounterText.Length; i++)
        {
            if (itemInventory[i])
            {
                itemCounterText[i].text = itemCounter[i].ToString();
            }
            else
            {
                itemCounterText[i].text = "0";
            }
        }
        animatorClipInfos = cc.anim.GetCurrentAnimatorClipInfo(0);
        Debug.Log(animatorClipInfos[0].clip.name);
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
        else if (other.gameObject.tag == "Enemy")
        {
            EnemyController ec = EnemyController.FindObjectOfType<EnemyController>();
            if (animatorClipInfos[0].clip.name == "SkillAttack1")
            {
                ec.enemycurrentHp -= attackPower * 2;
            }
            else if (animatorClipInfos[0].clip.name == "DubbleAttack")
            {
                ec.enemycurrentHp -= attackPower + attackPower / 2;
            }
            else
            {
                ec.enemycurrentHp -= attackPower;
            }
            Debug.Log(ec.enemycurrentHp);
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
        if (currentMp > maxMp)
        {
            currentMp = maxMp;
        }
        mpSlider.value = (float)currentMp / (float)maxMp;
    }
}
