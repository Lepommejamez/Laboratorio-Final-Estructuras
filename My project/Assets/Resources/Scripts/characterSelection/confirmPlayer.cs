using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confirmPlayer : MonoBehaviour
{
    public Text playernameText;
    public InputField textBox;
    public int playerNum;
    public ready button;

    public void confirm()
    {
        if (textBox.text == "")
        {
            textBox.text = "Player " + playerNum;
        }
        playernameText.text = textBox.text;
        button.readyPlayers[playerNum - 1] = true;
        playernameText.gameObject.SetActive(true);
        textBox.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
