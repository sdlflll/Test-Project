using System.Collections;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] GameObject DialoguePanel;
    public TextMeshPro _textInput;
    private string text;
    void Start()

    {
        text = _textInput.text;
        _textInput.text = "";
        DialoguePanel.SetActive(false);
    }
    IEnumerator TextCourutine()
    {
        foreach(char inputText in text)
        {
            _textInput.text += inputText;
            yield return new WaitForSeconds(0.1f);
            
        }
    }

    public void StartDialogue()
    {
        DialoguePanel.SetActive(true);
        StartCoroutine(TextCourutine());
    }
    public void EndDialogue ()
    {
        _textInput.text = "";
        DialoguePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
