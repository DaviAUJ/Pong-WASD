using UnityEngine;

public class MovimentoBola : MonoBehaviour {
    public float velocidadeMax = 40f;
    public float velocidade = 6.4f;
    public float incremento = 0.8f;
    public float anguloAdicionalRad = Mathf.PI / 18; // 10 graus

    public Vector2 direcao;
    private Rigidbody2D rb;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        // entre 20 e 60 graus
        EscolherAnguloAleatorio(Mathf.PI / 9, Mathf.PI / 3);
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



    private void EscolherAnguloAleatorio(float minInclusivo, float maxInclusivo) {
        // Gerando ângulo em radiano e depois determinando a qual quadrante do circulo unitário o ângulo pertence
        float anguloRad = Random.Range(minInclusivo, maxInclusivo) + Random.Range(0, 4) * Mathf.PI / 2;
        direcao.Set(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad));
    }

    private void IncrementarVelocidade() {
        float prox = velocidade + incremento;

        if(prox < velocidadeMax) {
            velocidade = prox;
        }
    }

    private void ColisaoRaquete(float sentidoBarra) {
        // verificando se a bolinha vai ficar num ângulo aceitável para a situação
        if(sentidoBarra > 0 && direcao.y <= 0.70f || sentidoBarra < 0 && direcao.y >= -0.70f) {
            float aux = sentidoBarra * anguloAdicionalRad;

            // Solução provisória que funciona
            // A barrinha da esquerda fica com as propriedades de conservação de momento invertidas
            // Isso aqui resolve
            if(direcao.x < 0) {
                aux *= -1;
            }

            Debug.Log(sentidoBarra);
            direcao.Set(
                // Matriz de rotação
                direcao.x * Mathf.Cos(aux) - direcao.y * Mathf.Sin(aux),
                direcao.x * Mathf.Sin(aux) + direcao.y * Mathf.Cos(aux)
            );
        }

        direcao.x *= -1;

        IncrementarVelocidade();
    }

    private void ColisaoParede() {
        direcao.y *= -1;
    }
}
