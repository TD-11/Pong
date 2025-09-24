using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    public int PontosCR = 0;
    public int PontosCL = 0;
    public float speed = 5f;
    private Rigidbody2D rb;
    public TMP_Text placar;
    private Vector2 direction;
    private float xDirection;
    private float yDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // Decide uma direção aleatória no eixo X (esquerda ou direita)
        xDirection = Random.value < 0.5f ? -1f : 1f;
        // Define uma leve variação no eixo Y (para não ir totalmente reto)
        yDirection = Random.Range(-0.5f, 0.5f);

        // Normaliza a direção e aplica a velocidade
        direction = new Vector2(xDirection, yDirection).normalized;
        rb.linearVelocity = direction * speed;

        placar.text = $"{PontosCL} x {PontosCR}";    
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Gol Local")
        {
            Destroy(gameObject);
            PontosCR += 1;
            placar.text = $"{PontosCL} x {PontosCR}";
            Debug.Log("Gol do visitante!");
        }

        if (col.gameObject.tag == "Gol Remoto")
        {
            Destroy(gameObject);
            PontosCL += 1;
            placar.text = $"{PontosCL} x {PontosCR}";
            Debug.Log("Gol da casa!");
        }

        if (col.gameObject.tag == "PlayerLocal")
        { 
            yDirection = Random.Range(-1f, 1f);
            direction = new Vector2(xDirection, yDirection).normalized;
            rb.linearVelocity = direction * speed;
        }
        if (col.gameObject.tag == "PlayerRemoto")
        {
            yDirection = Random.Range(-1f, 1f);
            direction = new Vector2(-xDirection, yDirection).normalized;
            rb.linearVelocity = direction * speed;
        }

        if (col.gameObject.tag == "Parede1" || col.gameObject.tag == "Parede2")
        {
            rb.linearVelocity = new Vector2(xDirection, -yDirection);
            rb.linearVelocity = direction * speed;
        }
    }
}
