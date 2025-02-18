using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoRaquete : MonoBehaviour {
    public float velocidadeMax = 8f;
    public float velocidade;
    public Vector2 direcao;

    private Rigidbody2D rb;

    [SerializeField]
    private InputActionReference movimento;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        velocidade = velocidadeMax;
    }

    private void Update() {
        direcao = movimento.action.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.MovePosition((Vector2)transform.position + Time.deltaTime * velocidade * direcao);
    }



    public void AplicarLentidao(Lentidao lentidao) {
        StartCoroutine(RotinaLentidao(lentidao));
    }

    private IEnumerator RotinaLentidao(Lentidao lentidao) {
        velocidade *= lentidao.GetMultiplicador();

        yield return new WaitForSecondsRealtime(lentidao.GetDuracao());

        velocidade = velocidadeMax;
        Debug.Log("voltou");
    }
}
