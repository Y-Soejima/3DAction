using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeachDoor : MonoBehaviour
{
    Animator door;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            door.SetBool("isPlayer", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        door.SetBool("isPlayer", false);
    }
}
