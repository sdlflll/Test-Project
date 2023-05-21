
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartToGameCutScene (PlayableDirector ToGameCS)
    {
        ToGameCS.Play();
    }
   public void SceneSwitcher (int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }
    public void AntiAliasing (Camera camera)
    {
        camera.allowMSAA = true;
    }
    public void Quit ()
    {
        Application.Quit();
        print("выход");
    }
}
