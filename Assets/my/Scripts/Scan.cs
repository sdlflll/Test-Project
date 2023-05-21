using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Scan : MonoBehaviour
{
    [SerializeField] private PostProcessProfile _profile;
    [SerializeField] private PostProcessProfile _backProfile;
    [SerializeField] private GameObject _postObject;
    private bool Scaner;
    private PostProcessVolume _post;
    public bool ToScan;
    private GameObject[] sprites;
    public bool ScanActive;
    void Start()
    {
        _post = _postObject.GetComponent<PostProcessVolume>();
        sprites = FindObjectsOfType<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ToScan == true)
        {
            if (Input.GetKeyDown(KeyCode.T) && Scaner == false)
            {
                _post.profile = _profile;
                Scaner = true;
                Time.timeScale = 0.1f;
                ScanActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.T) && Scaner == true)
            {
                _post.profile = _backProfile;
                Scaner = false;
                Time.timeScale = 1;
                ScanActive = false;
            }
        }
    }

    public void ToScaner ()
    {
        ToScan = true;
    }

    public void TogglePost(PostProcessProfile NewProfile)
    {
        _post.profile = NewProfile;
    }


}
