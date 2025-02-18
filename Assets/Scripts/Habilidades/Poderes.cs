using System.Collections;
using UnityEngine;

//Superclasse para poderes
public abstract class Poderes
{
    public int EnergiaMaxima = 10;
    public string Nome = "";
    public float tempoHabilidade = 2f;
    public GameObject raqueteRelacionada;

    public abstract IEnumerator Ativar(MovimentoBola bola);
}
