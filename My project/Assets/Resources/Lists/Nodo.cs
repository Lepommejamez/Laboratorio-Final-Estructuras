using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Nodo : ScriptableObject
{
    public Nodo next;
    public Nodo prev;
}