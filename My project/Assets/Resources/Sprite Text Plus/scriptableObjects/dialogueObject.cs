using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dialogue")]
public class dialogueObject : ScriptableObject
{
    [TextArea(5, 10)]
    public List<string> textLines;
}
