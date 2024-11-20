using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class changescene : MonoBehaviour
{
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
