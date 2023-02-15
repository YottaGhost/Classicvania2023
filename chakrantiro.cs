using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chakrantiro : MonoBehaviour
{

    public float rodaroda;
    public float speed = 6f;
    public Rigidbody2D rb;
    //GameObject player;
    public double dano;
    public double vida;
    public bool rotado = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        //player = GameObject.FindWithTag("chakram");
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
    void FixedUpdate()
    {

        if ((vida >=1.7) && (rotado == false))
        {
            transform.Rotate(0f, 0f, 180f);
            rb.velocity = transform.right * speed;
            
            rotado = true;
        }

        //chakran chak = player.GetComponent<chakran>();
        dano = 20 ;//chak.damage;

        
        vida += 1 * Time.deltaTime;
        if (vida >= 4)
        {
            Destroy(gameObject);
        }
    }
}
