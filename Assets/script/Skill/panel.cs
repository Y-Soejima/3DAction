using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class panel : MonoBehaviour
{
    [SerializeField] SkillBase sp;
    [SerializeField] SkillPanel skillPanel;
    [SerializeField] int skillPanelnumber;
    PlayerStatus ps;
    
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skillPanel.sb != null)
        {
            sp = skillPanel.sb;
        }
        if (!GetComponent<SkillBase>() && sp != null)
        {
            if (sp.skillNumber == 0)
            {
                this.gameObject.AddComponent<Smash>();
                SkillBase skill = this.gameObject.GetComponent<SkillBase>();
                ps.skillPanel[skillPanelnumber] = skill;
            }
        }
    }
}
