using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] int LevelToLoad;
    [SerializeField] GameObject theDoor;

    private void Start()
    {
       
    }

    public void PrintRoomName(int levelIndex)
    {
        LevelToLoad = levelIndex;
        
        string scenePath = SceneUtility.GetScenePathByBuildIndex(LevelToLoad);
        int lastSlash = scenePath.LastIndexOf('/');
        string name = scenePath.Substring(lastSlash + 1);
        int dot = name.LastIndexOf('.');
        theDoor.GetComponent<NameAppear>().SetTheLevelName(name.Substring(0, dot));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(LevelManager.instance.LoadingNextLevel(LevelToLoad));
        }
    }



}
