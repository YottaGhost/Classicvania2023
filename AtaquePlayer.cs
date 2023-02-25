using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public double MaxHp = 100;
    public double CurrentHp;

    public double recover;
    public double startup;
    public double stamina = 3;
    public bool block=false;
    public bool atacando = false;

    public Animator animator;
    GameObject Black;

    public GameObject balaprefab;
    public Transform firePoint;

    public double Cooldown = 0;
    public bool CooldownStart = false;
    void Start()
    {
        CurrentHp = MaxHp;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Cooldown <= 0) {
            Instantiate(balaprefab, firePoint.position, firePoint.rotation);
            CooldownStart = true;
            Cooldown = 0.3;
            atacando = true;
        }

        if (Input.GetButtonUp("Fire3") || stamina <= 0) {
                block = false;
                startup = 0.5;
            
        }
        if (Input.GetButtonDown("Fire3") && block == false && atacando == false && (startup <=0)){
            block = true;
        }  
        animator.SetBool("defedendo", block);
        startup -= 1 * Time.deltaTime;
        recover += 1 * Time.deltaTime;

        if (block == false && recover >= 3 && stamina < 3){
            stamina +=1;
            recover = 0;
        }

        if (Cooldown <= 0){
            atacando = false;
        }

        if (CooldownStart == true){
            Cooldown -= 1 * Time.deltaTime;
        }
    }
    
    public void TakeDamage(double damage)
    {
        if (block == false){
            CurrentHp -= damage;
            if (CurrentHp <= 0)
            {
            //canvas.SetActive(true);
                //Time.timeScale = 0;
                Black = GameObject.FindWithTag("BlackScreen");
                ImageController treco = Black.GetComponent<ImageController>();
                treco.isCoveringScreen = true;
            }
        } else{
            stamina -=1;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.tag == "HpUp")
        {
            MaxHp += 25;
            CurrentHp = MaxHp;
            Destroy(hitInfo.gameObject);
        }
    }
}
