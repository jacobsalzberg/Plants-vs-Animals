﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starText;
    private int stars = 100;
    public enum Status {SUCESS, FAILURE};


	// Use this for initialization
	void Start () {
        starText = GetComponent<Text>();
        UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars (int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCESS;
        }
        return Status.FAILURE;
    }
    

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
}
