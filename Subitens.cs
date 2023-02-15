using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subitens : MonoBehaviour
{
    public GameObject ChakranPrefab;
    public GameObject WaterPrefab;
    public GameObject CrossPrefab;
    public GameObject FirePrefab;
    public Transform firePoint;

    GameObject shield;
    public int selec = 1;
    public int maxSec =1;

    public double Cooldown = 0;
    public bool CooldownStart = false;
    void Start()
    {
        shield = GameObject.FindWithTag("Shield");
        
        shield.SetActive(false);
    }

    void Update()
    {
        //Verifica qual subweapon ta ativa e chama a funçao da mesma, pra spawnar ela
        if (Input.GetButtonDown("Fire2") && Cooldown <= 0) {
            if (selec == 1){
                Chakran();
            }
            if (selec == 2){
                Cross();
            }
            if (selec == 3){
                SacredShield();
            }
            if (selec == 4){
                SacredWater();
            }
            if (selec == 5){
                SacredFire();
            }
        }

        //Aumenta ou diminui qual a subweapon ta ativa, basicamente troca ao apertar q e e
        if (Input.GetButtonDown("ShoulderPos") && (selec <=maxSec)){
            selec +=1; 
            if (maxSec < selec){
                selec = 1;
            }
        }
        if (Input.GetButtonDown("ShoulderNeg")){
            selec -=1; 
            if (selec <= 0){
                selec = maxSec;
            }
        }

        

        //cooldown pra n ser spamevel, provavelmente sera o mesmo em todas as armas
        if (CooldownStart == true){
            Cooldown -= 1 * Time.deltaTime;
        }
    }
    void Chakran(){
        //chakran, vai pra frente e dps volta   
            Instantiate(ChakranPrefab, firePoint.position, firePoint.rotation);
            CooldownStart = true;
            Cooldown = 4;
        
    }
    void Cross(){

    }
    void SacredShield(){
            Rodar chi = shield.GetComponent<Rodar>();
            chi.cdStart = true;
            shield.SetActive(true);
            CooldownStart = true;
            Cooldown = 4;
    }
    void SacredWater(){

    }
    void SacredFire(){
        Instantiate(FirePrefab, firePoint.position, firePoint.rotation);
            CooldownStart = true;
            Cooldown = 3.5;
    }
    
}
