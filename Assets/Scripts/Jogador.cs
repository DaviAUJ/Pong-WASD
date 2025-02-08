using System;
using UnityEngine;

public class Jogador : MonoBehaviour {
    public string nome = "jogador";
    public int pontosVitoria = 10;
    public Contador contadorRelacionado;

    private Partida partidaRelacionada;
    private int pontos = 0;


    
    private void Start() {
        partidaRelacionada = transform.parent.gameObject.GetComponent<Partida>();
    }



    public void Pontuar() {
        pontos++;

        contadorRelacionado.AtualizarTexto(pontos);

        if(pontosVitoria <= pontos) {
            Vencer();
        }
        else {
            partidaRelacionada.CriarBola();
        }
    }

    private void Vencer() {
        partidaRelacionada.MostarVencedor(nome);
    }
}
