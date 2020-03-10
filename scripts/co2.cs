using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class co2 : MonoBehaviour
{
    public GameObject co_view;
    //public GameObject kh_in;
    //public GameObject ph_in;

    private double co;
    public double kh;
    public double ph;


    public void count(bool count_co2)
    {
        co = 3d * kh * Math.Pow(10, (7d - ph));
        co = Math.Round(co, 2);
        co_view.GetComponent<Text>().text = "" + co.ToString();
    }

    public void kh_changed(string new_kh)
    {
        kh = double.Parse(new_kh);
    }

    public void ph_changed(string new_ph)
    {
        ph = double.Parse(new_ph);
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
