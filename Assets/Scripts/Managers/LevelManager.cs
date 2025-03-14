using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    [SerializeField] float timeToLoad = 2f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    public IEnumerator LoadingNextLevel(string nextLevel)
    {
        Time.timeScale = 0.5f;

        UIManager.instance.FadeImage();
        
        yield return new WaitForSecondsRealtime(timeToLoad);

        Time.timeScale = 1f;

        SceneManager.LoadScene(nextLevel);
    }
    
}
