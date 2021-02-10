using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    [SerializeField] public int skillNumber; //スキルの固有番号
    [SerializeField] string skillInformation; //スキルの説明
 
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
