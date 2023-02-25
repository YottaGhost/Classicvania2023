using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verificarParedes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool verificadorDeParedes;
    public bool detect;
    // Update is called once per frame
    public void Update()
    {
        inimigo ini = transform.parent.gameObject.GetComponent<inimigo>();

    }
    
    void OnTriggerStay2D(Collider2D hitInfo)
    {
        inimigo ini = transform.parent.gameObject.GetComponent<inimigo>();
        if (verificadorDeParedes == true){
            if(hitInfo.gameObject.layer == 6){
                ini.virar = true;
            }
        }
        if (detect == true){
            AtaquePlayer play = hitInfo.GetComponent<AtaquePlayer>();
            if (play != null){
                ini.playerLonge = false;
            }else {ini.playerLonge = true;}
        }
    }
}
