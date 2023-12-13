using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public GameManager manager;

    [Header("Stats Player")]
    public int exp = 0;
    public int maxHealth = 100;
    public int lvl;

    [Header("Sliders")]
    public Slider sliderExp;
    public Slider sliderHealth;

    private int expMax;
    

    void Start()
    {
        expMax = 1000;
        lvl = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHealth.GetComponent<Slider>().value = maxHealth;
        sliderExp.GetComponent<Slider>().value = exp;
        sliderExp.GetComponent<Slider>().maxValue = expMax;
        LevelUp();
    }

    public void LevelUp()
    {
        if(exp >= expMax)
        {
            lvl++;
            exp = exp - expMax;
            expMax += 200;
            manager.GetComponent<GameManager>().PowerUps();
        }
    }


}
