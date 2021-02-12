using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smash : SkillBase
{
    [SerializeField] int decrementMp = 15;
    
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
            CharactorControllerRb cc = FindObjectOfType<CharactorControllerRb>();
            cc.anim.SetTrigger("SkillAttack1");
            base.SkillUse();
        }
    }
}
