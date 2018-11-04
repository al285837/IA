using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float speed;
    public Vector3 direccion;
    bool crouched;


    // Use this for initialization
    void Start () 
	{
        crouched = false;
		speed = 5f;
        direccion = new Vector3(0,0,0);

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("v"))
        {
            if (crouched) crouched = false;
            else crouched = true;
        }

        if (crouched) speed = 2f;
        else speed = 5f;
        direccion = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

  

        transform.Translate ((direccion) * speed*Time.deltaTime);
		
	}
}
