using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    [SerializeField] AudioClip doorOpen;
    AudioSource doorSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        doorSoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoorOpen()
    {
        if (doorSoundSource)
        {
            doorSoundSource.PlayOneShot(doorOpen);
        }
    }
}
