using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ready : MonoBehaviour
{
    public playerClass[] players;
    public charSelector selector;
    public List<Text> playernames;
    public List<bool> readyPlayers;
    Button button;

    

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = !readyPlayers.Contains(false);
    }
    public void addIndex()
    {
        if (readyPlayers.Count < 4)
        {
            readyPlayers.Add(false);
        }
    }
    public void removeIndex()
    {
        if (readyPlayers.Count > 2)
        {
            readyPlayers.RemoveAt(readyPlayers.Count - 1);
        }
    }
    public void startGame()
    {
        players = Resources.LoadAll<playerClass>("Lists/players/players");
        for (int i = 0; i < readyPlayers.Count; i++)
        {
            players[i].playerName = playernames[i].text;
            players[i].selectedCharacter = selector.sprites[selector.indices[i]];
            SceneManager.LoadScene("Game");
        }
    }
}
