using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x > 22)
        {

            transform.position = new Vector3(-22, transform.position.y, 0);

        }
        else if (transform.position.x < -22)
        {
            transform.position = new Vector3(22, transform.position.y, 0);
        }

        else if (transform.position.y > 12)
        {
            transform.position = new Vector3(transform.position.x, -12, 0);
        }

        else if (transform.position.y < -12)
        {
            transform.position = new Vector3(transform.position.x, 12, 0);
        }
    }
}
