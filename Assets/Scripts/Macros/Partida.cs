using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Partida : MonoBehaviour {
    [SerializeField] private TMP_Text textoSituacao;
    [SerializeField] private GameObject prefabBola;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private InputActionReference pauseP1;
    [SerializeField] private InputActionReference pauseP2;
    private GameObject bolaAtiva;
    private bool finalizada;
    private bool pausado;
    


    void Start() {
        CriarBola();
        finalizada = false;
    }

    void Update() {
        ChecarPausa();
    }



    public void CriarBola() {
        if(!finalizada) {
            bolaAtiva = Instantiate(prefabBola, new Vector3(0, 0, -1), quaternion.identity, transform);
        }
    }

    public void MostarVencedor(string nome) {
        AcabarPartida();
        textoSituacao.text = nome + " venceu!";
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

    private void ChecarPausa() {
        if(pauseP1.action.WasPressedThisFrame() || pauseP2.action.WasPressedThisFrame()) {
            if(pausado) {
                DespausarPartida();
            }
            else {
                PausarPartida();
            }
        }
    }

    private void PausarPartida() {
        if(!finalizada) {
            menuPausa.SetActive(true);
            textoSituacao.text = "Jogo pausado";
            Time.timeScale = 0;
            pausado = true;
        }
    }

    private void DespausarPartida() {
        menuPausa.SetActive(false);
        textoSituacao.text = "";
        Time.timeScale = 1;
        pausado = false;
    }
}
