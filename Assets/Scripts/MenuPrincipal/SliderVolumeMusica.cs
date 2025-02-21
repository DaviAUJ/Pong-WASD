using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeMusica : MonoBehaviour {
    [SerializeField] private Slider slider; // 0 a 100
    [SerializeField] private TMP_InputField inputDireto;
    [SerializeField] private AudioSource fonteMusica;

    public void Start() {
        slider.value = Configuracoes.GetVolumeMusica() * 100;
        inputDireto.text = slider.value.ToString();
    }

    public void AtualizarSlider() {
        slider.value = int.Parse(inputDireto.text);
        Configuracoes.SetVolumeMusica(slider.value / 100);
        AtualizarVolume();
    }

    public void AtualizarTexto() {
        inputDireto.text = slider.value.ToString();
        Configuracoes.SetVolumeMusica(slider.value / 100);
        AtualizarVolume();
    }

    public void AtualizarVolume() {
        fonteMusica.volume = Configuracoes.GetVolumeMusica();
    }
}
