using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    Transform m_player = null;
    [SerializeField] int bossMaxHp;
    [SerializeField] public int bossCurrentHp;
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed;
    Vector3 movePotion;
    Animator b_anim;
    Rigidbody rb;
    PlayerStatus ps;
    NavMeshAgent meshAgent;
    CharactorControllerRb cc;
    // Start is called before the first frame update
    void Start()
    {
        b_anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        cc = FindObjectOfType<CharactorControllerRb>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            m_player = player.transform;
        }
        ps = FindObjectOfType<PlayerStatus>();
        bossCurrentHp = bossMaxHp;
        meshAgent = GetComponent<NavMeshAgent>();
        movePotion = m_player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCurrentHp <= 0)
        {
            b_anim.Play("Die");
            //Destroy(this.gameObject);
        }
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 5)
        {
            BossAttack();
        }

        if (m_player)
        {
            Vector3 playerPosition = m_player.position;
            playerPosition.y = this.transform.position.y;
            this.transform.LookAt(playerPosition);
            if (15 >= distance && distance >= 4)
            {
                movePotion = m_player.position;
                meshAgent.SetDestination(movePotion);
            }
            b_anim.SetFloat("Speed", meshAgent.velocity.magnitude);
        }
    }

    void BossAttack()
    {
        b_anim.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            ps.currentHp -= 30;
            ps.hpSlider.value = (float)ps.currentHp / (float)ps.maxHp;
        }
    }
}
