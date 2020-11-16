using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    float rotationSpeed = 100.0f;
    float thrustForce = 3f;

    public GameObject bullet;

    private GameController gameController;

    void Start()
    {
        //Get a reference to the game controller object and the script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void FixedUpdate()
    {

        //Rotate the ship
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        //Moves ship forward
        GetComponent<Rigidbody>().AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));
        
        //Fire bullet
        if (Input.GetMouseButtonDown(0))ShootBullet();

    }

    void OnCollisionEnter(Collision col)
    {

        //Collision with anything but players own bullets triggers this
        if (col.gameObject.tag != "PlayerBullet")
        {
            //Moves the ship to the centre of the screen
            transform.position = new Vector3(0, 0, 0);

            //Removes speed from the ship
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            gameController.DecrementLives();
        }
    }

    void ShootBullet()
    {

        //Spawns a player bullet
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, 0), transform.rotation);

    }
}