using UnityEngine;

public class ToSettings : MonoBehaviour
{ 
    //���������� main � ��������� settingsPanel
    public void TapSettings(GameObject PlaySettingQuitText)
    {
        if (PlaySettingQuitText.active == true)
        {
            PlaySettingQuitText.SetActive(false);
        }
        else
        {
            PlaySettingQuitText.SetActive(true);
        }
    }
    public void IsSettingPanel(GameObject SettingsPanel)
    {
        if(SettingsPanel.active == true) {
            SettingsPanel.SetActive(false);
        }
        else
        {
            SettingsPanel.SetActive(true);
        }
        
    }
}
