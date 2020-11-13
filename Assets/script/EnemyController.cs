using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform m_player = null;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
