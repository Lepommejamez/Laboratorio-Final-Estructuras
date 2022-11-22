using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dialogue : MonoBehaviour
{
    [Header("Use <h> for hovering text")]
    [Header("Use <w> for wavy text")]
    [Header("Use <s> for shaky text")]
    [Header("Use <c0> for colored text")]
    [Header("Use <r> for randomized text")]
    public dialogueObject dialogue;

    [Header("Main Preferences")]
    public customFont font;
    public bool textIsDelayed;
    public float charDelay;
    public float fullStopDelay;
    public float commaDelay;
    public int spriteSortingLayer;

    [Header("Spacing Preferences")]
    public int xSpacing; //Horizontal space between any two characters
    public int ySpacing; //Vertical space between lines
    public int spacePixels; //amount of pixels corresponding to a space character

    [Header("Keycode Preferences")]
    public Color[] colors;
    public float randomizedTime;
    public float waveSpeed;
    public float waveHeight;
    public float hoverSpeed;
    public float hoverHeight;
    public float shakeRange;
    public void printLine(int i)
    {
        GameObject newObj = new GameObject("Line "+i);
        textLine textLine = newObj.AddComponent<textLine>();
        textLine.text = dialogue.textLines[i];
        textLine.font = font;
        textLine.textIsDelayed = textIsDelayed;
        textLine.charDelay = charDelay;
        textLine.fullStopDelay = fullStopDelay;
        textLine.commaDelay = commaDelay;

        textLine.xSpacing = xSpacing;
        textLine.ySpacing = ySpacing;
        textLine.spacePixels = spacePixels;

        textLine.spriteSortingLayer = spriteSortingLayer;
        textLine.colors = colors;
        textLine.randomizedTime = randomizedTime;
        textLine.waveSpeed = waveSpeed;
        textLine.waveHeight = waveHeight;
        textLine.hoverHeight = hoverHeight;
        textLine.hoverSpeed = hoverSpeed;
        textLine.shakeRange = shakeRange;

        newObj.transform.parent = this.transform;
        newObj.transform.position = this.transform.position;
    }
}
