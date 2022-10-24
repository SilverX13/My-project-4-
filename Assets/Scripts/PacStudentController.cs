using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacStudentController: MonoBehaviour
{
    public GameObject score;
    int scorecount = 0;

    public GameObject liver;
    int livercount = 3;

    public GameObject gametime;
    float timegame = 0;

    public float speed;

    public GameObject playData;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("onTimeInv", 1f, 0.1f);
        InvokeRepeating("addstrawberry", 3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed, 0);
            //this.transform.GetComponent<Animator>().SetInteger("run", 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 1);
        }else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed, 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 0);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed, 0, 0);
            //this.transform.GetComponent<Animator>().SetInteger("run", 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 3);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed, 0, 0);
            //this.transform.GetComponent<Animator>().SetInteger("run", 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 2);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("tag:" + collision.collider.tag);
        
        if (collision.collider.tag.Equals("enemy"))
        {
            livercount--;
            if (livercount <= 0)
            {
                liver.transform.GetComponent<TextMeshProUGUI>().text = "liver:" + 0;
                //Play death music;
                //Slow for a few seconds and jump to the third scene
                playdata playdata = playData.transform.GetComponent<playdata>();
                playdata.score = score.transform.GetComponent<TextMeshProUGUI>().text;
                playdata.gametime = gametime.transform.GetComponent<TextMeshProUGUI>().text;
                playdata.winOrUnwin = 1;
                DontDestroyOnLoad(playData);
                SceneManager.LoadScene(2);
            }
            else
            {
                liver.transform.GetComponent<TextMeshProUGUI>().text = "liver:" + livercount;
            }
            //play music
        }
        else if (collision.collider.tag.Equals("wall"))
        {
            //play music

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("tag1:" + collision.tag);
        if (collision.tag.Equals("food"))
        {
            Destroy(collision.gameObject);
            scorecount++;
            score.transform.GetComponent<TextMeshProUGUI>().text = "Score:" + scorecount;

            //≈–∂œ ‰”Æ
            GameObject.Find("back").transform.GetComponent<LevelGenerator>().fivecount--;
            if (GameObject.Find("back").transform.GetComponent<LevelGenerator>().fivecount <= 0)
            {
                playdata playdata = playData.transform.GetComponent<playdata>();
                playdata.score = score.transform.GetComponent<TextMeshProUGUI>().text;
                playdata.gametime = gametime.transform.GetComponent<TextMeshProUGUI>().text;
                playdata.winOrUnwin = 0;
                DontDestroyOnLoad(playData);
                SceneManager.LoadScene(2);
            }

            //play music
        }
        else if (collision.tag.Equals("evolve"))
        {
            Destroy(collision.gameObject);
            scorecount += 10;
            score.transform.GetComponent<TextMeshProUGUI>().text = "Score:" + scorecount;
            //play music
        }
    }

    public void onTimeInv()
    {
        timegame += 0.1f*60;

        gametime.transform.GetComponent<TextMeshProUGUI>().text = "Gametime:" + (int)(timegame / 3600%3600) + ":" + (int)(timegame / 60%60) + ":" + (int)(timegame % 60);
    }


    public void addstrawberry()
    {
        int r = Random.Range(0, GameObject.Find("back").transform.GetComponent<LevelGenerator>().listGame.Count);
        GameObject game = Instantiate<GameObject>(GameObject.Find("back").transform.GetComponent<LevelGenerator>().gameObjects[5]);
        game.transform.position = GameObject.Find("back").transform.GetComponent<LevelGenerator>().listGame[r];
        game.transform.parent = GameObject.Find("back").transform;
    }




}
