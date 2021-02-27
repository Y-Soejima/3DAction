using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusController : MonoBehaviour
{
    [SerializeField] ParticleSystem Locus;
    // Start is called before the first frame update
    void Start()
    {
        Locus.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void BeginBrueLocus()
    {
        Locus.gameObject.SetActive(true);
    }

    void EndBrueLocus()
    {
        Locus.gameObject.SetActive(false);
    }


}
