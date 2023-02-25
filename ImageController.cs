using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;

    [SerializeField] private bool isMoving = false;
    public bool isCoveringScreen = false;

    private void Start()
    {
        startPosition = transform.position; // Define a posição inicial da imagem
        endPosition = new Vector3(startPosition.x, -350f, startPosition.z); // Define a posição final da imagem

        Invoke("MoveDown", 0.5f); // Faz a imagem descer quando a cena inicia
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * 2f); // Move a imagem em direção à posição final
            if (transform.position.y <= endPosition.y + 0.1f)
            {
                isMoving = false; // Para a movimentação quando a imagem chega na posição final
            }
        }
        else if (isCoveringScreen)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * 2f); // Move a imagem em direção a tela para cobrir a cena
            if (transform.position.z <= -0.1f)
            {
                isCoveringScreen = false; // Para a movimentação quando a imagem cobre a tela
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void MoveDown()
    {
        isMoving = true;
    }

    public void CoverScreen()
    {
        isCoveringScreen = true;
    }
}
