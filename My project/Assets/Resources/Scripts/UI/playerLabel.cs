using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLabel : MonoBehaviour
{
    public playerList playerController;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.currentPlayer != null)
        {
            text.text = playerController.currentPlayer.name;
        }
    }
}
