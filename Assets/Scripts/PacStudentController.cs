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

    public AudioClip[] audioClip;

    public GameObject[] Ghost;
    void Start()
    {
        InvokeRepeating("onTimeInv", 1f, 0.1f);
        InvokeRepeating("addstrawberry", 3f, 10f);
        InvokeRepeating("addpard", 3f, 10f);
        
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
            if (collision.collider.gameObject.transform.GetComponent<GhostController>().speed == 0)
            {
                livercount++;
                collision.collider.gameObject.transform.position = new Vector3(2.18f, -3.55f, 0);
                this.transform.GetComponent<AudioSource>().PlayOneShot(audioClip[4]);
                collision.collider.gameObject.transform.GetComponent<GhostController>().speed = 0.015f;
            }
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
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClip[0]);//play dead
        }
        else if (collision.collider.tag.Equals("wall"))
        {
            //play music
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClip[1]);//coll wall
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

            //win or unwin
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
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClip[2]);//play food
        }
        else if (collision.tag.Equals("evolve"))
        {
            Destroy(collision.gameObject);
            Invoke("fixspeed", 4f);
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClip[3]);//play evolve
            Ghost[0].transform.GetComponent<GhostController>().speed = 0f;
            Ghost[1].transform.GetComponent<GhostController>().speed = 0f;
            Ghost[2].transform.GetComponent<GhostController>().speed = 0f;
            Ghost[3].transform.GetComponent<GhostController>().speed = 0f;
        }
        else if (collision.tag.Equals("food1"))
        {
            Destroy(collision.gameObject);
            scorecount += 10;
            score.transform.GetComponent<TextMeshProUGUI>().text = "Score:" + scorecount;
            //play music
            this.transform.GetComponent<AudioSource>().PlayOneShot(audioClip[3]);//play evolve
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


    public void addpard()
    {
        int r = Random.Range(0, GameObject.Find("back").transform.GetComponent<LevelGenerator>().listGame.Count);
        GameObject game = Instantiate<GameObject>(GameObject.Find("back").transform.GetComponent<LevelGenerator>().gameObjects[7]);
        game.transform.position = GameObject.Find("back").transform.GetComponent<LevelGenerator>().listGame[r];
        game.transform.parent = GameObject.Find("back").transform;
    }

    public void fixspeed()
    {
        Ghost[0].transform.GetComponent<GhostController>().speed = 0.015f;
        Ghost[1].transform.GetComponent<GhostController>().speed = 0.015f;
        Ghost[2].transform.GetComponent<GhostController>().speed = 0.015f;
        Ghost[3].transform.GetComponent<GhostController>().speed = 0.015f;
    }
}
