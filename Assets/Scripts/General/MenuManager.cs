using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject resumeButton;

    private void Start()
    {
        if(PlayerPrefs.GetInt("isGameStarted",0) == 1)
            resumeButton.SetActive(true);
        else
            resumeButton.SetActive(false);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("isGameStarted", 1);
        AudioManager.Instance.ChangeScene("Garden");
        SceneManager.LoadScene("Garden");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenControls()
    {
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

}
