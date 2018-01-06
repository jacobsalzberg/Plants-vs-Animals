using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {


    private float currentSpeed;
    private GameObject currentTarget;
    // podia colocar range separado

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + "trigger enter");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //called from the animator at time of actual blow
    public void StrikeCurrentTarget (float damage)
    {
       
    }

    public void Attack(GameObject obj){
        currentTarget = obj;

    }

}
