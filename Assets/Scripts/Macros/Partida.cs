using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Partida : MonoBehaviour {
    [SerializeField] private TMP_Text textoVitoria;
    [SerializeField] private GameObject prefabBola;
    private GameObject bolaAtiva;
    private bool finalizada;

    void Start() {
        CriarBola();
        finalizada = false;
    }


    
    public void CriarBola() {
        if(!finalizada) {
            bolaAtiva = Instantiate(prefabBola, new Vector3(0, 0, -1), quaternion.identity, transform);
        }
    }

    public void MostarVencedor(string nome) {
        AcabarPartida();
        textoVitoria.text = nome + " venceu!";
    }

    private void AcabarPartida() {
        finalizada = true;
        
        // Destroi todas as bolas que tem
        Destroy(bolaAtiva);
        GameObject[] deletar = GameObject.FindGameObjectsWithTag("BolaFantasma");
        foreach(GameObject item in deletar) {
            Destroy(item);
        }
    }
}
