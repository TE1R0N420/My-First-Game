using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField] AudioClip[] Music;
    [SerializeField] GameObject[] SFX;

    private GameObject theSFX;
    private AudioSource audioSource;


    private void Awake()
    {
        instance = this;
    }







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayLevelMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayLevelMusic()
    {
        audioSource.clip = Music[1];
        audioSource.Play();
    }

    public void PlayGameOverMusic()
    {
        audioSource.clip = Music[0];
        audioSource.Play();
    }

    public void PlaySFX(int sfxNumber)
    {
        //AudioSource.PlayClipAtPoint(SFX[sfxNumber], Camera.main.transform.position);

        theSFX = Instantiate(SFX[sfxNumber], Camera.main.transform);
        Invoke("DestroySfxGameObject", theSFX.GetComponent<AudioSource>().clip.length);
    }

    private void DestroySfxGameObject()
    {
        Destroy(theSFX);
    }
}
