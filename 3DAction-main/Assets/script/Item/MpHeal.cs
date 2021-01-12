using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpHeal : ItemController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use()
    {
        PlayerStatus.FindObjectOfType<PlayerStatus>().MpHeal();
        base.Use();
    }
}
