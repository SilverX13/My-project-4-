using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starButton : MonoBehaviour
{
    public GameObject score;
    public GameObject gametime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetString("score")!=null&&
            PlayerPrefs.GetString("gametime") !=null)
        {
            score.transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("score");
            gametime.transform.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("gametime");
        }
    }

    public void Onclickbutton()
    {
        SceneManager.LoadScene(1);
    }
}
