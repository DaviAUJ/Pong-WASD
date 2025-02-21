using UnityEngine;

// Classe onde é estatico para passar as configurações entre cenas
public class Configuracoes {
    public static string nomeP1 = "Jogador1";
    public static string nomeP2 = "Jogador2";
    public static Poderes poderP1;
    public static Poderes poderP2;
    private static float volumeMusica = 1f;
    private static float volumeEfeitosSonoros = 1f;

    public static float GetVolumeMusica() {
        return volumeMusica;
    }

    public static void SetVolumeMusica(float volume) {
        if(volume > 1) {
            volume = 1;
        }

        volumeMusica = volume;
    }

    public static float GetVolumeEfeitosSonoros() {
        return volumeEfeitosSonoros;
    }

    public static void SetVolumeEfeitosSonoros(float volume) {
        if(volume > 1) {
            volume = 1;
        }

        volumeEfeitosSonoros = volume;
    }
}
