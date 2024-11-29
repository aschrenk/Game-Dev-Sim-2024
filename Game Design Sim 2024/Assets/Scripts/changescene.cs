using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class changescene : MonoBehaviour
{
    public GameObject credits;
    public GameObject playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(playButton);
    }

    // Update is called once per frame
    void Update()
    {
        //if  (EventSystem.current.currentSelectedGameObject == null) EventSystem.current.SetSelectedGameObject(playButton);
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void stopGame()
    {
        Application.Quit();
    }

    public void showCredits()
    {
        credits.SetActive(true);
    }

    public void hideCredits()
    {
        credits.SetActive(false);
    }
}
