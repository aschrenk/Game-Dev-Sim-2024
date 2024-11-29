using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject resumeButton;
    public GameManager manager;
    private void OnEnable()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    public void OnResume()
    {
        manager.Unpause();
    }

    public void OnRetry()
    {
        manager.Unpause();
        SceneManager.LoadScene("SampleScene");
    }

    public void OnMainMenu()
    {
        manager.Unpause();
        SceneManager.LoadScene("MainMenu");
    }
}
