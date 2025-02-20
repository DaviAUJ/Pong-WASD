using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Sans : Poderes {
    private GameObject objetoBarreira;
    private Animator anim;
    public Sans(GameObject raquete) {
        EnergiaMaxima = 25;
        Nome = "Sans";
        tempoHabilidade = 20f;

        raqueteRelacionada = raquete;

        // Pega o prefab e instancia ele atrás da raquete e filho de Partida
        objetoBarreira = MonoBehaviour.Instantiate(
            (GameObject) AssetDatabase.LoadAssetAtPath("Assets/Prefabs/BarreiraSans.prefab", typeof(GameObject)), 
            new Vector3(raquete.transform.position.x * 1.05f, 0, 0), 
            Quaternion.identity,
            GameObject.Find("Partida").transform
        );

        // Começa desabilitado
        objetoBarreira.SetActive(false);
    }



    public override IEnumerator Ativar(MovimentoBola bola) {
        MudarOpacidade(0.1f);
        objetoBarreira.SetActive(true);

     

        yield return new WaitForSecondsRealtime(tempoHabilidade);

        // Retorna a opacidade e desativa a Barreira
        MudarOpacidade(1f);
        objetoBarreira.SetActive(false);
    }

    // Por algum motivo tenho que passar um novo Color para mudar só o alpha
    // Não tem nem um método pra trocar
    private void MudarOpacidade(float valor) {
        SpriteRenderer sprite = raqueteRelacionada.GetComponent<SpriteRenderer>();

        if(valor > 1) {
            valor = 1f;
        }

        sprite.color = new Color(
            sprite.color.r,
            sprite.color.g,
            sprite.color.b,
            valor
        );
    }
}
