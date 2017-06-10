using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {


    public float fadeInTime;

    private Image fadePanel;
    private Color currentColor = Color.black;


    // Use this for initialization
    void Start () {

        fadePanel = GetComponent<Image>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime)
        {
            // Fade In
            //deltatime eh o tempo que foi levado para cumprir o ultimo frame
            //usar deltatime faz os tempos serem referentes ao tempo (em segundos), ao inves de
            // ser referentes ao tempo
            float alphaChange = Time.deltaTime / fadeInTime; //proporcao pelo frame
            currentColor.a -= alphaChange; //a significa alpha
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false); //desativar o gameobject
        }
	}
}
