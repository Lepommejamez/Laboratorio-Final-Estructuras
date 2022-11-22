using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class card : ScriptableObject
{
    public enum cardType
    {
        recieveMoney,
        payToBank,   
        payToPlayer,
        recieveFromPlayer,
        goToJail,
        getOutOfJail
    }
    public cardType type;
    public int amt;
    [TextArea(5, 10)]
    public string description;

    public void drawCard(player p, player p2 = null)
    {
        switch (type)
        {
            case cardType.recieveMoney:
                //requires only 1 player
                p.moneyAmt += amt;
                break;
            case cardType.payToBank:
                //requires only 1 player
                p.moneyAmt -= amt;
                break;
            case cardType.payToPlayer:
                //requires 2 players
                p.moneyAmt -= amt;
                p2.moneyAmt += amt;
                break;
            case cardType.recieveFromPlayer:
                //requires 2 players
                p.moneyAmt += amt;
                p2.moneyAmt -= amt;
                break;
            case cardType.goToJail:
                //requires only 1 player
                break;
            case cardType.getOutOfJail:
                //requires only 1 player
                break;

            default:
                break;
        }
    }
}
