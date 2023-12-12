using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinExp : MonoBehaviour
{
    public int expCoin;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerStats>().exp += expCoin;
            Destroy(gameObject);
        }
    }

}
