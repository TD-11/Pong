using UnityEngine;

public class BallController : MonoBehaviour
{
    public int PontosCR = 0;
    public int PontosCL = 0;
    public float speed = 5f;
    private Rigidbody2D rb;
    public TMPro placar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // Decide uma direção aleatória no eixo X (esquerda ou direita)
        float xDirection = Random.value < 0.5f ? -1f : 1f;
        // Define uma leve variação no eixo Y (para não ir totalmente reto)
        float yDirection = Random.Range(-0.5f, 0.5f);

        // Normaliza a direção e aplica a velocidade
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.velocity = direction * speed;
        
        placar.text = $"{PontosCR} X {PontosCL}";
    }

    void Collider2D(Collider2D col)
    {
        if (col.gameObject.tag == "GolLocal")
        { 
            PontosCR += 1;
            placar.text = $"{PontosCR} x {PontosCL}";
            Debug.Log("Gol do visitante!");
        }
        if (col.gameObject.tag == "GolRemoto")
        {
            PontosCL += 1;
            placar.text = $"{PontosCR} x {PontosCL}";
            Debug.Log("Gol da casa!"); 
        }
    }
    
}
