using System;
using UnityEngine;

public class MovimentoBola : MonoBehaviour {
    public float velocidadeMax = 40f;
    public float velocidade = 6.4f;
    public float incremento = 0.8f;
    public float anguloAdicional = 10f;
    public Vector2 direcao;
    
    private Rigidbody2D rb;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        EscolherDirecao();
    }

    private void OnCollisionEnter2D(Collision2D colisao) {
        if(colisao.gameObject.CompareTag("Raquete")) {
            ColisaoRaquete(colisao.gameObject.GetComponent<MovimentoRaquete>().direcao.y);
        }
        else if(colisao.gameObject.CompareTag("Parede")) {
            ColisaoParede();
        }
    }
    
    private void FixedUpdate() {
        rb.MovePosition((Vector2)transform.position + Time.deltaTime * velocidade * direcao);
    }



    private void EscolherDirecao() {
        // Gerando ângulo em radiano de 20 até 60 graus e depois determinando a qual quadrante do circulo unitário o ângulo pertence
        double angulo = UnityEngine.Random.Range((float)Math.PI / 9, (float)Math.PI / 3) + UnityEngine.Random.Range(0, 4) * Math.PI / 2;

        direcao = new Vector2((float)Math.Cos(angulo), (float)Math.Sin(angulo));
    }

    private void IncrementarVelocidade() {
        float prox = velocidade + incremento;

        if(prox < velocidadeMax) {
            velocidade = prox;
        }
    }

    private void ColisaoRaquete(float sentidoY) {
        float aux = sentidoY * anguloAdicional;

        direcao.x *= -1;
        direcao.Set(
            (float)(direcao.x * Math.Cos(aux) - direcao.y * Math.Sin(aux)),
            (float)(direcao.x * Math.Sin(aux) + direcao.y * Math.Cos(aux))
        );
        IncrementarVelocidade();
    }

    private void ColisaoParede() {
        direcao.y *= -1;
    }
}
