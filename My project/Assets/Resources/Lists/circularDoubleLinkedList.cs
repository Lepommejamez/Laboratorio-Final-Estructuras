using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circularDoubleLinkedList : ScriptableObject
{
    bool isEmpty;
    public Nodo ptr;
    public Nodo ult;
    public string filePath;
    [SerializeField] int length;

    public void getList()
    {
        clearList();
        if (isEmpty)
        {
            foreach (Nodo nodo in fetchAllNodes())
            {
                AddLast(nodo);
                length++;
            }
            isEmpty = false;
        }
    }

    public void clearList()
    {
        isEmpty = true;
        length = 0;
        ptr = null;
        ult = null;
        foreach (Nodo nodo in fetchAllNodes())
        {
            nodo.next = null;
            nodo.prev = null;
        }
    }

    public void print()
    {
        Nodo P = this.ptr;
        while (P != null)
        {
            Debug.Log(P.name);
            P = P.next;
        }
    }

    int getLength()
    {
        int i = 0;
        Nodo P = this.ptr;
        while (P != null)
        {
            i++;
            P = P.next;
        }
        return i;
    }

    void AddLast(Nodo data)
    {
        if (ptr == null)
        {
            ptr = data;
            ult = data;
        }
        else
        {
            data.prev = ult;
            ult.next = data;
            ult = data;
        }
    }
    void AddFirst(Nodo data)
    {
        if (ptr == null)
        {
            ptr = data;
            ult = data;
        }
        else
        {
            ptr.prev = data;
            data.next = ptr;
            ptr = data;
        }
    }

    private Nodo[] fetchAllNodes()
    {
        Nodo[] cards = Resources.LoadAll<Nodo>(filePath);
        return cards;
    }
}
