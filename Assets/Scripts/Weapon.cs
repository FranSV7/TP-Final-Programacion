using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float fireTime;
    // Start is called before the first frame update
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireSpeed, ForceMode2D.Impulse);

        Destroy(bullet, 2);


    }

        // Update is called once per frame
        void Update()
    {
        if (Time.time >= fireTime)
        {
            fireTime = Time.time + 0.5f;
            Fire();
        }
    }

}
