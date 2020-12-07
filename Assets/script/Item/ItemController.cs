using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] GameObject iteminventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// アイテムを使う
    /// </summary>
    public void Use()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// アイテムを拾う
    /// </summary>
    public void Get()
    {
        this.transform.position = iteminventory.transform.position;
    }
}
