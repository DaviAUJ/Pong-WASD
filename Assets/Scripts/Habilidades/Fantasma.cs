using System.Collections;
using UnityEditor;
using UnityEngine;

public class Fantasma : Poderes {
    private GameObject bolaFantasma;
    private Color corBola;


    public Fantasma(GameObject raquete) {
        EnergiaMaxima = 15;
        Nome = "Fantasma";
        tempoHabilidade = 30f;

        raqueteRelacionada = raquete;

        // Pega a cor da raquete
        Color corRaquete = raquete.GetComponent<SpriteRenderer>().color; 
        corBola = new Color(
            corRaquete.r,
            corRaquete.g,
            corRaquete.b,
            0.1f
        );
    }



    public override IEnumerator Ativar(MovimentoBola bola) {
        yield return new WaitForSecondsRealtime(0.05f);

        CriarFantasma(bola);

        yield return new WaitForSecondsRealtime(tempoHabilidade);

        DeletarFantasma();
    }

    private void CriarFantasma(MovimentoBola bola) {
        // Instancia
        bolaFantasma = MonoBehaviour.Instantiate(
            (GameObject) AssetDatabase.LoadAssetAtPath("Assets/Prefabs/BolaFantasma Variant.prefab", typeof(GameObject)), 
            new Vector3(bola.gameObject.transform.position.x, bola.gameObject.transform.position.y, 0), 
            Quaternion.identity,
            GameObject.Find("Partida").transform
        );

        MovimentoBolaFantasma mov = bolaFantasma.GetComponent<MovimentoBolaFantasma>();

        // Inverte a direção dela para fazer sair da bola original espelhada
        mov.direcao = bola.direcao;
        mov.direcao.y *= -1;

        // Mesma velocidade
        mov.velocidade = bola.velocidade;

        // Passando quem é dono da bola
        mov.dono = raqueteRelacionada.GetComponent<Jogador>(); 

        // Define a cor da bola
        bolaFantasma.GetComponent<SpriteRenderer>().color = corBola;
    }

    private void DeletarFantasma() {
        MonoBehaviour.Destroy(bolaFantasma);
    }
}
