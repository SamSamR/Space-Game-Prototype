using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




//psudo code for AI
//need 3 raycasts for FOV (L, M, R), must be a cone???
//maybe need 2 raycasts one on each side to determine if to turn left or right
//need 1 raycast to track player

//if in range and sight of player follow player
//if loses player return to path


    //Piceis lvl
/////frog AI: can use raycast and offmesh link  and look at to attack player
//Jellyfish AI: follow path and attack player at close range, must return to location in pattern
//Picis AI: follow path and attacks player, must return to path, and navigate around objects

    //sagitarius lvl
//bird AI: must follow path and attacks player when in range, must return to path
//Aiming AI: Aims at player when they are faraway, wont aim if close up, fires different attacks based off of health
//sagitarius moving AI: stands and retretes when player gets close and trys to deal damage



