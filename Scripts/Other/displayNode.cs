using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayNode : MonoBehaviour
{
    public Nodo nodo;
    public customFont font;
    SpriteRenderer spr;
    public GameObject topText;
    public GameObject bottomText;

    // Start is called before the first frame update
    void Start()
    {
        /*
        this.gameObject.name = nodo.tileName;
        spr = this.GetComponent<SpriteRenderer>();
        if (spr == null)
        {
            spr = this.gameObject.AddComponent<SpriteRenderer>();
        }
        spr.sprite = nodo.sprite;

        if (topText == null)
        {
            topText = new GameObject("Text" + nodo.tileName);
            topText.transform.parent = this.transform;
        }
        textLine objText = topText.AddComponent<textLine>();
        objText.text = nodo.tileName;
        objText.font = font;

        
        if (bottomText == null)
        {
            bottomText = new GameObject("Text" + nodo.sellPrice);
            bottomText.transform.parent = this.transform;
        }

        objText = bottomText.AddComponent<textLine>();
        objText.text = nodo.sellPrice.ToString();
        objText.font = font;
        */

        //objText.printLine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
