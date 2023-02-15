using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chakran : MonoBehaviour
{
    public GameObject vc;

    public double damage = 15;
    public int nivel = 0;

    public GameObject balaS;
    public GameObject balaprefab;
    public GameObject balaprefab1;
    public Transform firePoint;
    public float Speed = 0f;
    public double maxCooldown;
    public double Cooldown = 0;

    public int upado = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Cooldown += 1 * Time.deltaTime;
        if (Cooldown >= maxCooldown)
        {
            Shoot();
            Cooldown = 0;
        }
        if (upado == 1)
        {
            Upgrade();
            upado = 0;
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, Random.Range(1, 3));
    }

    void Shoot()
    {
        if (nivel > 0)
        {
            Instantiate(balaprefab, firePoint.position, firePoint.rotation);
        }
    }
    public void Upgrade()
    {
        damage = 15 + (5 * nivel);
        if (nivel == 4)
        {

            damage = 40;

        }
        if (nivel == 5)
        {
           
            damage = 47;
            Speed = 1f;
        }
        if (nivel == 6)
        {
            damage = 50;
           
        }
        if (nivel == 7)
        {
            Speed = 3f;
            damage = 60;
        }
    }
}
