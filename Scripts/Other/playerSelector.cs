using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSelector : MonoBehaviour
{
    int minPlayerCount = 2;
    int maxPlayerCount = 4;
    public int playerCount = 2;
    public GameObject p1Icon;
    public GameObject p2Icon;
    public GameObject p3Icon;
    public GameObject p4Icon;
    public void addPlayer()
    {
        if (playerCount < maxPlayerCount)
        {
            playerCount++;
            if (playerCount == 3)
            {
                p3Icon.SetActive(true);
            }
            if (playerCount == 4)
            {
                p4Icon.SetActive(true);
            }
        }
    }
    public void removePlayer()
    {
        if (playerCount > minPlayerCount)
        {
            playerCount--;
            if (playerCount == 3)
            {
                p4Icon.SetActive(false);
            }
            if (playerCount == 2)
            {
                p3Icon.SetActive(false);
            }
        }
    }

}
