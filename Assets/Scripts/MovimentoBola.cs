using UnityEngine;

public class MovimentoBola : MonoBehaviour {
    public float velocidade = 10f;

    private void OnCollisionEnter2D(Collision2D colisao) {
        Debug.Log("TEste");
        velocidade *= -1;
    }
    
    private void Update() {
        transform.Translate(Vector2.right * velocidade / 1000);
    }

}
