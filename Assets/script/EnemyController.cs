using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Transform m_player = null;
    [SerializeField] int enemyMaxHp = 100;//最大HP
    [SerializeField] public int enemycurrentHp;//現在のHP
    [SerializeField] Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        enemycurrentHp = enemyMaxHp;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            m_player = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_player)
        {
            Vector3 playerPosition = m_player.position;
            playerPosition.y = this.transform.position.y;
            this.transform.LookAt(playerPosition);
        }
        if (enemycurrentHp <= 0)
        {
            Destroy(this.gameObject);
        }
        hpSlider.value = (float)enemycurrentHp / enemyMaxHp;
    }
}
