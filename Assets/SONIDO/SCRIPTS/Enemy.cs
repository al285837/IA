using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	public float distanceToAttack = 2f;
	public ValueBar bar;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (player.position, this.transform.position) < distanceToAttack ) {

			if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			
				if (bar.fill >= 1) {
					nav.SetDestination (player.position);
					nav.Resume ();
				} else {

					bar.fill += Time.deltaTime * 0.2f;
					bar.Bar.fillAmount = bar.fill;

				}
			
			}



		} else {

			if (bar.fill >= 1) {
				nav.SetDestination (player.position);
				nav.Resume ();
			}

			if (bar.fill == 0) {

				bar.fill = 0f;
				nav.Stop ();

			} else {

				bar.fill -= Time.deltaTime * 0.1f;
				bar.Bar.fillAmount = bar.fill;

			}


		}
			
		
	}
}
