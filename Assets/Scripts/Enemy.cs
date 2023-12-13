using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{

    [Header("Drop Items")]
    public GameObject[] items;
    int activeItem;
    
    [Header("Stats Enemy")]
    public int health;
    public int damage;
    public int moveSpeed = 5;

    [Header("Health Slider")]
    public Slider healthSlider;

    private SpriteRenderer enemyRender;
    private bool Attack = false;
    private Vector3 moveDirection;
    private GameObject player;
    private GameObject enemyCounts;
    public GameManager gameManager;

    private Vector3 enemyPosition;
   



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        activeItem = Random.Range(0, items.Length);
        enemyCounts = GameObject.FindWithTag("SpawnManager");
        enemyPosition = transform.position;
        enemyRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!Attack)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            moveDirection = (player.transform.position - transform.position).normalized;

        }

        healthSlider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);

            gameManager.UpdateKills();

            enemyCounts.GetComponent<SpawnEnemies>().enemyCount -= 1;

            Instantiate(items[activeItem], transform.position, Quaternion.identity);   
        }
        Vector3 direccionMovimiento = transform.position - enemyPosition;

        if (direccionMovimiento.x > 0) // Si se está moviendo a la derecha
        {
            enemyRender.flipX = false; // No voltear el sprite
        }
        else if (direccionMovimiento.x < 0) // Si se está moviendo a la izquierda
        {
            enemyRender.flipX = true; // Voltear el sprite horizontalmente
        }

        enemyPosition = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerStats>().maxHealth -= damage;
        }
    }
}
    
