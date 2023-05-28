using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] public GameObject Menus;
    public bool menuActivate;
    public bool menuNotActive;

    public void MenuSwitcher()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActivate == false)
            {
                menuActivate = true;
                menuNotActive = false;
            }
            else if (menuActivate == true)
            {

                menuActivate = false;
                menuNotActive = true;

            }
        }
    }
    public void ToMenuInGame()
    {
        if (menuActivate == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Menus.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }
    public void Continue ()
    {
        if (menuActivate == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            menuActivate = false;
            menuNotActive = true;
            Menus.SetActive(false);
            Time.timeScale = 1f;
        }
    }
  

    // Update is called once per frame
    void Update()
    {
        MenuSwitcher();
        ToMenuInGame();
    }
    public void SceneSwitcher(int QuitId)
    {
        menuActivate = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(QuitId);
    }
    public void Restart()
    {
        menuActivate = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
