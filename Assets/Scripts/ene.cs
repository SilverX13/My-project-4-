using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ene : MonoBehaviour
{
    public float speed;
    int ranges = 0;//0 left 1 right 2 up 3 down
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (ranges)
        {
            case 0:
                {
                    this.transform.Translate(-speed, 0,0);
                }break;
            case 1:
                {
                    this.transform.Translate(speed, 0, 0);
                }
                break;
            case 2:
                {
                    this.transform.Translate(0, speed, 0);
                }
                break;
            case 3:
                {
                    this.transform.Translate(0, -speed, 0);
                }
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.tag.Equals("wall"))
        //{
            
        //    ranges = Random.Range(0, 4);
        //    Debug.Log("sss:::"+ ranges);
        //}
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("wall"))
        {

            ranges = Random.Range(0, 4);
            Debug.Log("sss:::" + ranges);
        }
    }
}
