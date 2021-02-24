using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusController : MonoBehaviour
{
    [SerializeField] ParticleSystem locus;

    // Start is called before the first frame update
    void Start()
    {
        locus.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void BeginLocus()
    {
        locus.gameObject.SetActive(true);
    }

    void EndLocus()
    {
        locus.gameObject.SetActive(false);
    }
}
