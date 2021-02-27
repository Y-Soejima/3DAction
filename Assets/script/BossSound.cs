using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{
    [SerializeField] AudioClip bossAttack;
    AudioSource bossSound;
    // Start is called before the first frame update
    void Start()
    {
        bossSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BossAttack()
    {
        bossSound.PlayOneShot(bossAttack);
    }
}
