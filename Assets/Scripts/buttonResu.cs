using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonResu : MonoBehaviour
{
    public GameObject score;
    public GameObject gametime;
    public GameObject winOrunwin;
    // Start is called before the first frame update
    void Start()
    {
        score.transform.GetComponent<TextMeshProUGUI>().text = GameObject.Find("playdata").transform.GetComponent<playdata>().score;
        gametime.transform.GetComponent<TextMeshProUGUI>().text = GameObject.Find("playdata").transform.GetComponent<playdata>().gametime;

        if (GameObject.Find("playdata").transform.GetComponent<playdata>().winOrUnwin == 0)
        {
            winOrunwin.transform.GetComponent<TextMeshProUGUI>().text = "Win!";
            PlayerPrefs.SetString("score", score.transform.GetComponent<TextMeshProUGUI>().text);
            PlayerPrefs.SetString("gametime", gametime.transform.GetComponent<TextMeshProUGUI>().text);

        }
        else
        {
            winOrunwin.transform.GetComponent<TextMeshProUGUI>().text = "UnWin!";
            PlayerPrefs.SetString("score", score.transform.GetComponent<TextMeshProUGUI>().text);
            PlayerPrefs.SetString("gametime", gametime.transform.GetComponent<TextMeshProUGUI>().text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick1()
    {
        SceneManager.LoadScene(0);
    }

    public void onClick2()
    {
        Application.Quit();
    }
}
