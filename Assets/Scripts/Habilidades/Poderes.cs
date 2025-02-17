using System.Collections;
using UnityEngine;


//Superclasse para poderes
public abstract class Poderes : MonoBehaviour
{

    public int EnergiaMaxima = 10;
    
    public string Nome = "";

    public float tempoHabilidade = 2f;

    public abstract IEnumerator ativar(MovimentoBola bola);
    
}
