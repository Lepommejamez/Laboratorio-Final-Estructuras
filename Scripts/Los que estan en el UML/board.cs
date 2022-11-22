using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public GameObject tiles;
    public int tileCount;
    public boardTile ptr;
    public boardTile ult;

    // Start is called before the first frame update
    void Start()
    {
        getList();
    }

    void getList()
    {
        for (int i = 0; i < tiles.transform.childCount; i++)
        {
            tileCount = i;
            AddLast(tiles.transform.GetChild(i).gameObject.GetComponent<boardTile>());
        }
        ult.next = ptr.gameObject;
        ptr.prev = ult.gameObject;
        tileCount++;
    }
    void AddLast(boardTile data)
    {
        if (ptr == null)
        {
            ptr = data;
            ult = data;
        }
        else
        {
            data.prev = ult.gameObject;
            ult.next = data.gameObject;
            ult = data;
        }
    }
    void AddFirst(boardTile data)
    {
        if (ptr == null)
        {
            ptr = data;
            ult = data;
        }
        else
        {
            ptr.prev = data.gameObject;
            data.next = ptr.gameObject;
            ptr = data;
        }
    }
}
