using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class NameAppear : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI levelNameUI;
    [SerializeField] GameObject levelNameCanvas;
    [SerializeField] GameObject doorToOpen;
    private bool inOpenDoorZone;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelNameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inOpenDoorZone)
        {
            Collider2D col = doorToOpen.GetComponent<Collider2D>();
            if (col) col.enabled = false;

            SpriteRenderer sr = doorToOpen.GetComponent<SpriteRenderer>();
            if (sr) sr.enabled = false;
        }
    }








    public void SetTheLevelName(string lvlName)
    {
        levelNameUI.text = lvlName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelNameCanvas.SetActive(true);
            inOpenDoorZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelNameCanvas.SetActive(false);
            inOpenDoorZone = false;

            doorToOpen.SetActive(true);
        }
    }
}
