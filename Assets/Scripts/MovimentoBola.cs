using System;
using UnityEngine;

public class MovimentoBola : MonoBehaviour {
    public Vector2 direcao;
    public float velocidade = 8f;
    public float velocidadeMax = 40f;
    public float incremento = 0.8f;

    private Rigidbody2D rb;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        EscolherDirecao();
    }

    private void OnCollisionEnter2D(Collision2D colisao) {
        if(colisao.gameObject.CompareTag("Raquete")) {
            ColisaoRaquete();
        }
        else if(colisao.gameObject.CompareTag("Parede")) {
            ColisaoParede();
        }
    }
    
    private void FixedUpdate() {
        rb.MovePosition((Vector2)transform.position + Time.deltaTime * velocidade * direcao);
    }



    private void EscolherDirecao() {
        // Gerando ângulo em radiano de aproximadamente 20 até 70 graus e depois determinando a qual quadrante do circulo unitário o ângulo pertence
        double angulo = UnityEngine.Random.Range(0.349f, 1.221f) + UnityEngine.Random.Range(0, 4) * Math.PI / 2;
        Debug.Log(angulo);

        direcao = new Vector2((float)Math.Cos(angulo), (float)Math.Sin(angulo));
    }

    private void IncrementarVelocidade() {
        float prox = velocidade + incremento;

        if(prox < velocidadeMax) {
            velocidade = prox;
        }
    }

    private void ColisaoRaquete() {
        direcao.x *= -1;
        IncrementarVelocidade();
    }

    private void ColisaoParede() {
        direcao.y *= -1;
    }
}
