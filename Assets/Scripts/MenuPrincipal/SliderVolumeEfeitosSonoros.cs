using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeEfeitosSonoros : MonoBehaviour {
    [SerializeField] private Slider slider; // 0 a 100
    [SerializeField] private TMP_InputField inputDireto;


    public void Start() {
        slider.value = Configuracoes.GetVolumeEfeitosSonoros() * 100;
        inputDireto.text = slider.value.ToString();
    }

    public void AtualizarSlider() {
        slider.value = int.Parse(inputDireto.text);
        Configuracoes.SetVolumeEfeitosSonoros(slider.value / 100);
    }

    public void AtualizarTexto() {
        inputDireto.text = slider.value.ToString();
        Configuracoes.SetVolumeEfeitosSonoros(slider.value / 100);
    }
}
