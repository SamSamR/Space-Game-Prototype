using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
   // public Text clock;
   // public Text points;
    //private int EnemiesDestroid = 0;
    private int realTime;
    private int sec = 0;
    private int min = 0;
    private int hr = 0;

    void Start()
    {


        //EnemiesDestroid = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerFloatMove>().EnemiesDestroid;
       // points.text = "" + PlayerPrefs.GetInt("EnemiesDestroid");
    }

    // Update is called once per frame
    void Update()
    {
        realTime = (int)Time.timeSinceLevelLoad;

        sec = (int)(realTime % 60);
        min = (int)(realTime / 60) % 60;
        hr = (int)((realTime / 60) / 60) % 60;

        //clock.text = hr + ":" + min + ":" + sec;

        PlayerPrefs.SetInt("Hr", hr);
        PlayerPrefs.SetInt("Min", min);
        PlayerPrefs.SetInt("Sec", sec);

    }
}
