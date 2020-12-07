using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHeal : ItemController
{
    public void Heal()
    {
        CharactorControllerRb.FindObjectOfType<CharactorControllerRb>().HpHeal();
        base.Use();
    }
}
