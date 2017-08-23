using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody shot;

    public float speed;
   

	// Use this for initialization
	void Start () {

        shot = GetComponent<Rigidbody>();

        shot.velocity = transform.forward * speed;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
