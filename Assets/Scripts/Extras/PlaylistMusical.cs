using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlaylistMusical : MonoBehaviour {
    [SerializeField] private AudioResource[] musicas;
    private AudioSource jukebox;
    private int index;



    private void Start() {
        index = 0;
        jukebox = gameObject.GetComponent<AudioSource>();
        Embaralhar();
        StartCoroutine(Loop());
    }

    

    // Fisher-Yates
    private void Embaralhar() {
        int n = musicas.Length;

        while(n > 1) {
            n--;
            int k = Random.Range(0, n + 1);
            (musicas[n], musicas[k]) = (musicas[k], musicas[n]);
        }
    }

    private void TocarProxima() {
        index++;

        if(index == musicas.Length) {
            index = 0;
        }

        jukebox.resource = musicas[index];
        jukebox.Play();
    }

    private IEnumerator Loop() {
        while(true) {
            TocarProxima();

            yield return new WaitForSeconds(jukebox.clip.length);
        }
    }
}
