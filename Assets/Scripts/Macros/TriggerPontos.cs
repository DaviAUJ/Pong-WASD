using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour {
    public Jogador jogadorRelacionado;
    
    [SerializeField] private Partida partidaRelacionada;



    private void OnCollisionEnter2D(Collision2D bolinha) {
        if(bolinha.gameObject.CompareTag("BolaFantasma") && bolinha.gameObject.GetComponent<MovimentoBolaFantasma>().dono == jogadorRelacionado) {
            jogadorRelacionado.Pontuar();
        }
        else if(bolinha.gameObject.CompareTag("Bola")) {
            jogadorRelacionado.Pontuar();
            partidaRelacionada.CriarBola();
        }

        Destroy(bolinha.gameObject);
    }
}
