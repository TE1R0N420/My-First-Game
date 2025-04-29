using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{

    [SerializeField] Slider bossHealthSlider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossHealthSlider.maxValue = Object.FindFirstObjectByType<BossHealthHandler>().GetBossMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        bossHealthSlider.value = Object.FindFirstObjectByType<BossHealthHandler>().GetBossCurrentHealth();

        if(bossHealthSlider.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
