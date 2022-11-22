using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textLine : MonoBehaviour
{
    [Header("Use <h> for hovering text")]
    [Header("Use <w> for wavy text")]
    [Header("Use <s> for shaky text")]
    [Header("Use <c0> for colored text")]
    [Header("Use <r> for randomized text")]
    [TextArea(5, 10)]
    public string text;

    [Header("Main Preferences")]
    public customFont font;
    public bool textIsDelayed;
    public float charDelay;
    public float fullStopDelay;
    public float commaDelay;
    public int spriteSortingLayer;

    [Header("Spacing Preferences")]
    public int xSpacing = 0; //Horizontal space between any two characters
    public int ySpacing = 0; //Vertical space between lines
    public int spacePixels = 4; //amount of pixels corresponding to a space character

    private int yOffset = 0;
    private float pixel = 0;

    [Header("Keycode Preferences")]
    public Color[] colors;
    public float randomizedTime;
    public float waveSpeed;
    public float waveHeight;
    public float hoverSpeed;
    public float hoverHeight;
    public float shakeRange;

    private bool iscolor = false;
    private bool isHoverText = false;
    private bool isWavyText = false;
    private bool isShaky = false;
    private bool isScribbled = false;
    private int activeColor = 0;

    // Start is called before the first frame update
    void Start()
    {
        pixel = 1 / font.pixelsPerUnit;
        if(textIsDelayed)
        {
            StartCoroutine(printLineDelayed()); 
        }
        else
        {
            printLine();
        }
       
    }

    // Update is called once per fra
    public void printLine()
    {
        Vector2 charPos = new Vector2(this.transform.position.x, this.transform.position.y);
        char[] chars = text.ToCharArray();
        bool flag = false;
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '<')
            {
                flag = true;
                i++;
            }
            if (flag)
            {
                switch (chars[i])
                {
                    case 'h':
                        isHoverText = !isHoverText;
                        break;

                    case 'w':
                        isWavyText = !isWavyText;
                        break;

                    case 's':
                        isShaky = !isShaky;
                        break;

                    case 'c':
                        iscolor = true;
                        if (chars[i + 1] == '>')
                        {
                            iscolor = false;
                        }
                        if (char.IsDigit(chars[i + 1]))
                        {
                            activeColor = (int)char.GetNumericValue(chars[i + 1]);
                        }
                        break;

                    case 'r':
                        isScribbled = !isScribbled;
                        break;
                }
            }
            else
            {
                if (chars[i] != ' ' && chars[i] != '\n' && chars[i] != '\t')
                {
                    GameObject newObj = new GameObject(chars[i].ToString());
                    SpriteRenderer spr = newObj.AddComponent<SpriteRenderer>();
                    spr.sprite = font.getSprite(chars[i]);
                    newObj.transform.parent = this.gameObject.transform;
                    newObj.transform.position = charPos;
                    spr.sortingOrder = spriteSortingLayer;
                    charPos.x = charPos.x + font.getSpriteOffsetX(chars[i]) * pixel + font.getSpriteWidth(chars[i]) * pixel + (xSpacing - 1) * pixel;
                    if (iscolor)
                    {
                        spr.color = colors[activeColor];
                    }
                    if (isHoverText || isWavyText || isShaky || isScribbled)
                    {
                        var comp = newObj.AddComponent<CustomChar>();
                        comp.font = font;
                        if (isScribbled)
                        {
                            comp.randomized = true;
                            comp.randomizedTime = randomizedTime;
                        }
                        if (isHoverText)
                        {
                            comp.hover = true;
                            comp.hoverSpeed = hoverSpeed;
                            comp.hoverHeight = hoverHeight * pixel;
                        }
                        if (isShaky)
                        {
                            comp.shaky = true;
                            comp.shakerange = shakeRange;
                        }
                        if (isWavyText)
                        {
                            comp.wavy = true;
                            comp.num = i;
                            comp.waveSpeed = waveSpeed;
                            comp.waveHeight = waveHeight * pixel;
                        }
                    }
                }
                else
                {
                    switch (chars[i])
                    {
                        case ' ':
                            charPos.x = charPos.x + (spacePixels - 1) * pixel;
                            break;

                        case '\t':
                            charPos.x = charPos.x + (spacePixels - 1) * pixel * 6;
                            break;

                        case '\n':
                            charPos.x = this.transform.position.x;
                            charPos.y = charPos.y - ((yOffset + (font.getSpriteHeight(chars[i - 1])) + ySpacing) * pixel);
                            break;
                    }
                }
            }
            if (chars[i] == '>')
            {
                flag = false;
            }
        }
        Destroy(this);
    }
    public IEnumerator printLineDelayed()
    {
        Vector2 charPos = new Vector2(this.transform.position.x, this.transform.position.y);
        char[] chars = text.ToCharArray();
        bool flag = false;
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '<')
            {
                flag = true;
                i++;
            }
            if (flag)
            {
                switch (chars[i])
                {
                    case 'h':
                        isHoverText = !isHoverText;
                        break;

                    case 'w':
                        isWavyText = !isWavyText;
                        break;

                    case 's':
                        isShaky = !isShaky;
                        break;

                    case 'c':
                        iscolor = true;
                        if (chars[i + 1] == '>')
                        {
                            iscolor = false;
                        }
                        if (char.IsDigit(chars[i + 1]))
                        {
                            activeColor = (int)char.GetNumericValue(chars[i + 1]);
                        }
                        break;

                    case 'r':
                        isScribbled = !isScribbled;
                        break;
                }
            }
            else
            {
                
                if (chars[i] != ' ' && chars[i] != '\n' && chars[i] != '\t')
                {
                    GameObject newObj = new GameObject(chars[i].ToString());
                    SpriteRenderer spr = newObj.AddComponent<SpriteRenderer>();
                    spr.sprite = font.getSprite(chars[i]);
                    newObj.transform.parent = this.gameObject.transform;
                    newObj.transform.position = charPos;
                    spr.sortingOrder = spriteSortingLayer;
                    charPos.x = charPos.x + font.getSpriteOffsetX(chars[i]) * pixel + font.getSpriteWidth(chars[i]) * pixel + (xSpacing - 1) * pixel;
                    if (iscolor)
                    {
                        spr.color = colors[activeColor];
                    }
                    if (isHoverText || isWavyText || isShaky || isScribbled)
                    {
                        var comp = newObj.AddComponent<CustomChar>();
                        comp.font = font;
                        if (isScribbled)
                        {
                            comp.randomized = true;
                            comp.randomizedTime = randomizedTime;
                        }
                        if (isHoverText)
                        {
                            comp.hover = true;
                            comp.hoverSpeed = hoverSpeed;
                            comp.hoverHeight = hoverHeight * pixel;
                        }
                        if (isShaky)
                        {
                            comp.shaky = true;
                            comp.shakerange = shakeRange;
                        }
                        if (isWavyText)
                        {
                            comp.wavy = true;
                            comp.num = i;
                            comp.waveSpeed = waveSpeed;
                            comp.waveHeight = waveHeight * pixel;
                        }
                    }
                }
                else
                {
                    switch (chars[i])
                    {
                        case ' ':
                            charPos.x = charPos.x + (spacePixels - 1) * pixel;
                            break;

                        case '\t':
                            charPos.x = charPos.x + (spacePixels - 1) * pixel * 6;
                            break;

                        case '\n':
                            charPos.x = this.transform.position.x;
                            charPos.y = charPos.y - ((yOffset + (font.getSpriteHeight(chars[i-1])) + ySpacing) * pixel);
                            break;
                    }
                } 
            }

            float delay = charDelay;
            switch (chars[i])
            {
                case '>':
                    flag = false;
                    break;

                case '.':
                case '?':
                case '!':
                    delay += fullStopDelay;
                    break;

                case ',':
                    delay += commaDelay;
                    break;
            }
            if (!flag)
            {
                yield return new WaitForSeconds(delay);
            }
            else
            {
                yield return new WaitForSeconds(0);
            }
        }
        Destroy(this);
    }
}