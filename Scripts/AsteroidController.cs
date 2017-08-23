using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public float tumble;
    private Rigidbody ast;
    // Update is called once per frame

    void Start() {

        ast = GetComponent<Rigidbody>();

        ast.angularVelocity = Random.insideUnitSphere * tumble;
    }

    void Update () {


        
       // Vector3 rot = new Vector3(45, 20, 10);

        

	}
}
