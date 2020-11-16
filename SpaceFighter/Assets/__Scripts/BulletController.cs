using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Destroy itself after 1 seconds
        Destroy(gameObject, 2.0f);

        //Push the bullet in the direction it is facing
        GetComponent<Rigidbody>().AddForce(transform.up * 400);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
