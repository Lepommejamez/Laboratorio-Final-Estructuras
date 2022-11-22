using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class dice2 : MonoBehaviour
{
    public playerList spawner;
    [Range(0, 9)]
    public int range;
    public int currentNum;
    public bool rolling;
    public GameObject numbers;
    public customFont font;
    public UnityEvent onDiceRoll;
    public SpriteRenderer[] spr;

    [Header("Settings")]
    [Range(0, 2)]
    [SerializeField] float updateRate;
    void Awake()
    {
        spr = numbers.GetComponentsInChildren<SpriteRenderer>();
    }
    void Update()
    {
        if (rolling)
        {
            goTotPlayer();
        }
        if (Input.GetButtonDown("Submit"))
        {
            if (rolling)
            {
                stopShuffle();
                onDiceRoll.Invoke();
                spawner.currentPlayer.GetComponent<player>().moveTiles(currentNum);
            }
        }
    }
    public void startShuffle()
    {
        StartCoroutine("shuffle");
    }
    public void stopShuffle()
    {
        StopCoroutine("shuffle");
        rolling = false;
    }
    private IEnumerator shuffle()
    {
        rolling = true;
        while (true)
        {
            if (currentNum > range)
            {
                currentNum -= range;
            }
            else
                currentNum += 1;
            foreach (SpriteRenderer x in spr)
            {
                x.sprite = font.getSprite(System.Convert.ToChar(currentNum + 48));
            }
            yield return new WaitForSeconds(updateRate);
        }
    }
    public void goTotPlayer()
    {
        this.transform.position = new Vector3(spawner.currentPlayer.transform.position.x, this.transform.position.y, spawner.currentPlayer.transform.position.z);
    }
}