using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniBala : MonoBehaviour
{

    public float speed = 6f;
    public Rigidbody2D rb;
    public double dano;
    public double vida;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        AtaquePlayer jogador = hitInfo.gameObject.GetComponent<AtaquePlayer>();
            if (jogador != null)
            {
                jogador.TakeDamage(dano);
                Destroy(gameObject);
            }
    }
    // Update is called once per frame
    void Update()
    {
        vida += 1 * Time.deltaTime;
        if (vida >= 4)
        {
            Destroy(gameObject);
        }
    }
}
