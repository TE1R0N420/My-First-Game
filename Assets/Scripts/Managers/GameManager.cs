using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    [SerializeField] int currentBitcoins;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
            GetBitcoins(20);

        if (Input.GetKey(KeyCode.H))
            SpendBitcoins(10);
    }

    public void GetBitcoins(int amountToGet)
    {
        currentBitcoins += amountToGet;
    }

    public void SpendBitcoins(int amountToSpend)
    {
        currentBitcoins -= amountToSpend;

        if(currentBitcoins <= 0)
        {
            currentBitcoins = 0;
        }
    }
}
