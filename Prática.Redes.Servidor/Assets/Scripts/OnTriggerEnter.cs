using System;
using UnityEngine;

public class OnTriggerEnter : MonoBehaviour
{
    public float speed = 5f;
    public GameObject  PlayerLocal;
    public GameObject  PlayerRemote;
    private string eixo; // "Vertical1" para um player, "Vertical2" para outro
    public float limiteSuperior = 3.5f;
    public float limiteInferior = -3.5f;

    void Start()
    {
        if (PlayerLocal != null)
        {
            eixo = "Vertical";
        }
        if (PlayerRemote != null)
        {
            eixo = "Vertical";
        }
    }
    void Update()
    {
        float movimento = Input.GetAxisRaw(eixo) * speed * Time.deltaTime;

        // Move
        PlayerLocal.transform.Translate(0, movimento, 0);

        // Impede de passar das paredes
        float y = Mathf.Clamp(transform.position.y, limiteInferior, limiteSuperior);
        PlayerRemote.transform.position = new Vector2(transform.position.x, y);
    }
}
