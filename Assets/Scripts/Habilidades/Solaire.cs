using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Solaire : Poderes
{
    public MovimentoBola bola;


    public Solaire()
    {
        EnergiaMaxima = 20;

        Nome = "Solaire";

      
        // Acerta a bola com um raio que inicialmente a paralisa e depois a acelera em direção ao oponente, pontuando se passar ou desacelerando o se acerta lo





    }

    private void Start()
    {

        if (bola == null)
        {

            bola = FindFirstObjectByType<MovimentoBola>();


            if (bola == null)
            {
                Debug.LogError("Não foi possível encontrar a bola na cena!");
                return;
            }
        }

    }

    public override IEnumerator ativar(MovimentoBola bola)
    {


        Debug.Log($"{Nome} Foi ativado");

        // Paralizar a Bola por um determinado tempo

        bola.velocidade = 0;
       
        tempoHabilidade = 1f;
        
        yield return new WaitForSeconds(tempoHabilidade);

        //Dispara a bola na direção do oponente
        
        Vector2 direcaoDoOponente = bola.RaquetePlayer1.position - bola.transform.position;
        direcaoDoOponente.Normalize();

        float velocidadeAlta = 10f;  // Ajuste esse valor conforme necessário
        bola.transform.Translate(direcaoDoOponente * velocidadeAlta * Time.deltaTime);




        //Se acertar o oponente reduz a velocidade 



    }

}
