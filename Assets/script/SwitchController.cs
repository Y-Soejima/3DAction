using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] Material[] material;
    [SerializeField] public GameObject openText;
    MeshRenderer meshRenderer;
    public bool gimmickTrigger1 = false;//ギミックが解かれたのか判定する
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer= GetComponent<MeshRenderer>();
        openText.SetActive(false);
    }

    private void Update()
    {
        openText.transform.forward = Camera.main.transform.forward;
    }
    public void Clear()
    {
        gimmickTrigger1 = true;
        this.meshRenderer.material = gimmickTrigger1 ?  material[1] : material[0];
        
    }
}
