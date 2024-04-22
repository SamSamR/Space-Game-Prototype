using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 0;
    public int currentHealth = 0;

    public string enemyTag;
    public Rigidbody myRig;

    public Transform[] allChildren;
    public List<string> childObjects;

    //public bool ChildDestroid;

    public GameObject thePlayer;
    PlayerFloatMove playerScript;

    public GameObject winOrb;

    public void Start()
    {
        //get the player 
        thePlayer = GameObject.Find("PLayer");
        playerScript = thePlayer.GetComponent<PlayerFloatMove>();

        //get all children game objects of parent game Object
        allChildren = GetComponentsInChildren<Transform>();
        childObjects = new List<string>();
        foreach (Transform child in allChildren)
        {
            enemyTag = child.tag;
            if (enemyTag != "Untagged" || enemyTag != "boss")
            {
                Health(enemyTag);

                maxHealth = maxHealth + this.health;

                childObjects.Add(enemyTag);
            }
        }

        currentHealth = maxHealth;
    }


    public void Update()
    {
        //check if health = 0 and destroy object
        if(currentHealth == 0)
        {
            if(enemyTag == "boss")
            {
                Instantiate(winOrb, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
        }

        float playerAttack = playerScript.attack;
        if (playerScript.childDestroid == true)
        {
            currentHealth = 0;

            allChildren = GetComponentsInChildren<Transform>();
            childObjects = new List<string>();
            foreach (Transform child in allChildren)
            {
                enemyTag = child.tag;
                if (enemyTag != "Untagged" || enemyTag != "boss")
                {
                    Health(enemyTag);

                    currentHealth = currentHealth + this.health;

                    childObjects.Add(enemyTag);
                }
            }
        }
        
    }



    public void Health()
    {
        health = 10;
        enemyTag = gameObject.tag;
    }

    public void Health(string enemyTag)
    {
        switch (enemyTag)
        {
            case "small":
                this.health = 10;
                break;
            case "medium":
                this.health = 30;
                break;
            case "large":
                this.health = 60;
                break;
            case "extraLarge":
                this.health = 80;
                break;
            case "jumbo":
                this.health = 100;
                break;
            default:
                this.health = 0;
                break;
        }
       // Debug.Log("enemy tag: " + enemyTag + " health: " + health);
    }

    public void Movement()
    {

    }

    public void AI()
    {

    }
}
