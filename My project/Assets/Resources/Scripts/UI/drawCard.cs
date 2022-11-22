using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawCard : MonoBehaviour
{
    public Text text;
    public card card;
    private void OnEnable()
    {
        card = cardPool.cardDeck.drawRandomCard();
        Debug.Log("Skeet");
        text.text = card.description;
    }

    public void cardEffect()
    {
        player p1 = playerList.staticSpawner.currentPlayer.GetComponent<player>();
        if (card.type == card.cardType.payToPlayer || card.type == card.cardType.recieveFromPlayer)
        {
            player p2 = playerList.staticSpawner.getRandomPlayer();
            while (p1 == p2)
            {
                p2 = playerList.staticSpawner.getRandomPlayer();
            }
            card.drawCard(p1, p2);
        }
        else if(card.type == card.cardType.goToJail)
        {
            playerList.staticSpawner.currentPlayer.GetComponent<player>().goToJail();
        }
        else
        {
            card.drawCard(p1);
        }
    }
}
