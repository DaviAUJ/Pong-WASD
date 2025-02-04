using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoRaquete : MonoBehaviour {
    public float velocidadeMax = 8f;

    private Rigidbody2D rb;
    private Vector2 direcao;

    [SerializeField]
    private InputActionReference movimento;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        direcao = movimento.action.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.MovePosition((Vector2)transform.position + Time.deltaTime * velocidadeMax * direcao);
    }
}
