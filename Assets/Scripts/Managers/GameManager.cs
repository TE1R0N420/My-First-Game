using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int currentBitcoins;
    
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }


        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        UIManager.instance.UpdateBitcoinText(currentBitcoins);
    }

    public void GetBitcoins(int amountToGet)
    {
        currentBitcoins += amountToGet;
        UIManager.instance.UpdateBitcoinText(currentBitcoins);
    }

    public void SpendBitcoins(int amountToSpend)
    {
        currentBitcoins -= amountToSpend;

        if(currentBitcoins <= 0)
        {
            currentBitcoins = 0;
        }

        UIManager.instance.UpdateBitcoinText(currentBitcoins);
    }

    public int GetCurrentBitcoins() { return currentBitcoins; }
}
