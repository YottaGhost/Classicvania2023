using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public GameObject player;
    GameObject jogador;
    public double hp = 100;
    public Rigidbody2D rb;
    Transform target;
    public float _moveSpeed = 2f;
    public Transform firePoint;
    public GameObject xpprefab;
    public double Cooldown = 0;
    public Vector2 knock;
    public float dano;
    public double CooldownKnock;
    void Start()
    {
        
    }

    
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovement>();
        target = player.transform;
        if (CooldownKnock >= 0.3)
        {
            Vector2 direction = target.position - transform.position;
            direction = direction.normalized;
            Vector2 velocity = direction * _moveSpeed;
            rb.velocity = velocity;
        }
        Cooldown += 1 * Time.deltaTime;
        CooldownKnock += 1 * Time.deltaTime;
    }
    public void TakeDamage (double damage)
    {
        if (CooldownKnock >= 1.50)
        {
            Vector2 moveDir = rb.transform.position - player.transform.position;
            rb.velocity = moveDir.normalized * _moveSpeed;
            
            CooldownKnock = 0;
        }
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
    public GameObject quantidade;
    void Die()
    {
        Instantiate(xpprefab, firePoint.position, firePoint.rotation);
        Destroy(gameObject);
        //quantidade = GameObject.FindWithTag("controlador");
        //controlador con = quantidade.GetComponent<controlador>();
        //con.Quantidade -= 1;
    }

    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
     //   movimento jogador = hitInfo.GetComponent<movimento>();
       /// if (jogador != null)
        //{
         ///   jogador.TakeDamage(dano);
       ///     Cooldown = 0;
       // }

   // }
    //void OnTriggerStay2D(Collider2D hitInfo)
    //{
      //  movimento jogador = hitInfo.GetComponent<movimento>();
       // if (jogador != null)
        //{
          //  if (Cooldown >= 2)
            //{
              //  jogador.TakeDamage(dano);
                //Cooldown = 0;
            //}
        //}
    //}

}
