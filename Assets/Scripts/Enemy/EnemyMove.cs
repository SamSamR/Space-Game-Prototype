using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public float Interpolate = 0.125f;
    public Rigidbody EnemyRig;

    public Vector3 target;

    Vector3 goal1;
    Vector3 goal2;
    Vector3 goal3;
    Vector3 goal4;

    Vector3[] GoalsArray;

    public int goal = 0;

    public float range;

    Transform player;
   // public GameObject findPlayer;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRig = this.gameObject.GetComponent<Rigidbody>();

        //find player
        player = GameObject.FindWithTag("Player").transform;
        
        //find goals
        goal1 = GameObject.Find("goal1").transform.position;
        goal2 = GameObject.Find("goal2").transform.position;
        goal3 = GameObject.Find("goal3").transform.position;
        goal4 = GameObject.Find("goal4").transform.position;

        GoalsArray = new Vector3[10];
        GoalsArray[0] = goal1;
        GoalsArray[1] = goal2;
        GoalsArray[2] = goal3;
        GoalsArray[3] = goal4;

        target = GoalsArray[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //look at target
        //distance between object and target
        Vector3 relativePos = target - transform.position;
        //rotate object to look at target
        Quaternion endRotation = Quaternion.LookRotation(relativePos);  //(relativePos, vector3 that tells which direction is up);


        //local rotation of object
        Quaternion currentRotation = transform.localRotation;

        //use slerp to slowly turn the object to face the target, slerp(start, end, speed of turn)
        transform.localRotation = Quaternion.Slerp(currentRotation, endRotation, 0.01f);
         
        //move enemy closer to target
        EnemyRig.velocity = transform.forward * speed;

        range = Vector3.Distance(transform.position, player.position);

        //check if enemy has reached position
        if (Vector3.Distance(transform.position, target) < 20f && goal <= 4)
        {
            if(goal == 4)
            {
                goal = 0;
                target = GoalsArray[goal];
            }
            else
            {
                //Debug.Log("move to next target");
                target = GoalsArray[goal];
                goal = goal + 1;
            }
           
        }
    }
}
