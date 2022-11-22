using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class playerList : MonoBehaviour
{
    public static playerList staticSpawner;
    [HideInInspector] public List<GameObject> playerObjects = new List<GameObject>();
    public Dictionary<int, int> playerOrder = new Dictionary<int, int>();
    private List<playerClass> playersList = new List<playerClass>();
    public GameObject startingDice;
    public GameObject gameDice;
    public GameObject mainCam;
    public GameObject ptr;
    public GameObject ult;
    public UnityEvent onNextTurn;
    public List<GameObject> players = new List<GameObject>();
    public GameObject currentPlayer;
    public void sendPlayerToJail()
    {
        currentPlayer.GetComponent<player>().goToJail();
    }
    void Start()
    {
        staticSpawner = this;
        playerClass[] players = Resources.LoadAll<playerClass>("Lists/players/players");
        player[] players2 = this.transform.GetComponentsInChildren<player>();
        for(int i = 0; i < players.Length; i++)
        {
            if (players[i].playerName != "")
            {
                GameObject playerObj = players2[i].gameObject;
                playersList.Add(players[i]);
                playerObjects.Add(playerObj);
                playerObj.SetActive(true);
                playerObj.name = players[i].playerName;
                playerObj.GetComponent<SpriteRenderer>().sprite = players[i].selectedCharacter;
            }
        }
        


        for (int i = 0; i < players2.Length; i++)
        {
            if (players2[i].name == "_)(*&^%$#@")
            {
                Destroy(players2[i].gameObject);
                //Destroy(players2[i+1]);
            }
        }
    }
    public void setPlayerOrder()
    {
        for (int i = 0; i < 10; i++)
        {
            if (playerOrder.ContainsKey(i))
            {
                players.Add(playerObjects[playerOrder[i]]);
            }
        }

        ptr = players[0];
        ult = players[0];

        foreach (GameObject obj in players)
        {
            ult.GetComponent<player>().next = obj;
            ult = obj;
        }
        ult.GetComponent<player>().next = ptr;

        currentPlayer = players[0];
        mainCam.SetActive(false);
        cameraTransition.camTransition.enterAndExitDelayed(2);
    }
    public void advanceTile(int amt)
    {
        var player = currentPlayer.GetComponent<player>();
        player.canMove = true;
        player.moveTiles(amt);
    }
    public void startTurn()
    {
        currentPlayer.GetComponent<player>().camera.SetActive(true);
        var script = currentPlayer.GetComponent<player>();
        script.canMove = true;
        Debug.Log(this.gameObject.name + " started turn.");
    }
    public void endTurn()
    {
        var player = currentPlayer.GetComponent<player>();
        player.camera.SetActive(false);
        player.canMove = false;
        currentPlayer = currentPlayer.GetComponent<player>().next;
        player = currentPlayer.GetComponent<player>();
        player.canMove = true;
        player.camera.SetActive(true);
        Debug.Log(this.gameObject.name + " ended turn.");
        onNextTurn.Invoke();
    }
    public player getRandomPlayer()
    {
        return players[Random.Range((int)0, players.Count)].GetComponent<player>();
    }
    public void printDict()
    {
        foreach (KeyValuePair<int, int> kvp in playerOrder)
        {
            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }
    }
}
