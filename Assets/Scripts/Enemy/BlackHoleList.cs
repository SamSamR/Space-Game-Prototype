using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleList : MonoBehaviour
{
    public string enemyTag;
    public Transform[] allBlackHoles;
    public List<Transform> BlackHoleObjects;

    public Transform child1;
    public Transform child2;
    public Transform child3;

    // Start is called before the first frame update
    void Start()
    {
        //get all children game objects of parent game Object
        allBlackHoles = GetComponentsInChildren<Transform>();
        BlackHoleObjects = new List<Transform>();

        foreach (Transform child in allBlackHoles)
        {
            enemyTag = child.tag;
            if (enemyTag == "blackHole")
            {
                BlackHoleObjects.Add(child);
               // child.gameObject.SetActive(false);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        //01 23 45 67 89 1011   1213 1415 1617 1819 2021 2223

        //if butteryfly = red
        //start activating blak holes

        //if butterfly != red 
        //stop activating black holes 
        //deactivate any active black holes

        /* for(int i = 0; i <= 23; i++)
         {
             child1 = allBlackHoles[i];
             child1.gameObject.SetActive(true);

             //StartCoroutine(Pause(i));

             child2 = allBlackHoles[i+1];
             child2.gameObject.SetActive(true);

             //wait then deactivate
            // StartCoroutine(Pause2(i));
         }*/

        //StartCoroutine(blackHoleSpawn());

    }

    //blackhole spawn
    private IEnumerator blackHoleSpawn()
    {
        for (int i = 0; i <= 21; i = i + 2)
        {

            this.child1 = allBlackHoles[i];
            this.child1.gameObject.SetActive(true);

            //wait to spawn 2nd
            Debug.Log("wait to spawn 2nd");
            yield return new WaitForSeconds(5f);

            this.child2 = allBlackHoles[i + 1];
            this.child2.gameObject.SetActive(true);


            //wait then deactivate 1
            yield return new WaitForSeconds(5f);
            this.child1.gameObject.SetActive(false);


            //wait then deactivate 2 and activate 3
            yield return new WaitForSeconds(5f);
            Debug.Log("waited 10seconds");          
            this.child2.gameObject.SetActive(false);
            

            //step 0
            //activate portal 1
            //bull heads to portal one

            //step 1
            //when bull is 1/2 distance to portal 1
            //activate portal 2

            //step 2
            //when bull is at portal 1
            //teleport bull to portal 2
            //wait x
            // then deactivate portal 1

            //step 3
            //bull heads to portal 3

            //step 4
            //when bull is 1/2 distance to portal 3
            //Activate portal 3
            //deactivate portal 2

            //repeate from step 2 till stop

        }
    }


    //pause
    private IEnumerator Pause(int i)
    {
        child1 = allBlackHoles[i];
        child1.gameObject.SetActive(true);

        Debug.Log("wait to spawn 2nd");
        yield return new WaitForSeconds(20f);

        child2 = allBlackHoles[i + 1];
        child2.gameObject.SetActive(true);
    }

    //pause
    private IEnumerator Pause2(int i)
    {
        child1 = allBlackHoles[i];
        child2 = allBlackHoles[i + 1];

        yield return new WaitForSeconds(20f);
        Debug.Log("waited 20seconds");

        child1.gameObject.SetActive(false);
        child2.gameObject.SetActive(false);
    }
}
