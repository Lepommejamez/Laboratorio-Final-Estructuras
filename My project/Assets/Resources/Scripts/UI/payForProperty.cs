using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class payForProperty : MonoBehaviour
{
    public Text price; 
    public playerList spawner;
    private player player;
    private boardTile propertyTile;

    private void OnEnable()
    {
        Debug.Log("skeet");
        player = spawner.currentPlayer.GetComponent<player>();
        propertyTile = player.currentTile.GetComponent<boardTile>();
    }

    public void Update()
    {
        price.text = propertyTile.rentPrice.ToString("$0000000");
    }

    public void pay()
    {
        player.moneyAmt -= propertyTile.rentPrice;
        propertyTile.owner.GetComponent<player>().moneyAmt += propertyTile.rentPrice;
    }
}
