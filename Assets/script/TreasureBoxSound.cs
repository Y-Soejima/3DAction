using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBoxSound : MonoBehaviour
{
    [SerializeField] AudioClip openSound;
    AudioSource openSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        openSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenSound()
    {
        openSoundSource.PlayOneShot(openSound);
    }
}
