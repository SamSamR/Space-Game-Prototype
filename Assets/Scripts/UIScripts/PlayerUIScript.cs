using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    public Image HealthBar;
    public Image SpeedBar1;
    public Image SpeedBar2;

    public float currentHealth;
    public float maxHealth;

    public float currentSpeed;
    public float maxSpeed1;
    public float maxSpeed2;

    public int ringCount;

    public GameObject thePlayer;
    PlayerFloatMove playerScript;


    public GameObject ring1;
    public GameObject ring2;
    public GameObject ring3;
    public GameObject ring4;
    public GameObject ring5;
    public GameObject ring6;
    public GameObject ring7;
    public GameObject ring8;
    public GameObject ring9;
    public GameObject ring10;

    public GameObject[] ringsArray;

    private float sec = 0;

    public bool ringUI;

    private void Start()
    {
        //get the player 
        thePlayer = GameObject.Find("PLayer");
        playerScript = thePlayer.GetComponent<PlayerFloatMove>();

        ringsArray = new GameObject[10];
        
        ringsArray[0] = ring10;
        ringsArray[1] = ring9;
        ringsArray[2] = ring8;
        ringsArray[3] = ring7;
        ringsArray[4] = ring6;
        ringsArray[5] = ring5;
        ringsArray[6] = ring4;
        ringsArray[7] = ring3;
        ringsArray[8] = ring2;
        ringsArray[9] = ring1;
        


    }

    // Update is called once per frame
    void Update()
    {
  
        //get ring count
        ringCount = playerScript.ringCount;

        //get ring count
        ringUI = playerScript.ringUI;

        //get current health
        currentHealth = playerScript.health;

        //get max health
        maxHealth = playerScript.maxHealth;

        //get current speed
        currentSpeed = playerScript.speed;

        //get max speed
        maxSpeed2 = playerScript.maxSpeed;


        //fill bar, 0 = draw nothing, 1 = draw whole thing

        //Health bar
        float healthPercentage = currentHealth / maxHealth;
        HealthBar.fillAmount = healthPercentage - 0.1f;


        //Speed Bar 1,  speed <= 10
        float speed1Percentage = currentSpeed / maxSpeed1;
        SpeedBar1.fillAmount = speed1Percentage;
        

        //speed bar 2, speed >= 10
        if(currentSpeed > 10)
        {
            float speed2Percentage = (currentSpeed - 10)/ (maxSpeed2 - 10);
            SpeedBar2.fillAmount = speed2Percentage;
        }
        else
        {
            SpeedBar2.fillAmount = 0;
        }



        //remove rings from UI
        if (ringCount <= 9 && ringCount >=0)
        { 
            GameObject button = ringsArray[ringCount];
            button.SetActive(ringUI);
        }

        Debug.Log(ringCount);
        
    }

}
