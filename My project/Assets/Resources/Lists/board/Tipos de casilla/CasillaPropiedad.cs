using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item 1", menuName = "New Node/tile/Property")]
public class CasillaPropiedad : casilla
{
    bool hasOwner;
    public int sellPrice;
    public int rentPrice;
}
