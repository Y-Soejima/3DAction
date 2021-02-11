using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubbleAttack : SkillBase
{
    [SerializeField] int decrementMp = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SkillUse()
    {
        PlayerStatus ps = FindObjectOfType<PlayerStatus>();
        if (ps.currentMp >= decrementMp)
        {
            ps.currentMp -= decrementMp;
            ps.mpSlider.value = (float)ps.currentMp / (float)ps.maxMp;
            CharactorControllerRb cc = CharactorControllerRb.FindObjectOfType<CharactorControllerRb>();
            cc.anim.SetTrigger("SkillAttack2");
            base.SkillUse();
        }
    }
}
