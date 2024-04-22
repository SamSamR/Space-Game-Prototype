using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text speed;
    public Text MaxSpeed;

    private GameObject thePlayer;
    PlayerFloatMove playerScript;

    private float currentSpeed;
    private float maxSpeed;

    private void Start()
    {
        //get the player 
        thePlayer = GameObject.Find("PLayer");
        playerScript = thePlayer.GetComponent<PlayerFloatMove>();

    }

    // Update is called once per frame
    void Update()
    {
        //get current speed
        currentSpeed = playerScript.speed;

        //get max speed
        maxSpeed = playerScript.maxSpeed;

        if(currentSpeed > 9 && currentSpeed <= 10)
        {
            currentSpeed = 10;
        }
        speed.text = "" + (int)currentSpeed + " / " + (int)maxSpeed;
    }

}
