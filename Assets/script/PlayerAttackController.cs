using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] int attackPower = 20; //攻撃力
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        SwitchController sc = SwitchController.FindObjectOfType<SwitchController>();
        TreasureBoxController tb = TreasureBoxController.FindObjectOfType<TreasureBoxController>();
        EnemyController ec = EnemyController.FindObjectOfType<EnemyController>();
       if (other.gameObject.tag == "Switch")
        {
            sc.Clear();
        }
       if (other.gameObject.tag == "TreasureBox" && tb.isOpen == false)
        {
            tb.BoxOpen();
        }
       if (other.gameObject.tag == "Enemy")
        {
            ec.enemycurrentHp -= attackPower;
        }
    }
}
