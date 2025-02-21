using System.Collections;
using UnityEngine;

public class Solaire : Poderes
{
    private float tempoParado = 1f; 
    private float multiplicadorVelocidade = 1.5f;
    private float multiplicadorLentidao = 0.4f;

    public Solaire(GameObject raquete)
    {
        EnergiaMaxima = 20;
        Nome = "Solaire";
        tempoHabilidade = 8f;

        raqueteRelacionada = raquete;
    }

    public override IEnumerator Ativar(MovimentoBola bola)
    {
        // Tempo antes de paralizar
        yield return new WaitForSecondsRealtime(0.05f);

        // Paralizar a Bola por um determinado tempo
        float velocidadeAntiga = bola.velocidade;
        bola.velocidade = 0;
        
        yield return new WaitForSecondsRealtime(tempoParado);

        //Dispara a bola na direção do oponente
        if(bola.direcao.x > 0) {
            // Entre -45 e 45 graus
            bola.EscolherAnguloAleatorio(-1 * Mathf.PI / 4, Mathf.PI / 4);
        }
        else {
            // Entre 135 e 225 graus
            bola.EscolherAnguloAleatorio(Mathf.PI * 3 / 4, Mathf.PI * 5 / 4);
        }

        bola.velocidade += velocidadeAntiga * multiplicadorVelocidade;

        // Envia um debuff junto com a bola e tenta aplicar no oponente
        bola.lentidao = new Lentidao(tempoHabilidade, multiplicadorLentidao);
    }
}
