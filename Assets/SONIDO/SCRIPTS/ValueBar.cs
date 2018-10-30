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

    public void FillBar(float value)
    {
        if(fill < 100f) {
            fill += value;
        }
        

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
