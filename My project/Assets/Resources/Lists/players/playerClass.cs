using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "New Node/player")]
public class playerClass : Nodo
{
    public string playerName;
    public Sprite selectedCharacter;
    public GameObject avatar;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}
