using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load:" + name);
        Debug.Log("awake");
    }
    
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("start");

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("enable");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("Disable");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        //scene.buildIndex is the level int used in the lesson
         Debug.Log("Playing Clip" + levelMusicChangeArray[scene.buildIndex]);

        if (thisLevelMusic) // if there's some music attached
        {
            print("tem musica");
            audioSource.clip = thisLevelMusic; //atribue o audiosource
            audioSource.loop = true;
            audioSource.Play();
         
        }
    }

    public void SetVolume (float volume)
    {
        audioSource.volume = volume;
    }

}
