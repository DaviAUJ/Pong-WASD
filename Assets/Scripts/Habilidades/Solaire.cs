using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Solaire : Poderes
{
    private float tempoParado = 1f; 
    private float velocidadeAdicional = 10f;

    public Solaire()
    {
        EnergiaMaxima = 20;
        Nome = "Solaire";
    }

    private void Start()
    {

    }

    public override IEnumerator ativar(MovimentoBola bola)
    {
        Debug.Log($"{Nome} Foi ativado");

        // Paralizar a Bola por um determinado tempo
        bola.velocidade = 0;
        
        yield return new WaitForSeconds(tempoParado);

        //Dispara a bola na direção do oponente

        if(bola.direcao.x < 0) {
            // Entre -45 e 45 graus
            bola.EscolherAnguloAleatorio(-Mathf.PI / 4, Mathf.PI / 4);
        }
        else {
            // Entre 135 e 225 graus
            bola.EscolherAnguloAleatorio(Mathf.PI * 3 / 4, Mathf.PI * 5 / 4);
        }

        bola.velocidade += velocidadeAdicional;

        // Envia um debuff junto com a bola e tenta aplicar no oponente
        


    }

}
