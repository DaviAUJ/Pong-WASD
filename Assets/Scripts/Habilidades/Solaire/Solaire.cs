using System.Collections;
using UnityEngine;
using UnityEngine.Playables;


public class Solaire : Poderes
{
    private float tempoParado = 1f; 
    private float multiplicadorVelocidade = 1.5f;
    private float multiplicadorLentidao = 0.4f;
    private Animator anim;
    public TimelineManager timelineManager;
    [SerializeField] private PlayableDirector playableDirector;  // Referência ao PlayableDirector

    public Solaire(GameObject raquete)
    {
        EnergiaMaxima = 20;
        Nome = "Solaire";
        tempoHabilidade = 8f;

        raqueteRelacionada = raquete;

        timelineManager = GameObject.FindObjectOfType<TimelineManager>();

        if (timelineManager == null)
        {
            Debug.LogError("TimelineManager não foi encontrado na cena!");
        }

        // Tenta pegar o PlayableDirector da raquete
        playableDirector = raquete.GetComponent<PlayableDirector>();

        if (playableDirector == null)
        {
            Debug.LogError("PlayableDirector não encontrado na raquete!");
        }
    }

    public override IEnumerator Ativar(MovimentoBola bola)

    {
        // Tempo antes de paralizar
        yield return new WaitForSecondsRealtime(0.05f);

        // Paralizar a Bola por um determinado tempo
        float velocidadeAntiga = bola.velocidade;
        bola.velocidade = 0;

        AtivarAnimacaoTimeline();

        yield return new WaitForSecondsRealtime(tempoParado);

        //Dispara a bola na direção do oponente
        if(bola.direcao.x > 0) {
            // Entre -45 e 45 graus
            bola.EscolherAnguloAleatorio(-1 * Mathf.PI / 4, Mathf.PI / 4);
        }
        else {
            // Entre 135 e 225 graus
            bola.EscolherAnguloAleatorio(Mathf.PI * 3 / 4, Mathf.PI * 5 / 4);
        }

        bola.velocidade += velocidadeAntiga * multiplicadorVelocidade;

        // Envia um debuff junto com a bola e tenta aplicar no oponente
        bola.lentidao = new Lentidao(tempoHabilidade, multiplicadorLentidao);
    }

    void AtivarAnimacaoTimeline()
    {


        if (playableDirector != null)
        {
            // Verifica se o PlayableDirector não está tocando a animação
            if (playableDirector.state != PlayState.Playing)
            {

                timelineManager.PlayAnimation2();



            }
            else
            {
                Debug.LogWarning("PlayableDirector não foi atribuído!");

            }



        }

        if (timelineManager == null)
        {
            Debug.LogError("TimelineManager não foi encontrado!");
            return;
        }

        if (playableDirector == null)
        {
            Debug.LogError("PlayableDirector não foi atribuído!");
            return;
        }

        // Reinicia a animação e toca
        playableDirector.time = 0;
        playableDirector.Play();

        Debug.Log("Animação da Timeline iniciada!");
    }


}

