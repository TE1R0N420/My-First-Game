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
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
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
        if (sfxNumber < 0 || sfxNumber >= SFX.Length || SFX[sfxNumber] == null)
        {
            Debug.LogWarning("SFX number out of range or null.");
            return;
        }

        if (Camera.main == null)
        {
            Debug.LogWarning("No main camera available for SFX instantiation.");
            return;
        }

        if (this == null)
        {
            Debug.LogWarning("AudioManager instance is destroyed.");
            return;
        }

        theSFX = Instantiate(SFX[sfxNumber], Camera.main.transform);
        Invoke("DestroySfxGameObject", theSFX.GetComponent<AudioSource>().clip.length);
    }


    private void DestroySfxGameObject()
    {
        Destroy(theSFX);
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

}
