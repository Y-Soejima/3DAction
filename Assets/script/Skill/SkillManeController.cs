using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManeController : MonoBehaviour
{
    
    public int selectSkillNumber = -1;
    
    public void SetSkillNumber(int selectNumber)
    {
        selectSkillNumber = selectNumber;
    }

    public int SetSkill()
    {
        return selectSkillNumber;
    }
}
