using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross : MonoBehaviour
{

    public double dano;
    public double vida;
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.velocity = transform.right * 3f;
        rb2D.AddForce(transform.up * 700f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        inimigo enemy = hitInfo.GetComponent<inimigo>();
        if (enemy != null)
        {
            enemy.TakeDamage(dano);

            
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        //chakran chak = player.GetComponent<chakran>();
        dano = 35 ;//chak.damage;

        
        vida += 1 * Time.deltaTime;
        if (vida >= 4)
        {
            Destroy(gameObject);
        }
    }
    }

