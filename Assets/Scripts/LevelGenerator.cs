using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] levelMap =
     {
     {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
     {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
     {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
     {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
     {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
     {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
     {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
     {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
     {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
     {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
     {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
     {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
     {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
     {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
     {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
     };

    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 15; ++i)
        {
            for(int j = 0; j < 14; ++j)
            {
                if (levelMap[i, j] == 1)
                {
                    GameObject game = Instantiate<GameObject>(gameObjects[0]);
                    game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    game.transform.parent = GameObject.Find("back").transform;
                }else if (levelMap[i, j] == 2)
                {
                    GameObject game = Instantiate<GameObject>(gameObjects[1]);
                    game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    game.transform.parent = GameObject.Find("back").transform;
                }
                else if (levelMap[i, j] == 3)
                {
                    GameObject game = Instantiate<GameObject>(gameObjects[2]);
                    game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    game.transform.parent = GameObject.Find("back").transform;
                }
                else if (levelMap[i, j] == 4)
                {
                    GameObject game = Instantiate<GameObject>(gameObjects[3]);
                    game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    game.transform.parent = GameObject.Find("back").transform;
                }
                else if (levelMap[i, j] == 5)
                {
                    GameObject game = Instantiate<GameObject>(gameObjects[4]);
                    game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    game.transform.parent = GameObject.Find("back").transform;
                }
                else if (levelMap[i, j] == 6)
                {
                    GameObject game = Instantiate<GameObject>(gameObjects[5]);
                    game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    game.transform.parent = GameObject.Find("back").transform;
                }
                else if (levelMap[i, j] == 7)
                {
                    GameObject game = Instantiate<GameObject>(gameObjects[6]);
                    game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    game.transform.parent = GameObject.Find("back").transform;
                }
                else if (levelMap[i, j] == 0)
                {
                    //GameObject game = Instantiate<GameObject>(gameObjects[0]);
                    //game.transform.position = new Vector3((float)(-3.5f + 0.5 * j), (float)(3.75f - 0.5 * i), 0);
                    //game.transform.parent = GameObject.Find("back").transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPosition(Vector3 vector)
    {
        for(int i = 0; i < 15; ++i)
        {
            for(int j = 0; j < 14; ++j)
            {
                if(vector.x>=(float)(-3.5f+0.5*j-0.25f)&&vector.x<=(float)(-3.5f+0.5*j+0.25f)
                    && vector.y >= (float)(3.75 - 0.5 * i - 0.25f) && vector.y <= (float)(3.75f - 0.5 * i + 0.25f))
                {
                    return new Vector3(i,j,0);
                }
            }
        }

        return new Vector3(0,0,0);

    }

    public List<int> getLORR(Vector3 vector3)
    {
        Vector3 vector31 = new Vector3(0, 0, 0);
        vector31 = getPosition(vector3);
        Debug.Log("vec:" + vector31);
        List<int> ss = new List<int>();

        if (levelMap[(int)(vector31.x), (int)(vector31.y-1)] == 5||
            levelMap[(int)(vector31.x), (int)(vector31.y - 1)] == 0)
        {
            ss.Add(0);
            //return 0;
        }
        if(((int)(vector31.y+1)<14))
        {
            if((levelMap[(int)(vector31.x), (int)(vector31.y + 1)] == 5 ||
            levelMap[(int)(vector31.x), (int)(vector31.y + 1)] == 0))
            {
                //return 1;
                ss.Add(1);
            }
            
        }
        if (levelMap[(int)(vector31.x-1), (int)(vector31.y)] == 5 ||
           levelMap[(int)(vector31.x-1), (int)(vector31.y)] == 0)
        {
            ss.Add(2);
            //return 2;
        }
        if (((int)(vector31.x+1)<13))
        {
            if((levelMap[(int)(vector31.x + 1), (int)(vector31.y)] == 5 ||
           levelMap[(int)(vector31.x + 1), (int)(vector31.y)] == 0))
            {
                ss.Add(3);
                //return 3;
            }

        }

        return ss;
    }
}
