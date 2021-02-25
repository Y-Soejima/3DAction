using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        SwitchController sc = SwitchController.FindObjectOfType<SwitchController>();
       if (other.gameObject.tag == "Switch")
        {
            sc.Clear();
        }
       TreasureBoxController tb = other.GetComponent<TreasureBoxController>();
       if (other.gameObject.tag == "TreasureBox" && tb.isOpen == false)
        {
            tb.BoxOpen();
        }
    }
}
