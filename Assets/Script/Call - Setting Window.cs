using UnityEngine;

public class SettingsToggle : MonoBehaviour
{
    public GameObject settingsPanel; // Assign your settings panel here in the inspector

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}
