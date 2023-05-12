using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void ChangeScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
