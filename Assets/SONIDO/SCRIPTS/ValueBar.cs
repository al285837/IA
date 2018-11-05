using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour {

	public Image Bar;
	public float fill;
    Unit pathfinding;

	// Use this for initialization
	void Start () {

		fill = 0f;
        pathfinding = GetComponent<Unit>();

	}
	
	// Update is called once per frame
	void Update () {

        pathfinding.speed = 3f;

		if (fill>=.25f)
        {
            pathfinding.speed = 3f;
        }

        if (fill >= .6f)
        {
            pathfinding.speed = 6f;
        }
        if (fill >= 1f)
        {
            //te puto mata pringao
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
}
