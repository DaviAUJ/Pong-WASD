using UnityEngine;

public class GerenciadorSFX : MonoBehaviour {
    public static void Tocar(AudioClip efeito, float pan = 0) {
        float volume = Configuracoes.GetVolumeEfeitosSonoros();

        if(volume > 0) {
            float duracao;

            // Instancia objeto de som
            AudioSource fonte = new GameObject("fonteSom").AddComponent<AudioSource>();

            // Configura efeito sonoro
            fonte.clip = efeito;
            fonte.volume = volume;
            fonte.panStereo = pan;
            fonte.Play();   

            // Deleta a fonte depois de tocar o efeito sonoro
            duracao = efeito.length;
            Destroy(fonte.gameObject, duracao);
        }
    }

    public static void TocarAleatorio(AudioClip[] arrayEfeitos, float pan = 0) {
        int escolha = Random.Range(0, arrayEfeitos.Length);

        Tocar(arrayEfeitos[escolha], pan);
    }
}
