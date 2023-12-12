using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    private bool Attack = false;
    private Vector3 moveDirection;
    private GameObject player;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        activeItem = Random.Range(0, items.Length);
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

            Instantiate(items[activeItem], transform.position, Quaternion.identity);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerStats>().maxHealth -= damage;
        }
    }

}
    
