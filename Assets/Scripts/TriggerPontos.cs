using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour {
    [SerializeField]
    public Contador contadorRelacionado;



    private void OnCollisionEnter2D(Collision2D bolinha) {
        contadorRelacionado.Pontuar();

        Destroy(bolinha.gameObject);
    }
}
