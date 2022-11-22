using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer[] sprs;
    // Start is called before the first frame update
    void Start()
    {
        sprs = this.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        foreach(var i in sprs)
        {
            
        }
        */
    }
}
