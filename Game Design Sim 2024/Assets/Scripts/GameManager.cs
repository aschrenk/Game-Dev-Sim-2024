using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float currentTime;
    public int intTime;
    public int issueChance;

    public TMP_Text timeBar;
    string minutes;
    string hour;
    string day;
    string amPM;

    public GameObject[] notifs;

    void Start()
    {
        //initializes time values
        currentTime = 0f;
        issueChance = 0;
        minutes = "00";
        hour = "12";
        day = "7";
        amPM = "AM";

        //makes things update once a second instead of a thousand times
        InvokeRepeating("EverySecond", 1f, 1f);
    }

    void Update()
    {
        //time counting
        currentTime += Time.deltaTime;
        intTime = Mathf.RoundToInt(currentTime);
    }

    void EverySecond()
    {
        TimeReadout();
        EventChance();
    }

    //does the math for the timer and prints it
    void TimeReadout()
    {
        Debug.Log("Time check " + intTime);
        
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
        issueChance += intTime;

        int happen = issueChance + Random.Range(1, 6);
        if (happen >= 6)
        {
            notifs[Random.Range(0, 4)].SetActive(true);
            issueChance = 0;
        }
    }

    public void RemoveNotif(int index)
    {
        notifs[index].SetActive(false);
    }
}
