using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Font")]
public class customFont : ScriptableObject
{
    public string FontName;
    [TextArea(5, 10)]
    public string charOrder;
    public float pixelsPerUnit;
    public Sprite[] subSprites;
    public int rectX;
    public int rectY;

    public Dictionary<char, Sprite> spriteDict = new Dictionary<char, Sprite>();
    
    private void OnValidate()
    {
        subSprites = Resources.LoadAll<Sprite>(FontName);
        pixelsPerUnit =  subSprites[0].pixelsPerUnit;
        AssignDictionaryValues(spriteDict, charOrder);
        rectX = (int)(subSprites[0].rect.xMax - subSprites[0].rect.x);
        rectY = (int)(subSprites[0].rect.yMax - subSprites[0].rect.y);
        Debug.Log("Succesfully loaded "+spriteDict.Count+" characters.");
    }
    public void AssignDictionaryValues(Dictionary<char, Sprite> dic, string charOrder)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(FontName);
        char[] chars = charOrder.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            dic[chars[i]] = sprites[i];
        }
    }
    public Sprite getSprite(char character)
    {
        return spriteDict[character];
    }
    public int getSpriteOffsetX(char character)
    {
        Sprite sprite = spriteDict[character];
        int rectWidth = (int)(sprite.rect.xMax - sprite.rect.x);
        int rectHeight = (int)(sprite.rect.yMax - sprite.rect.y);
        Texture2D myTexture = sprite.texture;
        int min = 10000;
        for (int y = 0; y < rectHeight; y++)
        {
            for (int x = 0; x < rectWidth; x++)
            {
                int coordX = (int)sprite.rect.x + x;
                int coordY = (int)sprite.rect.y + y;
                if (myTexture.GetPixel(coordX, coordY).a != 0)
                {
                    if(x < min)
                    {
                        min = x;
                        break;
                    }  
                }
            }
        } 
        return min;
    }
    public int getSpriteWidth(char character)
    {
        Sprite sprite = spriteDict[character];
        int rectWidth = (int)(sprite.rect.xMax - sprite.rect.x);
        int rectHeight = (int)(sprite.rect.yMax - sprite.rect.y);
        Texture2D myTexture = sprite.texture;
        int count = 0;
        int max = -1000;
        for (int y = 0; y < rectHeight; y++)
        {
            count = 0;
            for (int x = 0; x < rectWidth; x++)
            {
                int coordX = (int)sprite.rect.x + x;
                int coordY = (int)sprite.rect.y + y;
                if (myTexture.GetPixel(coordX, coordY).a != 0)
                {
                    count = count + 1;
                }
            }
            if (count > max)
            {
                max = count;
            }
        }
        return max;
    }
    public int getSpriteHeight(char character)
    {
        Sprite sprite = spriteDict[character];
        int rectWidth = (int)(sprite.rect.xMax - sprite.rect.x);
        int rectHeight = (int)(sprite.rect.yMax - sprite.rect.y);
        Texture2D myTexture = sprite.texture;
        int count = 0;
        int max = -1000;
        for (int x = 0; x < rectWidth; x++)
        {
            count = 0;
            for (int y = 0; y < rectHeight; y++)
            {
                int coordX = (int)sprite.rect.x + x;
                int coordY = (int)sprite.rect.y + y;
                if (myTexture.GetPixel(coordX, coordY).a != 0)
                {
                    count = count + 1;
                }
            }
            if (count > max)
            {
                max = count;
            }
        }
        return max;
    }
}