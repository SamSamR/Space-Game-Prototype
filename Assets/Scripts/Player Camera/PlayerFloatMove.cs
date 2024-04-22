using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFloatMove : MonoBehaviour
{
    public Rigidbody myRig;
    public Transform ringPos;
    public GameObject ring;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float RotateSpeed = 5f;

    public int maxSpeed = 50;
    public float speed = 0;

    public int health = 100;
    public int maxHealth = 100;

    public float stunTime = 0.65f;
    public bool controller = true;
    public bool childDestroid = false;
    public int EnemiesDestroid = 0;

    public float attack = 0;
    public int ringCount = -1;

    private bool useRings = false;
    public bool ringUI = true;

    GameObject theUI;

    public ParticleSystem collisionParticle;
    public ParticleSystem spinParticle;
    public ParticleSystem accelParticle;

    public MenuHandler sceneChange;

    public AudioSource audioStun;
    public AudioSource audioAccel;
    public AudioSource audioRing;

    // Start is called before the first frame update
    void Start()
    {
        audioStun = GetComponent<AudioSource>();
       // audioAccel = GetComponent<AudioSource>();
        //audioRing = GetComponent<AudioSource>();

        maxHealth = PlayerPrefs.GetInt("MaxHealth");
        this.health = PlayerPrefs.GetInt("MaxHealth");


        myRig = this.gameObject.GetComponent<Rigidbody>();

        if (myRig == null)
        {
            //throw exception
            throw new System.Exception("Could not find Ridgedbody");
        }

        //put mouse at center of screen
        Cursor.lockState = CursorLockMode.Locked;

        theUI = GameObject.Find("UI");

    }


   
    void FixedUpdate()
    {
        //move player
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");


        //if not stunned
        if (controller)
        {
            //roate based on mouse location
            {
                yaw += RotateSpeed * x;
                pitch -= RotateSpeed * y;

                Quaternion Rotation = Quaternion.Euler(pitch, yaw, transform.forward.z);

                transform.rotation = Quaternion.Lerp(Rotation, transform.rotation, 0.125f);                
            }


            //move forward when hitting w
            {
            if (Input.GetButton("Vertical") == true && Input.GetMouseButton(0) == false)
            {
               if (this.speed < 10)
               {
                    //start speed
                    this.speed = this.speed + 0.25f;
               }
                
                //add force to player
               // myRig.AddForce(transform.forward * this.speed);

                //playerVelocity = myRig.velocity;

            }
  
            }

            //break with space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioAccel.Stop();
                myRig.velocity = new Vector3(0, 0, 0);
                this.speed = 0;

                StartCoroutine(Pause2());
            }

            //create ring
            if (Input.GetKey(KeyCode.Space) == true && useRings == true)
            {
                useRings = false;
                StartCoroutine(RingCount());
            }

            //straif
            {
                //straif left
                if (Input.GetKeyDown(KeyCode.A))
                {
                    spinParticle.Play();
                    myRig.AddForce(-1 * transform.right * 1000f);

                }
                //straif right
                if (Input.GetKeyDown(KeyCode.D))
                {
                    spinParticle.Play();
                    myRig.AddForce(transform.right * 1000f);
                }

                spinParticle.Stop();
            }

            //acceleration boost
            {
            //if click is held down increase acceleration
            if (Input.GetMouseButton(0) == true && Input.GetButton("Vertical") == true)
            {
                audioAccel.Play();
                accelParticle.Play();
                                   

                if (speed < maxSpeed - 0.1f)
                {
                    
                    this.speed = this.speed + 0.5f;
                } 
            }

            }

            //set Max speed acheived for score screen
            PlayerPrefs.SetFloat("MaxSpeed", this.speed);
        }


        //slow down speed
        { 
        if ((Input.GetMouseButton(0) == false && Input.GetButton("Vertical") == false) || (Input.GetButton("Vertical") == false && Input.GetMouseButton(0) == true) || (Input.GetButton("Vertical") == true && Input.GetMouseButton(0) == false && this.speed > 10))
        {
            //stop particles
            accelParticle.Stop();

            audioAccel.Stop();

            if ((int)speed > 0)
            {                
                this.speed -= 0.25f;
            }
        }

        }


        //add force to player
        myRig.AddForce(transform.forward * this.speed);

        //check player health
        if(this.health <= 0)
        {
            sceneChange.returnGameOver();
        }

    }


    //collide with power ups
    private void OnTriggerEnter(Collider other)
    {
        //increase acceleration of player
        if (other.tag == "UpAccel")
        {
            float test = speed + 10;
            if (test <= maxSpeed)
            {
                this.speed = this.speed + 10;

                PlayerPrefs.SetFloat("MaxSpeed", this.speed);
            }

        }
        //increase Max acceleration of player
         if (other.tag == "UpMaxAccel")
        {
            this.maxSpeed = this.maxSpeed + 10;
            //destroy object
            Destroy(other.gameObject);
        }
    }


    //stun timer
    private IEnumerator Stun()
    {
        yield return new WaitForSeconds(stunTime);
        this.speed = 10;
        controller = true;
    }

    //pause
    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        childDestroid = false;
    }

    //pause2
    private IEnumerator Pause2()
    {
        yield return new WaitForSeconds(1f);
        useRings = true;
    }

    //create a ring
    private IEnumerator RingCount()
    {
        PlayerUIScript UIScript = theUI.GetComponent<PlayerUIScript>();
        ringCount = UIScript.ringCount;

        if (ringCount <= 10 && ringCount >= -1)
        {
            audioRing.Play(0);
            GameObject newRing = Instantiate(ring, ringPos.position, transform.rotation);
            newRing.transform.Rotate(transform.rotation.x + 90, transform.rotation.y, transform.rotation.z);
            
            ringCount++;
            ringUI = false;
            StartCoroutine(RingIncrease());
            yield return new WaitForSeconds(1.5f);
        }
        else
        {
            
        }
         
    }

    private IEnumerator RingIncrease()
    {
        if (ringCount != 9)
        {
            yield return new WaitForSeconds(10f);
            ringCount--;
            ringUI = true;
        }
        else
        {
            yield return new WaitForSeconds(10f);
            ringCount = 9;
            ringUI = true;
        }
    }


    //collide with object
    private void OnCollisionEnter(Collision collision)
    {
        collisionParticle.Play();

        //already stunned can't get stunned again
        if (controller == false)
        {
            return;
        }

        GameObject enemyHit = collision.contacts[0].otherCollider.transform.gameObject;
        string enemyTag = enemyHit.tag;
        string name = enemyHit.name;
        if (name == "EnemySmall" || name == "EnemyMedium" || name == "EnemyLarge" || name == "EnemyExtraLarge" || name == "EnemyJumbo")
        {
            //get enemy info
            this.attack = this.speed;
            Enemy enemyInfo = collision.gameObject.GetComponent<Enemy>();
            enemyInfo.Health(enemyTag);
            int enemyHP = enemyInfo.health;
           
            //calculate attack
            if (attack >= enemyHP)
            {
                childDestroid = true;
                this.attack = enemyHP;
                Pause();
                //destroy enemy
                Destroy(enemyHit);

                //increase enemydestroid counter
                this.EnemiesDestroid++;
                PlayerPrefs.SetInt("EnemiesDestroid", this.EnemiesDestroid);
            }
            else
            {
                //player can't use controls
                controller = false;

                //decrease health
                for(int i = 0; i < 10; i++)
                {
                    this.health = this.health - 2;
                    i++;
                }


                //stun player and set speed back to 10
                StartCoroutine(Stun());
            }

        }
        else
        {
            //player can't use controls
            controller = false;

            //decrease health
            for (int i = 0; i < 5; i++)
            {
                this.health = this.health - 2;
                i++;
            }

            //stun player and set speed back to 10
            audioStun.Play(0);
            StartCoroutine(Stun());
        }


        //go to next level
        if (collision.gameObject.name == "WinOrb")
        {
            //SceneManager.LoadScene("LevelComplete");

            sceneChange.returnLvlFin();
        }

        if(collision.gameObject.name == "FinalWinOrb")
        {
            sceneChange.returnGameWon();
        }

    }

}