using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacstudent : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed, 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 1);
        }else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed, 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 0);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed, 0, 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 3);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed, 0, 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 0);
            this.transform.GetComponent<Animator>().SetInteger("run", 2);

        }
    }
}
