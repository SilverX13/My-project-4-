using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ene : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    public float speed;
    int ranges = 0;//0 left 1 right 2 up 3 down
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
                    //this.transform
                }break;
            case 1:
                {
                    this.transform.Translate(speed, 0, 0);//right
                }
                break;
            case 2:
                {
                    this.transform.Translate(0, speed, 0);//top
                }
                break;
            case 3:
                {
                    this.transform.Translate(0, -speed, 0);//down
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
