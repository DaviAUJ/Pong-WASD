using UnityEngine;
using UnityEngine.Playables;


public class TimelineManager : MonoBehaviour
{

    public PlayableDirector playableDirector;
    public PlayableAsset timeline1;
    public PlayableAsset timeline2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayAnimation1()
    {
        if (playableDirector != null && timeline1 != null)
        {
            playableDirector.playableAsset = timeline1;
            playableDirector.Play();
        }
    }

    // Método para tocar a segunda animação
    public void PlayAnimation2()
    {
        if (playableDirector != null && timeline2 != null)
        {
            playableDirector.playableAsset = timeline2;
            playableDirector.Play();
        }
    }
}
