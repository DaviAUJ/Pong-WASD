using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Partida : MonoBehaviour {
    public GameObject bola;
    public TMP_Text textoVitoria;



    void Start() {
        CriarBola();
    }


    
    public void CriarBola() {
        Instantiate(bola, new Vector3(0, 0, -1), quaternion.identity, transform);
    }

    public void MostarVencedor(string nome) {
        textoVitoria.text = nome + " venceu!";
    }
}
