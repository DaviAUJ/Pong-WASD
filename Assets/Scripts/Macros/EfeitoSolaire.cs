using UnityEngine;

public class EfeitoSolaire : MonoBehaviour {
    private Lentidao lentidao;
    private GameObject dono;



    private void OnCollisionEnter2D(Collision2D colisao) {
        GameObject objetoColidido = colisao.gameObject;

        if(lentidao != null && objetoColidido.CompareTag("Raquete") && objetoColidido != dono) {
            objetoColidido.GetComponent<MovimentoRaquete>().AplicarLentidao(lentidao);
            lentidao = null;
        }
    }

    

    public void SetLentidao(Lentidao lentidao) {
        this.lentidao = lentidao;
    }

    public void SetDono(GameObject dono) {
        this.dono = dono;
    }
}
