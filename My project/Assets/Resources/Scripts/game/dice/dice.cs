using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class dice : MonoBehaviour
{
    
    public playerList spawner;
    [Range(0, 9)]
    public int range;
    public int currentPlayer;
    public int currentNum;
    public bool rolling;
    public GameObject numbers;
    public customFont font;
    private SpriteRenderer[] spr;
    public UnityEvent onFinish;

    [Header("Settings")]
    [Range(0, 2)]
    [SerializeField] float updateRate;

    void Start()
    {
        spr = numbers.GetComponentsInChildren<SpriteRenderer>();
        goToNextPlayer();
        startShuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (rolling)
            {
                stopShuffle();
                if (spawner.playerOrder.ContainsKey(currentNum))
                {
                    Debug.Log("Skeet");
                    while (spawner.playerOrder.ContainsKey(currentNum))
                    {
                        currentNum++;
                        foreach (SpriteRenderer x in spr)
                        {
                            x.sprite = font.getSprite(System.Convert.ToChar(currentNum + 48));
                        }
                    }
                }
                spawner.playerOrder.Add(currentNum, currentPlayer);
            }
            else
            {
                if (spawner.playerObjects.Count-1 > currentPlayer)
                {
                    goToNextPlayer();
                    startShuffle();
                }
                else
                {
                    onFinish.Invoke();
                    Destroy(this.gameObject);
                }
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
    public void goToNextPlayer()
    {
        currentPlayer++;
        this.transform.position = new Vector3(spawner.playerObjects[currentPlayer].transform.position.x, this.transform.position.y, spawner.playerObjects[currentPlayer].transform.position.z);
    }
}
