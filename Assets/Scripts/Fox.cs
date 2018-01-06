using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// protection mecanism
[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
        void OnTriggerEnter2D (Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        // Leave the method if not colliding with defender
        if (!obj.GetComponent<Defender>()) //se n eh um defensor, o que fazer?
        {
            //Debug.Log("voltei");
            return;
        }
        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jump trigger");
        } else
        {
            anim.SetBool("IsAttacking", true);
            attacker.Attack (obj);
        }

            Debug.Log("fox collided with" + collider);
    }
}
