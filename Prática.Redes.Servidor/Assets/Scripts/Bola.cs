using UnityEngine;

public class Bola : MonoBehaviour
{
    public int PontosCL;
    public int PontosCR;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void Collider2D(Collider2D col)
    {
        if (col.gameObject.tag == "GolLocal")
        {
            PontosCR += 1;
            Debug.Log("Gol do visitante!"); 
        }
        if (col.gameObject.tag == "GolRemoto")
        {
            PontosCL += 1;
            Debug.Log("Gol da casa!"); 
        }
    }
    
}
