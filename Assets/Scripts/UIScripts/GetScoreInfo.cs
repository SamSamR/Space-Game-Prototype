using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreInfo : MonoBehaviour
{
    public Text points;
    public Text clock;
    public Text speed;

    // Start is called before the first frame update
    void Start()
    {
        points.text = "" + PlayerPrefs.GetInt("EnemiesDestroid");

        clock.text = PlayerPrefs.GetInt("Hr") + ":" + PlayerPrefs.GetInt("Min") + ":" + PlayerPrefs.GetInt("Sec");
        speed.text = "" + (int)PlayerPrefs.GetFloat("MaxSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
