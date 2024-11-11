using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float currentTime;
    public int intTime;
    
    int issueChance;
    int lastIssue;
    int issuesActive;

    public TMP_Text progDebug;
    int progress;
    int tasksDone;

    public Toggle[] tasksToggles;
    public TMP_Text[] tasksTexts;
    public string[] tasksStrings;

    public TMP_Text timeBar;
    string minutes;
    string hour;
    string day;
    string amPM;

    public GameObject[] notifs;
    public AudioSource audioSource;
    public AudioClip[] notifSounds;

    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        //initializes values
        currentTime = 0f;
        issueChance = 0;
        lastIssue = 0;
        issuesActive = 0;
        progress = 0;
        tasksDone = 0;

        minutes = "00";
        hour = "12";
        day = "7";
        amPM = "AM";

        //initializes task texts
        for (int i = 0; i <=14; i++)
        {
            tasksTexts[i].text = tasksStrings[i];
        }

        //makes things update once a second instead of a thousand times
        InvokeRepeating("EverySecond", 1f, 1f);
    }

    void Update()
    {
        //time counting
        currentTime += Time.deltaTime;
        intTime = Mathf.RoundToInt(currentTime);

        if (Input.anyKeyDown && issuesActive == 0)
        {
            WorkProgress();
        }
    }

    void EverySecond()
    {
        if (intTime >= 217)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }
        
        TimeReadout();
        EventChance();
    }

    //does the math for the timer and prints it
    void TimeReadout()
    {        
        int time = intTime * 1200;
        
        int mins = (time / 60) % 60;
        int hrs = (time / 3600);

        if (hrs >= 24 && hrs < 48)
        {
            day = "8";
        }
        else if (hrs >= 48)
        {
            day = "9";
        }

        hrs %= 24;
        if (hrs % 24 <= 11) 
        {
            amPM = "AM";
        }
        else
        {
            amPM = "PM";
        }

        hrs %= 12;
        if (hrs == 0) 
        { 
            hour = "12";
        }
        else
        {
            hour = hrs.ToString();
        }

        if (mins == 0)
        {
            minutes = "00";
        }
        else
        {
            minutes = mins.ToString();
        }


        timeBar.text = "6/" + day + " " + hour + ":" + minutes + " " + amPM;
    }

    void EventChance()
    {
        issueChance += intTime - lastIssue;

        int happen = issueChance + Random.Range(1, 15);
        if (happen >= 20)
        {
            int index = Random.Range(0, 4);
            if (!notifs[index].gameObject.activeSelf)
            {
                notifs[index].SetActive(true);
                audioSource.clip = notifSounds[index];
                audioSource.Play();
                issuesActive++;
            }

            lastIssue = intTime;
            issueChance = 0;
        }
    }

    public void RemoveNotif(int index)
    {
        notifs[index].SetActive(false);
        issuesActive--;
    }

    void WorkProgress()
    {
        progress++;
        if (progress >= 100)
        {
            //mark task complete
            tasksToggles[tasksDone].isOn = true;
            tasksTexts[tasksDone].text = "<s>" + tasksStrings[tasksDone] + "</s>";
            tasksTexts[tasksDone].color = new Color32(165, 165, 165, 255);
            tasksDone++;
            
            //win condition
            if (tasksDone >= 15)
            {
                Time.timeScale = 0;
                winScreen.SetActive(true);
            }

            progress = 0;
        }
        
        progDebug.text = progress.ToString();
    }
}
