using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] int bossMaxHp;
    [SerializeField] int bossCurrentHp;
    Animator b_anim;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        b_anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCurrentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void LateUpdate()
    {
        // 水平方向の速度を求めて Animator Controller のパラメーターに渡す
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        b_anim.SetFloat("Speed", horizontalVelocity.magnitude);
    }

    void BossAttack()
    {
        b_anim.SetTrigger("Attack");
    }
}
