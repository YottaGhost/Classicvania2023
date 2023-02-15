using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoteTiro : MonoBehaviour
{
    GameObject player;
    public double dano;
    public double vida;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
        dano = 35;

        vida += 1 * Time.deltaTime;
        if (vida >= 0.2)
        {
            Destroy(gameObject);
        }
    }
}
