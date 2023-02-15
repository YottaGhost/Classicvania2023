using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Vector3 pos;
    public double cooldown;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += 1 * Time.deltaTime;
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
        {
                inimigo enemy = hitInfo.GetComponent<inimigo>();
                if (enemy != null)
                {
                    enemy.TakeDamage(20);
                }
        }
}
