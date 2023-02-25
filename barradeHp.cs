using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barradeHp : MonoBehaviour
{
    public Image healthBarImage;
    public GameObject Coisa;

    public bool diminuindo;

    public float sla;

    void Start()
    {
        Coisa = GameObject.FindWithTag("Player");

    }
    public float Coolmax;
    void Update()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();

        AtaquePlayer treco = Coisa.GetComponent<AtaquePlayer>();
        
        if (diminuindo == false){
        //enche a barra de vida com a variavel 

        healthBarImage.fillAmount = Mathf.Clamp((float)treco.CurrentHp / (float)treco.MaxHp, 0, 1f);
        sla = objectRectTransform.rect.width;
        
        //Aumenta o tamanho da barra baseado no hp maximo do personagem
        sla = (float)treco.MaxHp * 2;
        objectRectTransform.sizeDelta = new Vector2(sla, 25);
        }
        else {
            Subitens treco1 = Coisa.GetComponent<Subitens>();
            healthBarImage.fillAmount = Mathf.Clamp((float)treco1.Cooldown / Coolmax, 0, 1f);
        }
        
    }
}
