using UnityEngine;


//Superclasse para poderes
public abstract class Poderes 
{

    public int EnergiaMaxima = 10;
    
    public string Nome = "";

    public abstract void ativar(MovimentoBola bola);
    
}
