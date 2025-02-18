using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Solaire : Poderes
{
    private float tempoParado = 1f; 
    private float multiplicadorVelocidade = 1.5f;

    public Solaire()
    {
        EnergiaMaxima = 20;
        Nome = "Solaire";
    }

    public override IEnumerator ativar(MovimentoBola bola)
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
        bola.lentidao = new Lentidao(8f, 0.4f);
    }

}
