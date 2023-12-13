using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text killsText;
    public TMP_Text time;
    public int kills = 0;
    public GameObject winUI;
    public GameObject powerUps;
    public PlayerStats playerStats;
    public Weapon fireRate;
    public BulletDestroy bullet;


    private float maxTime = 300f;
    private float leftTime;
    private bool activeTime = true;
    private bool inGame = false;


    void Start()
    {
        leftTime = maxTime;
        winUI.SetActive(false);
        powerUps.SetActive(false);
        
    }

    void Update()
    {
        if (activeTime)
        {
            leftTime -= Time.deltaTime;

            if (leftTime <= 0)
            {
                leftTime = 0;
                activeTime = false;
                Win();
            }
            UpdateTime();
        }

    }

    void UpdateTime()
    {
        int minutes = Mathf.FloorToInt(leftTime / 60);
        int seconds = Mathf.FloorToInt(leftTime % 60);

        string tiempoTexto = string.Format("{0:00}:{1:00}", minutes, seconds);

        time.text = tiempoTexto;
    }

    void Win()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UpdateKills()
    {
        kills++;
        UpdateKillText();
    }
    void UpdateKillText()
    {
        if (killsText != null)
        {
            killsText.text = kills.ToString();
        }
    }
    public void ResumeGame()
    {
        if (inGame == false)
        {
            powerUps.SetActive(false);
            Time.timeScale = 1f;
            inGame = true;
        }
    }


    public void PowerUps()
    {
        Time.timeScale = 0f;
        powerUps.SetActive(true);
    }

    public void ApplyDamagePowerUp(int damageIncrease)
    {
        if (bullet != null)
        {
            bullet.bulletDamage += damageIncrease; // Incrementa el daño del proyectil
            Debug.Log("Daño del proyectil aumentado a: " + bullet.bulletDamage);
        }
        else
        {
            Debug.LogWarning("No se encontró el componente BulletDestroy en el GameObject.");
        }
        ResumeGame();
    }

    public void MaxHealth()
    {
        
    }
    
    public void MoreSpeed()
    {
        
    }


}
