using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageTextController : MonoBehaviour
{
    //SpriteRenderer sprite;
    TextMesh damageText;
    Tween tween;
    Sequence seq;
    // Start is called before the first frame update
    void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        damageText = GetComponent<TextMesh>();
        seq = DOTween.Sequence();
        BuildSequence();
        PlaySequence();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
        
    }

    void BuildSequence()
    {
        tween = DOTween.ToAlpha(() => damageText.color,
            alpha => damageText.color = alpha,
            0f,
            0.9f);
        seq.Append(this.transform.DOMove(new Vector3(0, 0.2f, 0), 1).SetRelative())
            .AppendInterval(2)
            .OnComplete(() => Destroy(this.gameObject));
    }

    void PlaySequence()
    {
        seq.Play();
        tween.Play();
    }

    void OnDestroy()
    {
        tween?.Kill();
        seq?.Kill();
    }
     
}
