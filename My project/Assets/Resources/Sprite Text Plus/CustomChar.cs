using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomChar : MonoBehaviour
{
    public string FontName;
    public bool wavy;
    public bool hover;
    public bool randomized;
    public float randomizedTime;
    public bool shaky;
    public float waveSpeed = 7;
    public float hoverSpeed = 7;
    public float waveHeight;
    public float hoverHeight;
    public float shakerange;
    public int num = 0;

    public customFont font;

    SpriteRenderer spr;
    private Sprite[] subSprites;
    private Vector3 startPos;

    public Vector2 pixelPerfectClampPos(Vector2 moveVector, float pixelsPerUnit)
    {
        Vector2 vectorInPixels = new Vector2
            (
                Mathf.RoundToInt(moveVector.x * pixelsPerUnit),
                Mathf.RoundToInt(moveVector.y * pixelsPerUnit)
            );
        return vectorInPixels / pixelsPerUnit;
    }

    // Start is called before the first frame update
    void Start()
    {
        subSprites = font.subSprites;
        startPos = transform.position;
        spr = GetComponent<SpriteRenderer>();
        if (randomized)
        {
            StartCoroutine(random());
        }

        transform.position = pixelPerfectClampPos(transform.position, 16);
    }
    // Update is called once per frame
    void Update()
    {
        if (wavy)
        {
            transform.position = startPos + new Vector3(0.0f, Mathf.Sin(waveSpeed * Time.time + num) * waveHeight , 0.0f);
        }
        if (hover)
        {
            transform.position = startPos + new Vector3(0.0f, Mathf.Sin(hoverSpeed * Time.time) * hoverHeight, 0.0f);
        }
        if (shaky)
        {
            transform.position = startPos + new Vector3(Random.Range(-shakerange,shakerange), Random.Range(-shakerange, shakerange));
        }
    }
    private IEnumerator random()
    {
        while (true) 
        {
            spr.sprite = subSprites[Random.Range(0, subSprites.Length)];
            yield return new WaitForSeconds(randomizedTime);
        }
    }
}
