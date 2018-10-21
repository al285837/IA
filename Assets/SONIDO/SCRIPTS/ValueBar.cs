using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour {

	public Image Bar;
	public float fill;

	// Use this for initialization
	void Start () {

		fill = 0f;

	}
	
	// Update is called once per frame
	void Update () {

		//fill += Time.deltaTime * 0.1f;
		//Bar.fillAmount = fill;
		
	}
}
