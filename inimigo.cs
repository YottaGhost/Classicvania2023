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
    public bool virar = false;

    public GameObject Bala;

    public bool eAtirador;
    public bool playerLonge;
    
    public double tiroColMax;
    private double tiroCol;

    public bool isEye;

    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
    if (isEye == false ){
        if (playerLonge == true){
        rb.velocity = transform.right * _moveSpeed;
        }

        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovement>();
        target = player.transform;
        if (CooldownKnock >= 0.3)
        {
            //Vector2 direction = target.position - transform.position;
            //direction = direction.normalized;
           // Vector2 velocity = direction * _moveSpeed;
            //rb.velocity = velocity;
        }
        Cooldown += 1 * Time.deltaTime;
        CooldownKnock += 1 * Time.deltaTime;
    
        if (tiroCol <= 0 && playerLonge == false && eAtirador==true){
            tiroCol = tiroColMax; 
            Instantiate(Bala, firePoint.position, firePoint.rotation);
        }
    }
        if (virar == true){
            transform.Rotate(0f, 180f, 0f);
            virar = false;
        }

        tiroCol -= 1*Time.deltaTime;
    

    if (isEye) {
        
        // Calcula a posição do inimigo com base no tempo e na amplitude e frequência especificadas
        Vector3 position = transform.position;
        float sin = Mathf.Sin((Time.time - startTime) * frequency);
        rb.velocity = transform.right * _moveSpeed;
        position.y = sin * amplitude;
        transform.position = position;
    
    }
    }

    public float amplitude = 2f; // Amplitude do movimento sinuoso
    public float frequency = 1f; // Frequência do movimento sinuoso
    private float startTime; // Tempo de início do movimento sinuoso

    public bool direita = true;

    public void TakeDamage (double damage)
    {
        tiroCol = tiroColMax; 
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

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        AtaquePlayer jogador = hitInfo.gameObject.GetComponent<AtaquePlayer>();
            if (jogador != null)
            {
                jogador.TakeDamage(dano);
                Cooldown = 0;
            }
    }
    void OntriggerEnter2D(Collider2D hitInfo)
    {
        AtaquePlayer jogador = hitInfo.gameObject.GetComponent<AtaquePlayer>();
            if (jogador != null)
            {
                jogador.TakeDamage(dano);
                Cooldown = 0;
            }
    }
    void OnCollisionStay2D(Collision2D hitInfo)
    {
        AtaquePlayer jogador = hitInfo.gameObject.GetComponent<AtaquePlayer>();
        if (jogador != null)
        {
            if (Cooldown >= 2)
            {
                jogador.TakeDamage(dano);
                Cooldown = 0;
            }
        }
    }

}
