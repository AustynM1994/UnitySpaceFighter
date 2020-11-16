using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject bullet;
    public GameObject target = GameObject.FindGameObjectWithTag("PlayerShip");
    private GameController gameController;

    // Use this for initialization
    void Start () {

        InvokeRepeating("ShootBullet", 2f, 1f);
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();

    }
	
	// Update is called once per frame
	void Update () {
        // Moves the ship towards the player
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("PlayerShip").transform.position, .03f);
        transform.LookAt(GameObject.FindGameObjectWithTag("PlayerShip").transform);

    }

    void ShootBullet ()
    {

        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

    }

    void OnCollisionEnter(Collision col)
    {

        //Collision with the players bullets triggers this
        if (col.gameObject.tag == "PlayerBullet")
        { 
            Destroy(this.gameObject);
            gameController.DecrementEnemies();
            //Add to the score
            gameController.IncrementScore();
        }
    }
}
