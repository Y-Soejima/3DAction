using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Transform m_player = null;
    [SerializeField] int bossMaxHp;
    [SerializeField] public int bossCurrentHp;
    [SerializeField] public Slider bossHp;
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject text;
    [SerializeField] Transform pop;
    Vector3 movePotion;
    Animator b_anim;
    Rigidbody rb;
    PlayerStatus ps;
    NavMeshAgent meshAgent;
    CharactorControllerRb cc;
    Tween bossHpTween;
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
        bossHp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCurrentHp < bossMaxHp)
        {
            bossHp.gameObject.SetActive(true);
        }
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
        if (m_player && bossCurrentHp > 0)
        {
            Vector3 playerPosition = m_player.position;
            playerPosition.y = this.transform.position.y;
            this.transform.LookAt(playerPosition);
            if (15 >= distance)
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

    public void DamageTextPop(int damage)
    {
        text.GetComponent<TextMesh>().text = damage.ToString();
        Instantiate(text, pop);
    }

    public void BossSequence()
    {
        bossHpTween = DOTween.To(hp =>
        {
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
            bossHp.value = hp;
        },
                bossHp.value,
                (float)bossCurrentHp / (float)bossMaxHp,
                1f);
    }

    public void BossPlaySeq()
    {
        bossHpTween.Play();
    }

    private void OnDestroy()
    {
        bossHpTween?.Kill();
    }
}
