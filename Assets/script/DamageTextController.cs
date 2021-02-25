using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageTextController : MonoBehaviour
{
    SpriteRenderer sprite;
    TextMesh damageText;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        damageText = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
        Sequence seq = DOTween.Sequence();
        DOTween.ToAlpha(() => damageText.color,
            alpha => damageText.color = alpha,
            0f,
            1f);
        seq.Append(this.transform.DOMove(new Vector3(0, 0.2f, 0), 1)).SetRelative()
            .OnComplete(() => Destroy(this.gameObject));
    }
}
