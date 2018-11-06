using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraValueBar : MonoBehaviour
{

    public Image Bar;
    public float fill;


    // Use this for initialization
    void Start()
    {

        fill = 0f;
        

    }

    // Update is called once per frame
    void Update()
    {

        
        
        if (fill >= 1f)
        {
            //te puto mata pringao
            //alarma, todo los targets a ti
        }

    }

    public void FillBar(float value)
    {
        if (fill < 1f)
        {
            fill += value;
        }
        if (fill < 0f)
            EmptyBar();

    }
    public void DecreaseBar(float value)
    {
        if (fill > 0f)
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

