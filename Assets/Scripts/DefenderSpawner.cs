﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject parent;


    private void Start()
    {
        parent = GameObject.Find("Defenders");

        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }
    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        //print("clicked"); //LEMBRAR ---> PRECISA DE COLLIDER PRA TER CLICK
        // print(SnapToGrid (CalculateWorldPointOfMouseClick()));
        //print("World position" + CalculateWorldPointOfMouseClick());
        GameObject defender = Button.selectedDefender;
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate(defender, roundedPos, zeroRot) as GameObject;

        newDef.transform.parent = parent.transform;

    }

    Vector2 SnapToGrid (Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
