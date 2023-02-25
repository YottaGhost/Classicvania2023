using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarInimigo : MonoBehaviour
{
    public float detectionRange = 5f; // A distância de detecção do jogador
    public float rotationSpeed = 5f; // A velocidade de rotação do inimigo
    public bool playerDetected; // Uma flag que indica se o jogador foi detectado
    private Transform playerTransform; // A transformada do jogador
    public float distance;

    void Start()
    {
        // Encontra a transformada do jogador
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
        if (other.CompareTag("Player"))
        {
            // Calcula a distância entre o inimigo e o jogador
            distance = Vector2.Distance(transform.position, other.transform.position);

            // Verifica se o jogador está dentro do alcance de detecção
            if (distance <= detectionRange)
            {
                // Define a flag como verdadeira
                playerDetected = true;
            }
        }
    }

    private void Update() {
        inimigo ini = transform.parent.gameObject.GetComponent<inimigo>();
        if (playerDetected == false){
            ini.playerLonge = true;
        }
        if (playerDetected == true){
            ini.playerLonge = false;
        }

        if (playerDetected)
        {
             // Calcula a direção para a qual o inimigo deve se virar
            Vector3 direction = playerTransform.position - transform.parent.position;
            direction.z = 0f;
            

        // Rotaciona o inimigo em 180 graus no eixo Y se necessário
        if (direction.x < 0 && direita == true)
        {
            Debug.Log("chamou 1" );
            Flip();
        }
        else if (direction.x > 0 && !direita)
        {
            Debug.Log("chamou 2" );
            Flip();
        }

        
    }
    }
public bool direita = true;
    void Flip(){
            transform.parent.rotation = Quaternion.Euler(0f, 180f, 0f);
            Debug.Log("virou");
            if (direita == true){
                transform.parent.rotation = Quaternion.Euler(0f, 180f, 0f);
                direita = false;
            }else{
                transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
                direita = true;
            }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica se o objeto que saiu do trigger é o jogador
        if (other.CompareTag("Player"))
        {
            // Define a flag como falsa
            playerDetected = false;
        }
    }
}
