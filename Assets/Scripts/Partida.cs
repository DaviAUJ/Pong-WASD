using Unity.Mathematics;
using UnityEngine;

public class Partida : MonoBehaviour {
    public GameObject bola;
    


    void Start() {
        CriarBola();
    }


    
    public void CriarBola() {
        Instantiate(bola, new Vector3(0, 0, -1), quaternion.identity, transform);
    }

    
}
