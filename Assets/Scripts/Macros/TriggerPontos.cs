using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour {
    public Jogador jogadorRelacionado;



    private void OnCollisionEnter2D(Collision2D bolinha) {
        jogadorRelacionado.Pontuar();

        Destroy(bolinha.gameObject);
    }
}
