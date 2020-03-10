using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class make : MonoBehaviour
{

    public bool light = true;
    [Space]
    public GameObject glass_floor;
    public GameObject glass_front;
    public GameObject glass_back;
    public GameObject glass_left;
    public GameObject glass_right;

    [Header("aqua size cm")]
    public float glass_size = 0.4f;
    [Space(3)]
    public float aqua_out_x = 10f;
    public float aqua_out_y = 10f;
    public float aqua_out_z = 10f;

    [Header("fulfillment cm")]
    public GameObject water;
    public float water_level = 2f;
    [Space]
    public GameObject solid;
    public float solid_A = 2f;
    public float solid_B = 2f;
    [Space]
    public Slider glass_value_slider;
    public Slider x_out_value_slider;
    public Slider y_out_value_slider;
    public Slider z_out_value_slider;
    public Slider V_water_value_slider;
    public Slider V_solid_A_value_slider;
    public Slider V_solid_B_value_slider;
    [Space]
    public GameObject V_aqua_out_value_view;
    public GameObject V_aqua_in_value_view;
    public GameObject V_water_value_view;
    public GameObject V_solid_value_view;
    [Space(3)]
    public GameObject glass_value_view;
    public GameObject x_out_value_view;
    public GameObject y_out_value_view;
    public GameObject z_out_value_view;
    public GameObject water_level_view;
    public GameObject solid_A_view;
    public GameObject solid_B_view;

    public Vector3 newVerts;

    private float aqua_in_x;
    private float aqua_in_y;
    private float aqua_in_z;
    private float water_level_h;

    private float volume_all_out;
    private float volume_all_in;
    private float volume_water;
    private float volume_solid;

    private double volume_all_out_d;
    private double volume_all_in_d;
    private double volume_water_d;
    private double volume_solid_d;


    public void slider_glass_size(float newValueG)
    {
        glass_size = newValueG / 10;
    }


    public void slider_x_size(float newValueX)
    {
        aqua_out_x = newValueX;
    }


    public void slider_y_size(float newValueY)
    {
        aqua_out_y = newValueY;
    }


    public void slider_z_size(float newValueZ)
    {
        aqua_out_z = newValueZ;
    }


    public void slider_water_level(float newValueWater)
    {
        water_level = newValueWater;
    }


    public void slider_solid_A(float newValueSolidA)
    {
        solid_A = newValueSolidA;
    }


    public void slider_solid_B(float newValueSolidB)
    {
        solid_B = newValueSolidB;
    }


    public void show_text()
    {
        glass_value_view.GetComponent<Text>().text = "grubość szkła: " + glass_size.ToString() + " cm";
        x_out_value_view.GetComponent<Text>().text = "szerokość: " + aqua_out_x.ToString() + " cm";
        y_out_value_view.GetComponent<Text>().text = "głębokość: " + aqua_out_y.ToString() + " cm";
        z_out_value_view.GetComponent<Text>().text = "wysokość: " + aqua_out_z.ToString() + " cm";
        water_level_view.GetComponent<Text>().text = "do wody od góry: " + water_level.ToString() + " cm";
        solid_A_view.GetComponent<Text>().text = "podłoże przód: " + solid_A.ToString() + " cm";
        solid_B_view.GetComponent<Text>().text = "podłoże tył: " + solid_B.ToString() + " cm";

        V_aqua_out_value_view.GetComponent<Text>().text = " " + volume_all_out_d.ToString() + " l.";
        V_aqua_in_value_view.GetComponent<Text>().text = "poj.: " + volume_all_in_d.ToString() + " l.";
        V_water_value_view.GetComponent<Text>().text = "wody: " + volume_water_d.ToString() + " l.";
        V_solid_value_view.GetComponent<Text>().text = "podłoża: " + volume_solid_d.ToString() + " l.";

    }

    public void set_slider()
    {
        glass_value_slider.value = glass_size * 10;
        x_out_value_slider.value = aqua_out_x;
        y_out_value_slider.value = aqua_out_y;
        z_out_value_slider.value = aqua_out_z;
        V_water_value_slider.value = water_level;
        if (solid_A >= solid_B)
        {
            V_water_value_slider.maxValue = aqua_in_z - solid_A;
        }
        else
        {
            V_water_value_slider.maxValue = aqua_in_z - solid_B;
        }

        V_solid_A_value_slider.value = solid_A;
        V_solid_B_value_slider.value = solid_B;
    }


    // Start is called before the first frame update 
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        // obliczenia wnetrza 
        aqua_in_x = aqua_out_x - 2 * glass_size;
        aqua_in_y = aqua_out_y - 2 * glass_size;
        aqua_in_z = aqua_out_z - glass_size;


        // ustawienie wielkości szyb
        glass_floor.transform.localScale = new Vector3(aqua_out_x, glass_size, aqua_out_y);
        glass_front.transform.localScale = new Vector3(aqua_out_x, aqua_out_z, glass_size);
        glass_back.transform.localScale = new Vector3(aqua_out_x, aqua_out_z, glass_size);
        glass_left.transform.localScale = new Vector3(glass_size, aqua_out_z, (aqua_out_y) - 2 * glass_size);
        glass_right.transform.localScale = new Vector3(glass_size, aqua_out_z, (aqua_out_y) - 2 * glass_size);

        // ustawienie położenia szyb
        glass_floor.transform.localPosition = new Vector3(0, -aqua_out_z / 2 + glass_size / 2, 0);
        glass_front.transform.localPosition = new Vector3(0, glass_size, (-aqua_out_y / 2) + glass_size / 2);
        glass_back.transform.localPosition = new Vector3(0, glass_size, (aqua_out_y / 2) - glass_size / 2);
        glass_left.transform.localPosition = new Vector3((-aqua_out_x / 2) + glass_size / 2, glass_size, 0);
        glass_right.transform.localPosition = new Vector3((aqua_out_x / 2) - glass_size / 2, glass_size, 0);

        //obliczenia wysokości wody    
        water_level_h = aqua_out_z - water_level;

        // ustawienie wielkości i położenia wody
        water.transform.localScale = new Vector3(aqua_in_x - 0.01f, water_level_h - 0.01f, aqua_in_y - 0.01f);
        water.transform.localPosition = new Vector3(0, -aqua_out_z / 2 + glass_size + water_level_h / 2, 0);


        // ustawienie wielkości i położenia podłoża
        solid.transform.localScale = new Vector3(aqua_in_x - 0.02f, solid_A - 0.02f, aqua_in_y - 0.02f);
        solid.transform.localPosition = new Vector3(0, -aqua_out_z / 2 + glass_size + solid_A / 2, 0);


        //oblicza pojemnośći   Mathf.Round(value);
        volume_all_out = (aqua_out_x * aqua_out_y * aqua_out_z) / 1000;
        volume_all_out_d = Math.Round(volume_all_out, 0);

        volume_all_in = (aqua_in_x * aqua_in_y * aqua_in_z) / 1000;
        volume_all_in_d = Math.Round(volume_all_in, 1);

        //volume_solid = (aqua_in_x * aqua_in_y * solid_A) / 1000;
        volume_solid = ((((solid_B - solid_A) * aqua_in_y * 0.5f) + (aqua_in_y * solid_A)) * aqua_in_x) / 1000;
        volume_solid_d = Math.Round(volume_solid, 1);


        volume_water = volume_all_in - ((aqua_in_x * aqua_in_y * water_level) / 1000) - volume_solid;
        if (volume_water <= 0) volume_water = 0;
        volume_water_d = Math.Round(volume_water, 1);

        show_text();
        set_slider();

        if (solid_A != 0 || solid_B != 0)
        {
            Debug.Log("jest podłoże");
            solid.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("brak podłoża");
            solid.gameObject.SetActive(false);
        }


        if (water_level >= aqua_in_z)
        {
            Debug.Log("brak wody");
            water.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("jest woda");
            water.gameObject.SetActive(true);
        }

     



    }
}
