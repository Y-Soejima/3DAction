using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        SwitchController sc = SwitchController.FindObjectOfType<SwitchController>();
       if (other.gameObject.tag == "Switch")
        {
            sc.Clear();
        }

        TreasureBoxController tb = TreasureBoxController.FindObjectOfType<TreasureBoxController>();
        if (other.gameObject.tag == "TreasureBox" && tb.isOpen == false)
        {
            tb.BoxOpen();
        }
    }
}
