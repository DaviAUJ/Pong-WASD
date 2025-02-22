using System.Collections;
using UnityEditor;
using UnityEngine;

public class Sans : Poderes {
    private GameObject objetoBarreira;



    public Sans() {
        EnergiaMaxima = 20;
        Nome = "Solaire";
        tempoHabilidade = 8f;

        CarregarSom("EfeitosSonoros/Mega");
    }

    public Sans(GameObject raquete) {
        EnergiaMaxima = 25;
        Nome = "Sans";
        tempoHabilidade = 5f;

        SetRaqueteRelacionada(raquete);
        CarregarSom("EfeitosSonoros/Mega");
    }
    


    public override IEnumerator Ativar(MovimentoBola bola) {
        yield return new WaitForSeconds(0.05f);

        GerenciadorSFX.Tocar(efeitoAtivacao);
        
        MudarOpacidade(0.1f);
        objetoBarreira.SetActive(true);

        yield return new WaitForSeconds(tempoHabilidade);

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

    public override void SetRaqueteRelacionada(GameObject raquete) {
        base.SetRaqueteRelacionada(raquete);
        CriarBarreira();
    }

    private void CriarBarreira() {
        // Pega o prefab e instancia ele atrás da raquete e filho de Partida
        objetoBarreira = MonoBehaviour.Instantiate(
            (GameObject) Resources.Load("Prefabs/BarreiraSans", typeof(GameObject)), 
            new Vector3(raqueteRelacionada.transform.position.x * 1.05f, 0, 0), 
            Quaternion.identity,
            GameObject.Find("Partida").transform
        );
        
        // Começa desabilitado
        objetoBarreira.SetActive(false);
    }
}
