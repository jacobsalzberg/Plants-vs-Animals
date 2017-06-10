using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    private void Awake()
    {
        if (autoLoadNextLevelAfter == 0)
        {
        }
        //print(SceneManager.GetActiveScene().buildIndex);
        Invoke("LoadTitle", autoLoadNextLevelAfter);
        
        //SceneManager.LoadScene("01a Start");
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load load: " + name);
        SceneManager.LoadScene(name);
    }
    public void LoadNextLevel()
    {
        //print(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("load next level: " + name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //level index
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitRequest()
    {
        Debug.Log("Quit request");
        Application.Quit();

    }
}