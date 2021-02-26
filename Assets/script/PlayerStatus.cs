using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStatus : MonoBehaviour
{
    [SerializeField] public int maxHp = 100; // 最大HP
    [SerializeField] public int currentHp; //現在のHP
    [SerializeField] public int maxMp = 100; //最大MP
    [SerializeField] public int currentMp; // 現在のMP
    [SerializeField] public Slider hpSlider; //HPバー
    [SerializeField] public Slider mpSlider; //MPバー
    [SerializeField] int attackPower = 20; //攻撃力
    int damage; // ダメージ
    //アイテムの種類
    [SerializeField] public ItemController[] itemInventory = new ItemController[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    //各アイテムの所持数
    [SerializeField] public int[] itemCounter = new int[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    [SerializeField] public Text[] itemCounterText = new Text[System.Enum.GetValues(typeof(ItemController.ItemList)).Length];
    [SerializeField] public ItemController itemSlot;
    //スキルの種類
    [SerializeField] public SkillBase[] skill = new SkillBase[System.Enum.GetValues(typeof(SkillBase.SkillList)).Length];
    //スキルパネルにセットするスキル
    public SkillBase[] skillPanel = new SkillBase[4];
    public AnimatorClipInfo[] animatorClipInfos;
    [SerializeField] GameObject[] enemys;
    CharactorControllerRb cc;
    public Tween heal;
    void Start()
    {
        hpSlider.value = 1;
        mpSlider.value = 1;
        currentHp = maxHp;
        currentMp = maxMp;
        cc = FindObjectOfType<CharactorControllerRb>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
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
        //if (enemys != null)
        //{
        //    enemys[0] = enemys.OrderBy(enemy => Vector3.Distance(this.gameObject.transform.position, enemy.transform.position)).FirstOrDefault();
        //    Debug.Log(enemys[0]);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int damage = Random.Range(10, 30);
            Debug.Log("Damage:" + damage);
            currentHp -= damage;
            DOTween.To(hp => hpSlider.value = hp,
                hpSlider.value,
                (float)currentHp / (float)maxHp,
                1f);
            //hpSlider.value = (float)currentHp / (float)maxHp;
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
            if (itemSlot == null)
            {
                itemSlot = item;
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            EnemyController ec = EnemyController.FindObjectOfType<EnemyController>();
            if (animatorClipInfos[0].clip.name == "SkillAttack1")
            {
                damage = attackPower * 2;
                
            }
            else if (animatorClipInfos[0].clip.name == "DubbleAttack")
            {
                damage = attackPower + attackPower / 2;
                
            }
            else if (animatorClipInfos[0].clip.name == "Attack")
            {
                damage = attackPower;
                currentMp += 10;
                if (currentMp > maxMp)
                {
                    currentMp = maxMp;
                }
                mpSlider.value = (float)currentMp / (float)maxMp;
                
            }
            ec.enemycurrentHp -= damage;
            ec.BuildSeq();
            ec.PlaySeq();
            ec.TextPop(damage);
            Debug.Log("Damage:" + damage);
        }
        else if (other.gameObject.tag == ("Boss"))
        {
            Boss boss = FindObjectOfType<Boss>();
            if (animatorClipInfos[0].clip.name == "SkillAttack1")
            {
                damage = attackPower * 2;
            }
            else if (animatorClipInfos[0].clip.name == "DubbleAttack")
            {
                damage = attackPower + attackPower / 2;
            }
            else
            {
                damage = attackPower;
                currentMp += 10;
                if (currentMp > maxMp)
                {
                    currentMp = maxMp;
                }
                mpSlider.value = (float)currentMp / (float)maxMp;
            }
            boss.bossCurrentHp -= damage;
            boss.BossSequence();
            boss.BossPlaySeq();
            boss.DamageTextPop(damage);
        }
    }

    public void HpHeal()
    {
        currentHp += 50;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpSlider.value = (float)currentHp / (float)maxHp;
    }

    public void MpHeal()
    {
        currentMp += 50;
        if (currentMp > maxMp)
        {
            currentMp = maxMp;
        }
        mpSlider.value = (float)currentMp / (float)maxMp;
    }

    //public void ItemGet(GameObject item)
    //{
    //    ItemController ic = item.GetComponent<ItemController>();
    //    ic.Get(ic);
    //    if (itemInventory[ic.itemNumber] == null)
    //    {
    //        itemInventory[ic.itemNumber] = ic;
    //    }
    //    itemCounter[ic.itemNumber] = ic.itemCount;
    //    if (itemSlot == null)
    //    {
    //        itemSlot = ic;
    //    }
    //}
}
