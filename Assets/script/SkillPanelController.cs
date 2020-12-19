using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelController : MonoBehaviour
{
    Animator skillAnim;
    // Start is called before the first frame update
    void Start()
    {
        skillAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Skill"))
        {
            skillAnim.SetBool("IsSkillReady",true);
        }
        else
        {
            skillAnim.SetBool("IsSkillReady", false);
        }
    }
}
