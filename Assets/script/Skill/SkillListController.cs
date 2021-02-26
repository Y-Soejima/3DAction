using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillListController : MonoBehaviour
{
    [SerializeField] public Button[] maneButton = new Button[2];
    [SerializeField] public Button[] skillButton = new Button[1];
    [SerializeField] public Button[] skillPanelButton = new Button[4];
    [SerializeField] GameObject skillPanel0;
    [SerializeField] Text information;
    [SerializeField] SkillBase skill;
    SkillManeController smc;
    PlayerStatus ps;
    public int skillNum;
    [SerializeField] AudioClip selectSound;
    [SerializeField] AudioClip submitSound;
    AudioSource buttonSoundSource;
    public void Start()
    {
        buttonSoundSource = GetComponent<AudioSource>();
        ps = FindObjectOfType<PlayerStatus>();
        smc = SkillManeController.FindObjectOfType<SkillManeController>();
        foreach (var button in skillPanelButton)
        {
            button.interactable = false;
        }
        skill = ps.skill[skillNum];
    }
    public void OnClick()
    {
        buttonSoundSource.PlayOneShot(submitSound);
        smc.SetSkillNumber(skillNum);
        foreach (var button in skillPanelButton)
        {
            button.interactable = true;
        }
        EventSystem.current.SetSelectedGameObject(skillPanel0);

        foreach (var button in maneButton)
        {
            button.interactable = false;
        }
        foreach(var button in skillButton)
        {
            button.interactable = false;
        }
    }

    public void OnSelect()
    {
        buttonSoundSource.PlayOneShot(selectSound);
        information.text = skill.skillInformation;
    }

    public void OnDeserect()
    {
        information.text = "";
    }
}
