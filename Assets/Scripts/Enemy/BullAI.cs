using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullAI : MonoBehaviour
{
    public GameObject theList;
    public GameObject portalPrefab;
    public BlackHoleList bhScript;
    public List<Transform> BlackHolePOS;

    private Transform child1;
    private Transform child2;

    public Transform currentTarget;
    public float portalDistance = 400f;

    public bool colideCheck = false;

    public int goal = 0;

   // public Transform player;

    public Rigidbody EnemyRig;
    public float speed = 5f;

    public float slerpRot = 0.01f;

    public float deactivationTime;

    public bool teleport = false;

    public bool butterflyRed = false;

    private int i = 0;

    public Transform center;

    public MeshRenderer pr = null;

    public MeshRenderer pr2 = null;

    public GameObject butterfly;

    Vector3 goal1;
    Vector3 goal2;
    Vector3 goal3;
    Vector3 goal4;

    Vector3[] GoalsArray;

    public Vector3 target;

    public Animator bullAnime;

    public bool liedown = true;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRig = this.gameObject.GetComponent<Rigidbody>();


        //find goals
        goal1 = GameObject.Find("Cylinder").transform.position;
        goal2 = GameObject.Find("Cylinder (1)").transform.position;
        goal3 = GameObject.Find("Cylinder (2)").transform.position;
        goal4 = GameObject.Find("Cylinder (3)").transform.position;

        GoalsArray = new Vector3[10];
        GoalsArray[0] = goal1;
        GoalsArray[1] = goal2;
        GoalsArray[2] = goal3;
        GoalsArray[3] = goal4;
        

        //find player
        //player = GameObject.FindWithTag("Player").transform;

        //get black holes
        theList = GameObject.Find("BlackHoleList");
        bhScript = theList.GetComponent<BlackHoleList>();
        //Debug.Log(bhScript.BlackHoleObjects.Count);

        //locations
        //BlackHolePOS = bhScript.BlackHoleObjects;

        //first target
        //currentTarget = BlackHolePOS[goal];

        // this.transform.position = bhScript.BlackHoleObjects[goal].GetComponent<Transform>().position;


        //animation lie down
        bullAnime = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (liedown == true)
        {
            StartCoroutine(lie());
        }
        else
        {


            //if butterfly is red
            butterfly = GameObject.Find("Butterfly");

            butterflyRed = !butterfly.GetComponent<ButterflyCollor>().colorblue;

            EnemyRig.velocity = transform.forward * speed / 30;
            bullAnime.SetBool("run", true);

            // EnemyRig.velocity = transform.forward * speed;

            if (butterflyRed == true)
            {
                if (goal <= 21)
                {
                    
                    bullAnime.SetBool("walk", false);
                    speed = 350f;
                    //run to portal 2
                    //child2 = BlackHolePOS[goal + 1];
                    child2 = bhScript.BlackHoleObjects[goal + 1];
                    //currentTarget = BlackHolePOS[goal + 1];
                    currentTarget = bhScript.BlackHoleObjects[goal + 1];

                    this.transform.LookAt(currentTarget.transform.position - new Vector3(0, 25, 0));

                    //move enemy closer to target
                    EnemyRig.velocity = transform.forward * speed;

                    if (Vector3.Distance(transform.position, currentTarget.transform.position) < portalDistance)
                    {
                        pr = currentTarget.gameObject.GetComponent<MeshRenderer>();
                        pr.enabled = true;
                        StartCoroutine(blackHoleSpawn());
                    }



                    //colide with portal 2
                    if (Vector3.Distance((transform.position - new Vector3(0, 25, 0)), currentTarget.transform.position) <= 50f)
                    {
                        this.goal = this.goal + 2;
                        //this.transform.position = BlackHolePOS[goal].transform.position;
                        i = i + 1;
                        this.transform.position = bhScript.BlackHoleObjects[goal].transform.position;
                        pr2 = bhScript.BlackHoleObjects[goal].gameObject.GetComponent<MeshRenderer>();
                        pr2.enabled = true;
                        StartCoroutine(blackHoleSpawn2());

                    }






                }
                else
                {
                    goal = 0;
                    i = 0;
                }


            }
            else
            {
                //animation walk
                bullAnime.SetBool("walk", true);
                bullAnime.SetBool("run", false);

                //walk to center
                speed = 150;
                target = GoalsArray[0];

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

                //check if enemy has reached position
                if (Vector3.Distance(transform.position, target) < 15f && goal <= 4)
                {
                    if (goal == 4)
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
    }


    

    //blackhole spawn
    private IEnumerator blackHoleSpawn()
    {        
        yield return new WaitForSeconds(deactivationTime);
        pr.enabled = false;
    }

    //blackhole spawn
    private IEnumerator blackHoleSpawn2()
    {
        yield return new WaitForSeconds(deactivationTime);
        pr2.enabled = false;
    }

    private IEnumerator lie()
    {
        yield return new WaitForSeconds(20);
        //bullAnime.SetBool("run", true);
        liedown = false;
        

    }


}
