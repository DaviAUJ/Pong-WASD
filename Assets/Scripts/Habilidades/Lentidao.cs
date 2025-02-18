using UnityEngine;

public class Lentidao {
    private float segundosDuracao;
    private float multiplicador;

    public Lentidao(float segundosDuracao, float multiplicador) {
        this.segundosDuracao = segundosDuracao;
        this.multiplicador = multiplicador;
    }

    public float GetDuracao() {
        return segundosDuracao;
    }
    
    public float GetMultiplicador() {
        return multiplicador;
    }
}
