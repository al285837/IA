﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	Transform player;
	//NavMeshAgent nav;
	public float distanceToAttack = 2f;
	ValueBar bar;

    public bool searching;
    public Transform target;
    float detectionSpeed = 5f;
    Character script;
    Animator anim;

 

	// Use this for initialization
	void Start () {
        bar = GetComponent<ValueBar>();
        script =  GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        
           


        //nav = GetComponent<NavMeshAgent> ();
        searching = false;
       // target.position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {


		

			if ((Vector3.Distance(player.position, this.transform.position) < distanceToAttack) && (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical") )  && script.speed >= detectionSpeed) {

                target.position = player.position;
                searching = true;
                //BARRA == 0
                if (bar.fill < 0.30f)
                    bar.BarToValue(.30f);
                bar.Bar.fillAmount = bar.fill;

                
 
              
			
			}

		


        if ((transform.position - target.position).magnitude <0.5f)
        {
            searching = false;
            //lookaround
        }

		
	}




    void SetAllFalse()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Running", false);
        anim.SetBool("Walking", false);
        anim.SetBool("Fire", false);
    }
}
