using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float levelSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        //PRECISA COLOCAR O GAMEOBJECT JA QUE ESTA EM OUTRO OBJETO!!
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FindYouWin();
        winLabel.SetActive(false);
    }

    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("PLZ CREATE YOU WIN OBJECT");
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (Time.timeSinceLevelLoad / levelSeconds);
    
    bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel);
    if  (timeIsUp && !isEndOfLevel)
        {
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
    }

    void LoadNextLevel ()
    {
        levelManager.LoadNextLevel();
    }

} 

