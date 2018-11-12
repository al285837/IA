using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour {

	public Image Bar;
	public float fill;
    Unit pathfinding;

    Animator anim;

	// Use this for initialization
	void Start () {

		fill = 0f;
        pathfinding = GetComponent<Unit>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        pathfinding.speed = 3f;

        SetAllFalse();
        anim.SetBool("Idle", true);

        if (fill>=.25f)
        {
            pathfinding.speed = 3f;
            SetAllFalse();
            anim.SetBool("Walking", true);

        }

        if (fill >= .6f)
        {
            pathfinding.speed = 6f;
            SetAllFalse();
            anim.SetBool("Running", true);
        }
        if (fill >= 1f)
        {
            //te puto mata pringao
            SetAllFalse();
            anim.SetBool("Fire", true);
        }

    }

    public void FillBar(float value)
    {
        if(fill < 1f) {
            fill += value;
        }
        if (fill < 0f)
            EmptyBar();

    }
    public void DecreaseBar (float value)
    {
        if(fill > 0f)
        {
            fill -= value;
        }
        if (fill < 0f)
            EmptyBar();
    }
    public void EmptyBar()
    {
        fill = 0f;
    }

    public void BarToValue(float value)
    {
        fill = value;
    }


    void SetAllFalse()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Running", false);
        anim.SetBool("Walking", false);
        anim.SetBool("Fire", false);
    }
}
