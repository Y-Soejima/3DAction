using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    [SerializeField] SkillBase sp;
    [SerializeField] SkillPanel skillPanel;
    [SerializeField] int skillPanelnumber;
    PlayerStatus ps;
    Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PlayerStatus>();
        image = GetComponent<Image>();
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
            else if(sp.skillNumber == 1)
            {
                this.gameObject.AddComponent<DubbleAttack>();
                SkillBase skill = this.gameObject.GetComponent<SkillBase>();
                ps.skillPanel[skillPanelnumber] = skill;
            }
            image.sprite = sp.skillImage;
        }
    }
}
