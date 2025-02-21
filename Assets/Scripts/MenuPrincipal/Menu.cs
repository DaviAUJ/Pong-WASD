using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CarregarMenuPrincipal() {
        SceneManager.LoadScene(0);
    }

    public void CarregarJogo() {
        SceneManager.LoadScene(1);
    }

    public void FecharJogo() {
        Application.Quit();
    }

    public void HabilitarObjeto(GameObject objeto) {
        objeto.SetActive(true);
    }

    public void DesabilitarObjeto(GameObject objeto) {
        objeto.SetActive(false);
    }
}
