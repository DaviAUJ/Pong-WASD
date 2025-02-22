using System.Collections;
using UnityEngine;

//Superclasse para poderes
public abstract class Poderes
{
    protected int EnergiaMaxima = 10;
    protected string Nome = "";
    protected float tempoHabilidade = 2f;
    protected GameObject raqueteRelacionada;
    protected AudioClip efeitoAtivacao;



    public abstract IEnumerator Ativar(MovimentoBola bola);

    public int GetEnergiaMaxima() {
        return EnergiaMaxima;
    }

    public virtual void SetRaqueteRelacionada(GameObject raquete) {
        raqueteRelacionada = raquete;
    }

    // por que eu só não fiz os poderes herdarem MonoBehavior? Saudade de um SerializeField :(
    // Pelo menos eu aprendi algo
    protected void CarregarSom(string caminho) {
        efeitoAtivacao = Resources.Load<AudioClip>(caminho);
    }
}
