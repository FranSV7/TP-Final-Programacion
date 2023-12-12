using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [Header("Stats Player")]
    public int exp = 0;
    public int maxHealth = 100;

    [Header("Sliders")]
    public Slider sliderExp;
    public Slider sliderHealth;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHealth.GetComponent<Slider>().value = maxHealth;
        sliderExp.GetComponent<Slider>().value = exp;
    }
}
