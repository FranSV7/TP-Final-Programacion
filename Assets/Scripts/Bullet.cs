using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [Header("Hit Effect")]
    [SerializeField] private GameObject hitEffect;

    [Header("Stats Bullet")]
    public int bulletDamage = 0;

    void Start()
    {
        bulletDamage = 10;
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health -= bulletDamage;
        }

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        Destroy(gameObject);

    }
}
