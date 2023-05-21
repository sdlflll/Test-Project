using UnityEngine;
using UnityEngine.Playables;

public class SkipCutScene : MonoBehaviour
{
    public GameObject director;
    void Start()
    {
        director.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKey(KeyCode.E))
        {
            director.GetComponent<PlayableDirector>().time += Time.deltaTime;
        }
    }
}
