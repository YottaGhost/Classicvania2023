using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodar : MonoBehaviour
{
    public GameObject vc;
    public double cooldown;
    public bool cdStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float rotacao;
    // Update is called once per frame
    void Update()
    {
        if (cdStart == true){
            cooldown += 1 *Time.deltaTime;
        }
        if (cooldown >= 4.5){
            cdStart = false;
            vc.SetActive(false);
            cooldown = 0;
        }

        rotacao = 0.5f;
        transform.Rotate(0f, 0, rotacao);
    }
}
