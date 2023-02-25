using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escolha : MonoBehaviour
{
    public GameObject vc;
    GameObject chak;
    GameObject cross;
    GameObject shield;
    GameObject water;
    GameObject fire;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        chak = GameObject.FindWithTag("UiChak");
        cross = GameObject.FindWithTag("UiCross");
        shield = GameObject.FindWithTag("UiShield");
        water = GameObject.FindWithTag("UiWater");
        fire = GameObject.FindWithTag("UiFire");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        Subitens chi = player.GetComponent<Subitens>();
        if (chi.selec == 1){
                vc.transform.position = chak.transform.position;
            }
            if (chi.selec == 2){
                vc.transform.position = cross.transform.position;
            }
            if (chi.selec == 3){
                vc.transform.position = shield.transform.position;
            }
            if (chi.selec == 4){
                vc.transform.position = water.transform.position;
            }
            if (chi.selec == 5){
                vc.transform.position = fire.transform.position;
            }
        

    }
}
