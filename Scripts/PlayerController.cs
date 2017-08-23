using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody ship;
    public float speed;

    public AudioSource fire;

    public Boundary boundary;
    public float tilt;

    public GameObject shot;

    // fire rate determines the rate at which we fire, in a way that we dont continously fire like a machine gun.
    public float fireRate;
    float nextFire = 0;

    /* using the shotSpawn game object as a fixed place from where we fire the bullet, more like a virtual gun.
     gives us an initial position from where to fire the bolt, to help with the instantite function.
    */
    public Transform shotSpawn; // transform variable directly uses transform component of game object!
   

	// Use this for initialization
	void Start () {

        ship = GetComponent<Rigidbody>();
        fire = GetComponent<AudioSource>();
        		
	}

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            GameObject shotFired = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            fire.Play();
            nextFire = Time.time + fireRate;
            /*
            Vector3 shotPos = shotFired.transform.position;

            if(shotPos.z > 15.4)
            {
                shotFired.gameObject.SetActive(false);
            }
            */
        }
    }

    // Called just before a fixed physics step
    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // adds velocity to the player ship
        ship.velocity = movement * speed;

        // Restricts the area in which the player ship's moves
        ship.position = new Vector3

            (
                Mathf.Clamp(ship.position.x, boundary.xMin, boundary.xMax ),
                0.0f,
                Mathf.Clamp(ship.position.z, boundary.zMin, boundary.zMax )
            
            );

        // Rotates the ship simultaneously while we move it to give it a 3D effect
        // Quaternion.Euler used to rotate a game object in degrees. (x, y, z) where x, y, and z are in degrees
        ship.rotation = Quaternion.Euler(0.0f, 0.0f, ship.velocity.x * -tilt);


       
		
	}
}
