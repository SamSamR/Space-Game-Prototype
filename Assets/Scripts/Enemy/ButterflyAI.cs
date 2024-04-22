using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAI : MonoBehaviour
{
    public float speed = 2f;
    public float Interpolate = 0.125f;
    public Rigidbody EnemyRig;

    public Vector3 target;

    Vector3 goal1;
    Vector3 goal2;
    Vector3 goal3;
    Vector3 goal4;
    Vector3 goal5;
    Vector3 goal6;
    Vector3 goal7;
    Vector3 goal8;

    Vector3[] GoalsArray;

    public int goal = 0;

    public float range;

    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        EnemyRig = this.gameObject.GetComponent<Rigidbody>();

        //find player
        player = GameObject.FindWithTag("Player").transform;

        //find goals
        goal1 = GameObject.Find("Cube (1)").transform.position;
        goal2 = GameObject.Find("Cube (2)").transform.position;
        goal3 = GameObject.Find("Cube (3)").transform.position;
        goal4 = GameObject.Find("Cube (4)").transform.position;

        goal5 = GameObject.Find("Cube (5)").transform.position;
        goal6 = GameObject.Find("Cube (6)").transform.position;
        goal7 = GameObject.Find("Cube (7)").transform.position;
        goal8 = GameObject.Find("Cube (8)").transform.position;

        GoalsArray = new Vector3[10];
        GoalsArray[0] = goal1;
        GoalsArray[1] = goal2;
        GoalsArray[2] = goal3;
        GoalsArray[3] = goal4;

        GoalsArray[4] = goal5;
        GoalsArray[5] = goal6;
        GoalsArray[6] = goal7;
        GoalsArray[7] = goal8;

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
        transform.localRotation = Quaternion.Slerp(currentRotation, endRotation, 0.125f);

        //move enemy closer to target
        EnemyRig.velocity = transform.forward * speed;

       // range = Vector3.Distance(transform.position, player.position);

        //check if enemy has reached position
        if (Vector3.Distance(transform.position, target) < 25f && goal <= 8)
        {
            if (goal == 8)
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

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
    }

}
