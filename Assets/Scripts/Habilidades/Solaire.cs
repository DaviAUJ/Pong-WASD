using System;
using UnityEngine;

public class Solaire : Poderes
{

    public Solaire()
    {
        EnergiaMaxima = 20;

        Nome = "Solaire";

        
        // Acerta a bola com um raio que inicialmente a paralisa e depois a acelera em direção ao oponente, pontuando se passar ou desacelerando o se acerta lo

       



     }
    public override void ativar(MovimentoBola bola)
    {


        Debug.Log($"{Nome} Foi ativado");

        // Paralizar a Bola 

        bola.velocidade = 0;

        //Dispara a bola na direção do oponente



        //Se acertar o oponente reduz a velocidade 



    }

}
