using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;  // Necessário para usar PlayableDirector

public class Sans : Poderes {

    public TimelineManager timelineManager;

    private GameObject objetoBarreira;
   
    private Animator anim;

    [SerializeField] private PlayableDirector playableDirector;  // Referência ao PlayableDirector
    private GameObject raqueteRelacionada;





    public Sans() {
        EnergiaMaxima = 20;
        Nome = "Solaire";
        tempoHabilidade = 8f;

        CarregarSom("EfeitosSonoros/Mega");
    }



    public Sans() {
        EnergiaMaxima = 20;
        Nome = "Solaire";
        tempoHabilidade = 8f;

        CarregarSom("EfeitosSonoros/Mega");
    }

    public Sans(GameObject raquete) {
        EnergiaMaxima = 25;
        Nome = "Sans";
        tempoHabilidade = 9f;

        SetRaqueteRelacionada(raquete);
        CarregarSom("EfeitosSonoros/Mega");

        timelineManager = GameObject.FindObjectOfType<TimelineManager>();

        playableDirector = raqueteRelacionada.GetComponent<PlayableDirector>();

        if (playableDirector == null)
        {
            Debug.LogWarning("PlayableDirector não encontrado na raquete!");
        }

        // Começa desabilitado
        objetoBarreira.SetActive(false);
    }

    public override IEnumerator Ativar(MovimentoBola bola) {
        yield return new WaitForSeconds(0.05f);

        GerenciadorSFX.Tocar(efeitoAtivacao);
        
        MudarOpacidade(0.1f);
        objetoBarreira.SetActive(true);

        AtivarAnimacaoTimeline();

        yield return new WaitForSeconds(tempoHabilidade);

        // Retorna a opacidade e desativa a Barreira
        MudarOpacidade(1f);
        objetoBarreira.SetActive(false);


    }

    void AtivarAnimacaoTimeline()
    {
       
        
        if (playableDirector != null)
        {
            // Verifica se o PlayableDirector não está tocando a animação
            if (playableDirector.state != PlayState.Playing)
            {

                timelineManager.PlayAnimation1();



            }
            else
                 {
                  Debug.LogWarning("PlayableDirector não foi atribuído!");
                  
            }

            

        }
       



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
