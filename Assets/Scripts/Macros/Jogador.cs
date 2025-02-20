using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour {
    public string nome = "jogador";
    public int pontosVitoria = 10;
    public float PontosPoder = 0;
    public float limiteInferior = 0.2f;
    public float limiteSuperior = 0.9f;
    public Slider medidorPoder;
    public Contador contadorRelacionado;
    public Poderes poder;

    private Partida partidaRelacionada;
    private int pontos = 0;



    private void Start() {
        partidaRelacionada = transform.parent.gameObject.GetComponent<Partida>();
        poder = new Solaire(gameObject);
        medidorPoder.maxValue = poder.GetEnergiaMaxima();
    }

    private void OnCollisionEnter2D(Collision2D colisao) {
        if(colisao.gameObject.CompareTag("Bola")) {
            PontosPoder += FuncaoPoder(PegarPosYRelativa(colisao.gameObject));

            if (PontosPoder >= poder.GetEnergiaMaxima()) 
            {
                StartCoroutine(poder.Ativar(colisao.gameObject.GetComponent<MovimentoBola>()));
                PontosPoder = 0;
            }

            medidorPoder.value = PontosPoder; // Atualiza o medidor
        }
    }

    

    public void Pontuar() {
        pontos++;

        contadorRelacionado.AtualizarTexto(pontos);

        if(pontosVitoria <= pontos) {
            Vencer();
        }
    }

    private void Vencer() {
        partidaRelacionada.MostarVencedor(nome);
    }

    // a = limiteInferior
    // b = limiteSuperior
    // Função que calcula o poder baseado na posição do jogador
    // insira o codigo abaixo no desmos e adicione os controles deslizantes para visualizar a função
    // \max\left(\frac{1+a^{2}}{b^{2}}x^{2}-a^{2},0\right)
    
    private float FuncaoPoder(float pos) {
        float a2 = Mathf.Pow(limiteInferior, 2);

        return Mathf.Max((Mathf.Pow(pos, 2) - a2) / (Mathf.Pow(limiteSuperior, 2) - a2), 0);
    }

    // Pega a posição y relativa entre jogador e um objeto qualquer
    // A coordenada é baseada em 1 ser o topo do jogador e -1 a base
    private float PegarPosYRelativa(GameObject objeto) {
        return (objeto.transform.position.y - transform.position.y) * 2 / transform.localScale.y;
    }
}
