using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpHeal : ItemController
{
    [SerializeField] AudioClip healSound;
    AudioSource healSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        healSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use(ItemController item)
    {
        healSoundSource.PlayOneShot(healSound);
        PlayerStatus.FindObjectOfType<PlayerStatus>().MpHeal();
        base.Use(item);
    }
}
