using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] Material[] material;
    MeshRenderer meshRenderer;
    public bool gimmickTrigger1 = false;//ギミックが解かれたのか判定する
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer= GetComponent<MeshRenderer>();
    }

    public void Clear()
    {
        gimmickTrigger1 = true;
        this.meshRenderer.material = gimmickTrigger1 ?  material[1] : material[0];
        
    }
}
