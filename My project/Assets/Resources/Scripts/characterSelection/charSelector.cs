using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charSelector : MonoBehaviour
{
    [SerializeField] public Texture2D spritesheet;
    public Sprite[] sprites;
    public List<int> indices;
    public List<Image> renderers;

    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("personajes");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            renderers[0].sprite = sprites[indices[0]];
            renderers[1].sprite = sprites[indices[1]];
            renderers[2].sprite = sprites[indices[2]];
            renderers[3].sprite = sprites[indices[3]];
        }
        catch
        {

        }
    }

    public void movePointer(string player)
    {
        int playerInt = int.Parse(player);
        int nextInt = indices[Mathf.Abs(playerInt) - 1] + 1 * (int)Mathf.Sign(playerInt);

        if (nextInt > sprites.Length - 1)
        {
            indices[Mathf.Abs(playerInt) - 1] -= sprites.Length;
            nextInt = indices[Mathf.Abs(playerInt) - 1] + 1 * (int)Mathf.Sign(playerInt);
        }

        if (nextInt < 0)
        {
            indices[Mathf.Abs(playerInt) - 1] += sprites.Length;
            nextInt = indices[Mathf.Abs(playerInt) - 1] + 1 * (int)Mathf.Sign(playerInt);
        }

        if (indices.Contains(nextInt) )
        {
            indices[Mathf.Abs(playerInt) - 1] += 1 * (int)Mathf.Sign(playerInt);
            movePointer(player);
        }
        else
        {
            indices[Mathf.Abs(playerInt) - 1] += 1 * (int)Mathf.Sign(playerInt);
        }
    }

    public void addIndex()
    {
        if (indices.Count < 4)
        {
            indices.Add(0);
            movePointer(""+ (indices.Count));
        }
        
    }
    public void removeIndex()
    {
        if (indices.Count > 2)
        {
            indices.RemoveAt(indices.Count - 1);
        }
    }
}
