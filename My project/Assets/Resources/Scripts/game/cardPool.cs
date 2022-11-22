using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardPool : MonoBehaviour
{
    public static cardPool cardDeck;
    public card[] cards;
    void Start()
    {
        cardDeck = this;
        cards = Resources.LoadAll<card>("cards/active");
    }

    public card drawRandomCard()
    {
        return cards[Random.Range((int)0, cards.Length)];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
