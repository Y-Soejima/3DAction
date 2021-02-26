using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSound : MonoBehaviour
{
    AudioSource attackSound1;
    
    [SerializeField] AudioClip sound1;
    [SerializeField] AudioClip sound2;
    // Start is called before the first frame update
    void Start()
    {
        attackSound1 = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sound1()
    {
        attackSound1.PlayOneShot(sound1);
    }

    void Sound2()
    {
        attackSound1.PlayOneShot(sound2);
    }
}
