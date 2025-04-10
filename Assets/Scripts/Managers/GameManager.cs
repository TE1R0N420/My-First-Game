using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int currentBitcoins;
    
    
    private void Awake()
    {
        instance = this;
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
}
