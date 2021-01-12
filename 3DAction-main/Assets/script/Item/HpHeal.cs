using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeal : ItemController
{
    PlayerStatus ps;
    public void Start()
    {
        ps = PlayerStatus.FindObjectOfType<PlayerStatus>();
    }
    public override void Use()
    {
        ps.HpHeal();
        base.Use();
    }
}
