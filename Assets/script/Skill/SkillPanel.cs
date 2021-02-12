using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    [SerializeField] GameObject skillMane;
    [SerializeField] GameObject skillPanel;
    //[SerializeField] int skillPanelNumber;
    public SkillBase sb;
    PlayerStatus ps;
    SkillManeController smc;
    SkillListController slc;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        ps = PlayerStatus.FindObjectOfType<PlayerStatus>();
        smc = SkillManeController.FindObjectOfType<SkillManeController>();
        slc = SkillListController.FindObjectOfType<SkillListController>();
        image = this.GetComponent<Image>();
    }

    public void OnClick()
    {
        if (skillPanel.GetComponent<SkillBase>())
        {
            Destroy(skillPanel.GetComponent<SkillBase>());
        }
        for(int i = 0; i < ps.skill.Length; i++)
        {
            if (i == smc.selectSkillNumber)
            {
                sb = ps.skill[i];
                image.sprite = sb.skillImage;
            }
        }
        foreach (var button in slc.maneButton)
        {
            button.interactable = true;
        }
        foreach (var button in slc.skillButton)
        {
            button.interactable = true;
        }
        EventSystem.current.SetSelectedGameObject(skillMane);
        foreach (var button in slc.skillPanelButton)
        {
            button.interactable = false;
        }
    }
}
