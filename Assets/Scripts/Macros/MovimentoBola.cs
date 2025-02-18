using System.Collections;
using UnityEngine;

public class MovimentoBola : MonoBehaviour {
    public float velocidadeMax = 40f;
    public float velocidade = 6.4f;
    public float incremento = 0.8f;
    public float anguloAdicionalRad = Mathf.PI / 18; // 10 graus
    public Vector2 direcao;
    public Lentidao lentidao;

    private Rigidbody2D rb;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        lentidao = null;

        // Escolhe um ângulo entre -45 e 45 e escolhe um lado
        EscolherAnguloAleatorio(-1 * Mathf.PI/ 4, Mathf.PI / 4);

        if(Random.Range(0, 2) == 1) {
            direcao.x *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D colisao) {
        if(colisao.gameObject.CompareTag("Raquete")) {
            ColisaoRaquete(colisao.gameObject.GetComponent<MovimentoRaquete>());
        }
        else if(colisao.gameObject.CompareTag("Parede")) {
            ColisaoParede();
        }
        else if(colisao.gameObject.CompareTag("Barreira")) {
            ColisaoBarreira();
        }
    }
    
    private void FixedUpdate() {
        rb.MovePosition((Vector2)transform.position + Time.deltaTime * velocidade * direcao);
    }



    public void EscolherAnguloAleatorio(float minInclusivo, float maxInclusivo) {
        // Gerando ângulo em radiano
        float anguloRad = Random.Range(minInclusivo, maxInclusivo);
        direcao.Set(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad));
    }

    private void IncrementarVelocidade() {
        float prox = velocidade + incremento;

        if(prox <= velocidadeMax) {
            velocidade = prox;
        }
    }

    private void ColisaoRaquete(MovimentoRaquete raquete) {
        float sentidoBarra = raquete.direcao.y;

        // verificando se a bolinha vai ficar num ângulo aceitável para a situação
        if(sentidoBarra > 0 && direcao.y <= 0.70f || sentidoBarra < 0 && direcao.y >= -0.70f) {
            float aux = sentidoBarra * anguloAdicionalRad;

            // A barrinha da esquerda fica com as propriedades de conservação de momento invertidas
            // Isso aqui resolve
            if(direcao.x < 0) {
                aux *= -1;
            }
            
            direcao.Set(
                // Matriz de rotação
                direcao.x * Mathf.Cos(aux) - direcao.y * Mathf.Sin(aux),
                direcao.x * Mathf.Sin(aux) + direcao.y * Mathf.Cos(aux)
            );
        }

        direcao.x *= -1;

        IncrementarVelocidade();

        // tenta aplicar desaceleração no oponente
        if(lentidao != null) {
            raquete.AplicarLentidao(lentidao);
            lentidao = null;
        }
    }

    private void ColisaoParede() {
        direcao.y *= -1;
    }

    private void ColisaoBarreira() {
        direcao.x *= -1;
        IncrementarVelocidade();
    }
}
