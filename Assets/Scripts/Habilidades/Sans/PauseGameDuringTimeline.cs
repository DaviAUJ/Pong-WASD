using UnityEngine;
using UnityEngine.Playables;

public class PauseGameDuringTimeline : MonoBehaviour
{
    public PlayableDirector timeline; // Arraste o PlayableDirector da Timeline aqui
    public GameObject RaqueteP1; // O primeiro jogador 
    public GameObject RaqueteP2; // O segundo jogador 
    public GameObject Bola; // A bola do jogo

    private Rigidbody2D BolaRb;
    private Vector2 savedVelocity; // Para armazenar a velocidade antes da pausa

    void Start()
    {
        if (timeline != null)
        {
            timeline.played += OnTimelineStart;
            timeline.stopped += OnTimelineEnd;
        }

        AchaBolas(); // Encontra a bola quando o jogo começa

    }

    void AchaBolas()
    {
        Bola = GameObject.FindWithTag("Bola"); 

        if (Bola != null)
        {
            BolaRb = Bola.GetComponent<Rigidbody2D>();
        }
    }


    void OnTimelineStart(PlayableDirector director)
    {
        // Desativar os controles dos jogadores (se tiverem scripts de movimento)
        if (RaqueteP1 != null) RaqueteP1.GetComponent<MovimentoRaquete>().enabled = false;
        if (RaqueteP2 != null) RaqueteP2.GetComponent<MovimentoRaquete>().enabled = false;

        Debug.Log("Timeline começou! Procurando a bola...");

        if (Bola == null) AchaBolas(); // Caso a bola tenha sido recriada

        // Pausar a bola sem alterar dire��o/velocidade
        if (BolaRb != null)
        {
            savedVelocity = BolaRb.linearVelocity; // Salva a velocidade
            BolaRb.linearVelocity = Vector2.zero; // Para a bola
            BolaRb.simulated = false; // Desativa a f�sica temporariamente
        }
    }

    void OnTimelineEnd(PlayableDirector director)
    {

        Debug.Log("Timeline terminou! Voltando a bola ao normal.");

        // Reativar os controles dos jogadores
        if (RaqueteP1 != null) RaqueteP1.GetComponent<MovimentoRaquete>().enabled = true;
        if (RaqueteP2 != null) RaqueteP2.GetComponent<MovimentoRaquete>().enabled = true;

        // Restaurar a bola com a mesma velocidade
        if (BolaRb != null)
        {
            BolaRb.simulated = true; // Reativa a f�sica
            BolaRb.linearVelocity = savedVelocity; // Restaura a velocidade original
        }
    }

    void OnDestroy()
    {
        if (timeline != null)
        {
            timeline.played -= OnTimelineStart;
            timeline.stopped -= OnTimelineEnd;
        }
    }
}
