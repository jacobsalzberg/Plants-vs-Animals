﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        //Creates a parent if necessary
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    private void Update()
    {
        if (isAttackingAheadInLane())
        {
            animator.SetBool("isAttacking", true);

        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    //Look through all spawners, and set myLaneSpawner if found
    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + "can't find spawner in lane");
    }

    bool isAttackingAheadInLane()
    {
        return false;    
    }
    
    private void Fire ()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;


    }

	
}
