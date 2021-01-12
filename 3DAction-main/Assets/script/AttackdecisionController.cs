using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackdecisionController : MonoBehaviour
{
    [SerializeField] Collider attackTrigger = null;//攻撃判定のトリガー
    // Start is called before the first frame update
    void Start()
    {
        attackTrigger.gameObject.SetActive(false);
    }

    /// <summary>
    /// 攻撃判定を有効にする
    /// </summary>
    void BeginAttack()
    {
        if (attackTrigger)
        {
            attackTrigger.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 攻撃判定を無効にする
    /// </summary>
    void EndAttack()
    {
        if (attackTrigger)
        {
            attackTrigger.gameObject.SetActive(false);
        }
    }
}
