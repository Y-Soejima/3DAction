using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    Transform m_player = null;
    [SerializeField] int enemyMaxHp = 100;//最大HP
    [SerializeField] public int enemycurrentHp;//現在のHP
    [SerializeField] Slider hpSlider;
    [SerializeField] GameObject damageText;
    [SerializeField] Transform textPos;
    Tween enemyHp;
    // Start is called before the first frame update
    void Start()
    {
        enemycurrentHp = enemyMaxHp;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            m_player = player.transform;
        }
        hpSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemycurrentHp < enemyMaxHp && enemycurrentHp > 0)
        {
            hpSlider.gameObject.SetActive(true);
        }
        if (m_player)
        {
            Vector3 playerPosition = m_player.position;
            playerPosition.y = this.transform.position.y;
            this.transform.LookAt(playerPosition);
        }
        BuildSeq();
        PlaySeq();
    }

    public void TextPop(int damage)
    {
        damageText.GetComponent<TextMesh>().text = damage.ToString();
        Instantiate(damageText, textPos);
    }


    public void BuildSeq()
    {
        enemyHp = DOTween.To(hp =>
        {
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
            hpSlider.value = hp;
        },
                hpSlider.value,
                (float)enemycurrentHp / (float)enemyMaxHp,
                1f);
    }

    public void PlaySeq()
    {
        enemyHp.Play();
    }

    private void OnDestroy()
    {
        enemyHp?.Kill();
    }
}
