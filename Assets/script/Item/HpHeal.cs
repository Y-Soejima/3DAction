using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HpHeal : ItemController
{
    PlayerStatus ps;
    [SerializeField] AudioClip healSound;
    AudioSource healSoundSource;
    public void Start()
    {
        ps = PlayerStatus.FindObjectOfType<PlayerStatus>();
        healSoundSource = GetComponent<AudioSource>();
    }
    public override void Use(ItemController item)
    {
        healSoundSource.PlayOneShot(healSound);
        ps.HpHeal();
        base.Use(item);
    }

    
}
