using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class buyProperty : MonoBehaviour
{
    public Image sprite;
    public Text propertyName;
    public playerList spawner;
    public UnityEvent canBuy;
    public UnityEvent cannotBuy;
    public Text price;

    public player player;
    public boardTile propertyTile;

    private void OnEnable()
    {
        Debug.Log("skeet");
        player = spawner.currentPlayer.GetComponent<player>();
        propertyTile = player.currentTile.GetComponent<boardTile>();
    }

    public void Update()
    {
        propertyName.text = propertyTile.casillaPropiedad.tileName;
        if (propertyTile.casillaPropiedad.sprite != null)
        {
            sprite.sprite = propertyTile.casillaPropiedad.sprite;
        }
        price.text = propertyTile.sellPrice.ToString("$0000000");
    }

    public void buy()
    {
        if (player.moneyAmt >= propertyTile.sellPrice)
        {
            Debug.Log("Buy Property");
            player.properties.Add(propertyTile);
            propertyTile.owner = player.gameObject;
            player.moneyAmt -= propertyTile.sellPrice;
            canBuy.Invoke();
        }
        else
        {
            Debug.Log("Insufficient Funds");
            cannotBuy.Invoke();
        }
    }
}
