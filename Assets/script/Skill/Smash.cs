using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : SkillBase
{

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
        CharactorControllerRb cc = CharactorControllerRb.FindObjectOfType<CharactorControllerRb>();
        cc.anim.SetTrigger("SkillAttack1");
        base.SkillUse();
    }
}
