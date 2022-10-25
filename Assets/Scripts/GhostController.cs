using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    public float speed;
    int ranges = 0;//0 left 1 right 2 up 3 down

    public AudioClip[] AudioClip;
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = new LevelGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        switch (ranges)
        {
            case 0:
                {
                    this.transform.Translate(-speed, 0,0);//left
                    this.transform.GetComponent<Animator>().SetInteger("run", 2);
                }break;
            case 1:
                {
                    this.transform.Translate(speed, 0, 0);//right
                    this.transform.GetComponent<Animator>().SetInteger("run", 3);
                }
                break;
            case 2:
                {
                    this.transform.Translate(0, speed, 0);//top
                    this.transform.GetComponent<Animator>().SetInteger("run", 1);
                }
                break;
            case 3:
                {
                    this.transform.Translate(0, -speed, 0);//down
                    this.transform.GetComponent<Animator>().SetInteger("run", 0);
                }
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("wall"))
        {
            List<int> vs = levelGenerator.getLORR(this.transform.position);
            ranges = vs[Random.Range(0, vs.Count)];
            //foreach (int s in vs)
            //{
            //    Debug.Log("sss:::" + s);
            //}
            //play music
            //this.transform.GetComponent<AudioSource>().PlayOneShot(AudioClip[0]);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.collider.tag.Equals("wall"))
        //{
        //    List<int> vs =  levelGenerator.getLORR(this.transform.position);
        //    ranges = vs[Random.Range(0, vs.Count)];
        //    foreach(int s in vs)
        //    {
        //        Debug.Log("sss:::" + s);
        //    }

        //}
    }
}
