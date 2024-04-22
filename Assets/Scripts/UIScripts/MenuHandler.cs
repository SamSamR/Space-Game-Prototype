using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public string gameScene;
    public string Level1;
    public string Level2;
    public string Level3;
    public string Level4;
    public string LevelComplete;
    public string GameOver;
    public string GameWon;

    public int EnemiesDestroid = 0;
    public int MaxSpeedReached = 0;


    public void returnMain()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void returnLevel1()
    {
        SceneManager.LoadScene(Level1);

        PlayerPrefs.SetInt("EnemiesDestroid", EnemiesDestroid);
        PlayerPrefs.SetFloat("MaxSpeed", MaxSpeedReached);

        PlayerPrefs.SetString("currentLevel", Level1);
        PlayerPrefs.SetString("nextLevel", Level2);
    }

    public void returnLevel2()
    {
        SceneManager.LoadScene(Level2);

        PlayerPrefs.SetInt("EnemiesDestroid", EnemiesDestroid);
        PlayerPrefs.SetFloat("MaxSpeed", MaxSpeedReached);

        PlayerPrefs.SetString("currentLevel", Level2);
        PlayerPrefs.SetString("nextLevel", Level3);
    }

    public void returnLevel3()
    {
        SceneManager.LoadScene(Level3);

        PlayerPrefs.SetInt("EnemiesDestroid", EnemiesDestroid);
        PlayerPrefs.SetFloat("MaxSpeed", MaxSpeedReached);

        PlayerPrefs.SetString("currentLevel", Level3);
        PlayerPrefs.SetString("nextLevel", Level4);
    }

    public void returnLevel4()
    {
        SceneManager.LoadScene(Level4);

        PlayerPrefs.SetInt("EnemiesDestroid", EnemiesDestroid);
        PlayerPrefs.SetFloat("MaxSpeed", MaxSpeedReached);

        PlayerPrefs.SetString("currentLevel", Level4);
        PlayerPrefs.SetString("nextLevel", gameScene);
    }

    //go to level complete
    public void returnLvlFin()
    {
        SceneManager.LoadScene(LevelComplete);
        Cursor.lockState = CursorLockMode.None;

        string BossSpawn = PlayerPrefs.GetString("currentLevel");

        GameObject Player = GameObject.Find("thePlayer");
        GameObject Bull = GameObject.Find("Bull");
        GameObject Fish = GameObject.Find("Fish");
        GameObject Centaur = GameObject.Find("Centaur");

        switch (BossSpawn)
        {
            case "Level1":
                Player.SetActive(false);
                Bull.SetActive(true);
                Fish.SetActive(false);
                Centaur.SetActive(false);
                break;

            case "Level2":
                Player.SetActive(false);
                Bull.SetActive(false);
                Fish.SetActive(true);
                Centaur.SetActive(false);
                break;

            case "Level3":
                Player.SetActive(false);
                Bull.SetActive(false);
                Fish.SetActive(false);
                Centaur.SetActive(true);
                break;

            case "Level4":
                Player.SetActive(false);
                Bull.SetActive(false);
                Fish.SetActive(false);
                Centaur.SetActive(true);
                break;

            default:
                Debug.Log("In default");

                Player.SetActive(false);
                Bull.SetActive(false);
                Fish.SetActive(false);
                Centaur.SetActive(false);
                break;
        }

      //  PlayerPrefs.SetFloat("MaxSpeed", MaxSpeedReached);
    }

    public void returnGameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(GameOver);
    }

    public void returnGameWon()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(GameWon);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("nextLevel"));
    }

    public void setPanel(int p)
    {
        switch (p)
        {
            case 0:
                p1.SetActive(true);
                p2.SetActive(false);
                p3.SetActive(false);
                p4.SetActive(false);
                break;

            case 1:
                p1.SetActive(false);
                p2.SetActive(true);
                p3.SetActive(false);
                p4.SetActive(false);
                break;

            case 2:
                p1.SetActive(false);
                p2.SetActive(false);
                p3.SetActive(true);
                p4.SetActive(false);
                break;

            case 3:
                p1.SetActive(false);
                p2.SetActive(false);
                p3.SetActive(false);
                p4.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void easyDificulty()
    {
        PlayerPrefs.SetInt("MaxHealth", 1000);
    }

    public void mediumDificulty()
    {
        PlayerPrefs.SetInt("MaxHealth", 100);
    }

    public void HardDificulty()
    {
        PlayerPrefs.SetInt("MaxHealth", 10);
    }
}