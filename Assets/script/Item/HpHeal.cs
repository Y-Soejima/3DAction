using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeal : ItemController
{
    public override void Use()
    {
        PlayerStatus.FindObjectOfType<PlayerStatus>().HpHeal();
        base.Use();
    }
}
