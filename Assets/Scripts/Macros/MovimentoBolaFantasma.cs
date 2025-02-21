using UnityEngine;

public class MovimentoBolaFantasma : MovimentoBola {
    public Jogador dono;

    protected override void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
}
