using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class player  : MonoBehaviour
{
    public Dictionary<int, int> playerbalance = new Dictionary<int, int>();
    public int escapes;
    public bool isInJail;
    public boardTile jailTile;
    public playerList spawner;
    public float moveSpeed = 1;
    public int moneyAmt;
    public bool canMove;
    public bool isMoving;
    public boardTile currentTile;
    public GameObject camera;
    public GameObject next;
    public List<boardTile> properties;
    public UnityEvent onArriveAtTile;
    public UnityEvent onEndTurn;
    public void Start()
    {
        playerbalance.Add(500, 2);
        playerbalance.Add(100, 4);
        playerbalance.Add(50, 1);
        playerbalance.Add(20, 1);
        playerbalance.Add(10, 2);
        playerbalance.Add(5, 1);
        playerbalance.Add(1, 5);
        /*
        print(getNetBalance());

        int x = 500;
        int y = 600;
        print(600/500);
        */
    }
    public int getNetBalance()
    {
        int sum = 0;
        foreach (KeyValuePair<int, int> kvp in playerbalance)
        {
            sum += kvp.Key * kvp.Value;
        }
        return sum;
    }
    public bool hasAmount(int amount)
    {
        if (getNetBalance() >= amount)
            return true;
        else
            return false;
    }
    public void recieveMoney(int amount)
    {
        playerbalance[500] += amount / 500;
        amount %= 500;
        playerbalance[100] += amount / 100;
        amount %= 100;
        playerbalance[50] += amount / 50;
        amount %= 50;
        playerbalance[20] += amount / 20;
        amount %= 20;
        playerbalance[10] += amount / 10;
        amount %= 10;
        playerbalance[5] += amount / 5;
        amount %= 5;
        playerbalance[1] += amount / 1;
        amount %= 1;
    }
    public void payMoney(int amount)
    {
        if(hasAmount(amount))
        {
            if (amount/500 >= 1)
            {
                playerbalance[500] -= amount / 500;
            }
        }
    }
    public void printDict()
    {
        foreach (KeyValuePair<int, int> kvp in playerbalance)
        {
            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }
    }
    void Update()
    {
        if (canMove)
        {
            if (isMoving && this.transform.position == currentTile.gameObject.transform.position)
            {
                currentTile.landOnTile();
                StartCoroutine(landOnTile());
                isMoving = false;
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, currentTile.gameObject.transform.position, moveSpeed * Time.deltaTime);
            }
        } 
    }
    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Mathf.Floor(Mathf.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
    public void moveTiles(int amt)
    {
        isMoving = true;
        if (isInJail && IsPrime(amt))
        {
            isInJail = false;
        }
        if (Mathf.Sign(amt) == 1)
        {
            for (int i = 0; i < Mathf.Abs(amt); i++)
            {
                nextTile();
            }
        }
        else
        {
            for (int i = 0; i < Mathf.Abs(amt); i++)
            {
                prevTile();
            }
        }
    }
    public void nextTile()
    {
        if (!isInJail)
        {
            isMoving = true;
            currentTile = currentTile.next.GetComponent<boardTile>();
        }
        
    }
    public void prevTile()
    {
        if (!isInJail)
        {
            isMoving = true;
            currentTile = currentTile.prev.GetComponent<boardTile>();
        }    
    }
    public IEnumerator landOnTile()
    {
        onArriveAtTile.Invoke();
        yield return new WaitForSeconds(1);
        onEndTurn.Invoke();
    }
    public void getOutOfJailFree()
    {
        escapes++;
    }
    public void goToJail()
    {
        if (escapes == 0)
        {
            isInJail = true;
            currentTile = jailTile;
            isMoving = true;
        }
        else
        {
            escapes--;
        }
        
    }
}
