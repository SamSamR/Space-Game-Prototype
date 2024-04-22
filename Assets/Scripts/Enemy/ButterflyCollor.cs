using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCollor : MonoBehaviour
{
    //gets renderer
    Renderer[] rend;


    //get color values
    Color blue = new Color(191, 191, 191, 0);
    Color red = new Color(191, 0, 0, 0);

    public bool colorblue = true;
    public float timer = 5f;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
       Shader.EnableKeyword("KEYWORD_ON");

        //enemy = GameObject.Find("EnemyB");
        rend = GetComponentsInChildren<Renderer>();

        //wait to turn red
        StartCoroutine(colorTimer());
        Debug.Log("b" +timer);     
        timer = 60f;

    }

    // Update is called once per frame
    void Update()
    {
        if (colorblue == false)
        {
            StartCoroutine(colorTimer());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if butterfly and player collide turn blue

        if (collision.gameObject.name == "PLayer")
        {
            Debug.Log("hit player");
            //find shader
            foreach (Renderer m in rend)
            {
                if(m.gameObject.tag != "nope")
                {
                    m.material.shader = Shader.Find("Shader Graphs/Butterfly PBR Graph");
                    m.material.SetColor("ButterflyColor", blue);
                }
                
            }           
            colorblue = true;
        }
    }

    private IEnumerator colorTimer()
    {
        yield return new WaitForSeconds(timer);
        //get material
        //find shader
        foreach (Renderer m in rend)
        {
            if(m.gameObject.tag != "nope")
            {
                m.material.shader = Shader.Find("Shader Graphs/Butterfly PBR Graph");
                m.material.SetColor("ButterflyColor", red);
            }
           
        }
        
        colorblue = false;
    }
}
