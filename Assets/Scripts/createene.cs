using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createene : MonoBehaviour
{
    public GameObject[] games;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects[0] = Instantiate<GameObject>(games[0]);
        gameObjects[0].transform.position = new Vector3(-1.235572f, -0.2876849f, 0);

        gameObjects[1] = Instantiate<GameObject>(games[1]);
        gameObjects[1].transform.position = new Vector3(2.47f, 3.17f, 0);


        //gameObjects[2] = Instantiate<GameObject>(games[2]);
        //gameObjects[2].transform.position = new Vector3(2.47f, 3.17f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
