using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour {
    public int pontosVitoria = 7;

    private int pontos = 0;
    private TMP_Text texto;



    private void Start() {
        texto = GetComponent<TMP_Text>();
    }


    
    private void AtualizarTexto() {
        texto.text = pontos.ToString();
    }

    public void Pontuar() {
        pontos++;

        AtualizarTexto();

        if(pontos >= pontosVitoria) {
            // Declarar vitoria
        }
    }
}
