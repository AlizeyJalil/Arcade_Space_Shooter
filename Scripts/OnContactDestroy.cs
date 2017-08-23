using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnContactDestroy : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    public void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        else
            Debug.Log("GameController object not found!");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Boundary")) {

            Instantiate(explosion, transform.position, transform.rotation);

            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.gameOver();
            }

            gameController.AddScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
 
        }
        
    }
}
