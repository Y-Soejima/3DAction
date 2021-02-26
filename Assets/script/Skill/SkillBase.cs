﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBase : MonoBehaviour
{
    [SerializeField] public int skillNumber; //スキルの固有番号
    [SerializeField] public string skillInformation; //スキルの説明
    [SerializeField] public Sprite skillImage;
 
    /// <summary>
    /// スキル一覧
    /// </summary>
    public enum SkillList
    {
        smash,
        DubbleAttack,
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SkillUse()
    {

    }
}
