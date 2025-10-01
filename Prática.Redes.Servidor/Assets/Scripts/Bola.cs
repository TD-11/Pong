using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int PontosCR = 0;
    public int PontosCL = 0;
    public float speed = 5f;
    public TMP_Text placar;

    private Vector2 direction;

    void Start()
    {
        LaunchBall();
        AtualizarPlacar();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);

        direction = new Vector2(x, y).normalized;
    }

    void ResetarBola()
    {
        transform.position = Vector2.zero;
        LaunchBall();
    }

    void AtualizarPlacar()
    {
        placar.text = $"{PontosCL} x {PontosCR}";
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Gol Local"))
        {
            PontosCR++;
            AtualizarPlacar();
            ResetarBola();
        }
        else if (col.CompareTag("Gol Remoto"))
        {
            PontosCL++;
            AtualizarPlacar();
            ResetarBola();
        }
        else if (col.CompareTag("PlayerLocal"))
        {
            float y = Random.Range(-2f, 2f);
            direction = new Vector2(1f, y).normalized;
        }
        else if (col.CompareTag("PlayerRemoto"))
        {
            float y = Random.Range(-2f, 2f);
            direction = new Vector2(-1f, y).normalized;
        }
        else if (col.CompareTag("Parede1") || col.CompareTag("Parede2"))
        {
            direction = new Vector2(direction.x, -direction.y);
        }
    }
}
