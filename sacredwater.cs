using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sacredwater : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public GameObject WaterPrefab;

    GameObject player;
    public double vidaUt =2;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1f, 1.2f, 1f);
        vidaUt = 2;
    }
    public bool foiPai =false;
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        Subitens chi = player.GetComponent<Subitens>();

        if(IsGrounded() && chi.Water ==4 && foiPai == false){
            Instantiate(WaterPrefab, groundCheck.position, groundCheck.rotation);
            chi.Water -=1;
            foiPai = true;
            Destroy(gameObject);
        }
        if ((chi.Water<=3 && chi.Water > 0) && vidaUt <=1 && debug == false && foiPai == false){
            Instantiate(WaterPrefab, groundCheck.position, groundCheck.rotation);
            chi.Water -=1;
            foiPai = true;
        }

        if (vidaUt >= 1 && chi.Water <=3){
            transform.localScale += new Vector3(0, 0.01f, 0);
        } else if (chi.Water <=3){transform.localScale -= new Vector3(0, 0.01f, 0);}

        if (vidaUt <=0){
            Destroy(gameObject);
        }

        vidaUt -= 1 * Time.deltaTime;
    }
    public bool debug;
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        debug = IsGrounded();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        inimigo enemy = hitInfo.GetComponent<inimigo>();
        if (enemy != null)
        {
            enemy.TakeDamage(15);
        }
    }
}
