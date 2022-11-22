using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class boardTile : MonoBehaviour
{
    public enum tileTypes
    {
        property,
        card,
        misc,
        custom,
        none
    }

    private SpriteRenderer spr;
    public tileTypes type;
    public GameObject next;
    public GameObject prev;
    public casilla ScriptableObject;

    [Header("Property")]
    public CasillaPropiedad casillaPropiedad;
    public GameObject owner;
    public int rentPrice;
    public int sellPrice;
    public UnityEvent propertyEvent1;
    public UnityEvent propertyEvent2;

    [Header("Card")]
    public UnityEvent drawCard;

    [Header("Custom")]
    public UnityEvent customEvent;

    // Start is called before the first frame update
    void Start()
    {
        spr = this.GetComponent<SpriteRenderer>();
        switch (type)
        {
            case tileTypes.property:
                spr.sprite = Resources.Load<Sprite>("Sprites/tiles/property_tile");
                if (casillaPropiedad != null)
                {
                    sellPrice = casillaPropiedad.sellPrice;
                    rentPrice = casillaPropiedad.rentPrice;
                }
                break;
            case tileTypes.card:
                spr.sprite = Resources.Load<Sprite>("Sprites/tiles/card_tile");
                break;
            case tileTypes.misc:
                spr.sprite = Resources.Load<Sprite>("Sprites/tiles/mystery_tile");
                break;
            case tileTypes.none:
                spr.sprite = Resources.Load<Sprite>("Sprites/tiles/base_tile");
                break;
            case tileTypes.custom:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void landOnTile()
    {
        switch (type)
        {
            case tileTypes.property:
                Debug.Log("Pay Up");
                if (casillaPropiedad != null)
                {
                    if (owner == null)
                    {
                        //Shows the buy property UI
                        propertyEvent1.Invoke();
                    }
                    else
                    {
                        //Shows the "You will be charged x UI"
                        propertyEvent2.Invoke();
                    }
                }
            break;

            case tileTypes.card:
                Debug.Log("Draw a Card");
                drawCard.Invoke();
                break;
            case tileTypes.misc:
                Debug.Log("Misc Effect");
                break;
            case tileTypes.custom:
                customEvent.Invoke();
                break;
            default:
                Debug.Log("Tile Does Not Have a Type");
                break;
        }
    }
}
