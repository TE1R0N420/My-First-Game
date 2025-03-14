using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    public static UIManager instance;
    
    [SerializeField] Image imageToFade;

    private void Start()
    {
        instance = this;
    }


    public void FadeImage()
    {
        imageToFade.GetComponent<Animator>().SetTrigger("Start Fade");
    }





}
