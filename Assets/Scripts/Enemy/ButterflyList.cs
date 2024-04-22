using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyList : MonoBehaviour
{
    public string enemyTag;
    public Transform[] allGoals;
    public List<Transform> GoalObjects;

    public Transform child1;
    public Transform child2;
    public Transform child3;

    // Start is called before the first frame update
    void Start()
    {
        //get all children game objects of parent game Object
        allGoals = GetComponentsInChildren<Transform>();
        GoalObjects = new List<Transform>();

        foreach (Transform child in allGoals)
        {
            enemyTag = child.tag;
            if (enemyTag == "Untagged")
            {
               GoalObjects.Add(child);
                // child.gameObject.SetActive(false);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
       

    }

   
}
