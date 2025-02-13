using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour {
    private TMP_Text texto;



    private void Start() {
        texto = GetComponent<TMP_Text>();
    }



    public void AtualizarTexto(int novoInt) {
        texto.text = novoInt.ToString();
    }
}
