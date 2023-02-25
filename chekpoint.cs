using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chekpoint : MonoBehaviour
{
    public bool Pai;
    GameObject pai;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pai == false){
            pai = GameObject.FindWithTag("Check");
            chekpoint treco = pai.GetComponent<chekpoint>();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        if (Pai == false){
        chekpoint treco = pai.GetComponent<chekpoint>();
        if(hitInfo.tag == "Player"){
            
            treco.pos = hitInfo.transform.position;
        }
        }
    }
}
