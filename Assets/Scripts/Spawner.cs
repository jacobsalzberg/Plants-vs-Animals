﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn (thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn (GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    bool isTimeToSpawn (GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        //time.deltatime --> how long the frame took


        //spawnar mais rapido que a taxa de quadros, a
        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rape capped by frame rate");
        }

        // limite do spawn
        float threshold = spawnsPerSecond * Time.deltaTime / 5 ;  //5 lanes

        if (Random.value < threshold)
        {
            return true;
        } else
        {
            return false;
        }


        //return true;
    }



}