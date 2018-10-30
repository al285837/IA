using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float speed;
    public Vector3 direccion;


    // Use this for initialization
    void Start () 
	{

		speed = 5f;
        direccion = new Vector3(0,0,0);

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("v")) speed = 2f;
        else speed = 5f;
        direccion = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

  

        transform.Translate ((direccion) * speed*Time.deltaTime);
		
	}
}
