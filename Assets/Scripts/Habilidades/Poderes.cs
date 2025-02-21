using System.Collections;
using UnityEngine;

//Superclasse para poderes
public abstract class Poderes
{
    protected int EnergiaMaxima = 10;
    protected string Nome = "";
    protected float tempoHabilidade = 2f;
    protected GameObject raqueteRelacionada;

    public abstract IEnumerator Ativar(MovimentoBola bola);

    public int GetEnergiaMaxima() {
        return EnergiaMaxima;
    }
}
