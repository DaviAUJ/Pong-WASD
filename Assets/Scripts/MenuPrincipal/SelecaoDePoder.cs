using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoDePoder : MonoBehaviour {
    [SerializeField] private ToggleGroup escolhaP1;
    [SerializeField] private ToggleGroup escolhaP2;
    [SerializeField] private TMP_Text inputNomeP1;
    [SerializeField] private TMP_Text inputNomeP2;



    public void Confirmar() {
        Toggle ativoP1 = escolhaP1.ActiveToggles().FirstOrDefault();
        Toggle ativoP2 = escolhaP2.ActiveToggles().FirstOrDefault();
        
        
        // Define o poder de P1
        Configuracoes.poderP1 = DefinirPoder(ativoP1.name);

        // Define o poder de P2
        Configuracoes.poderP2 = DefinirPoder(ativoP2.name);

        // Define os nomes dos jogadores
        if(!inputNomeP1.Equals("")) {
            Configuracoes.nomeP1 = inputNomeP1.text;
        }

        if(!inputNomeP2.Equals("")) {
            Configuracoes.nomeP2 = inputNomeP2.text;
        }
    }

    private Poderes DefinirPoder(string nome) {
        Poderes saida = null;

        // Deve haver alguma forma melhor de definir os poderes além de if else if
        if(nome.Equals("Solaire")) {
            saida = new Solaire();
        }
        else if(nome.Equals("Sans")) {
            saida = new Sans();
        }
        else if(nome.Equals("Fantasma")) {
            saida = new Fantasma();
        }
        
        return saida;
    }
}
