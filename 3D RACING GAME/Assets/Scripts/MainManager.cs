using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMAnager : MonoBehaviour
{
    
    public GameObject Loading;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=2f;
        // if(SceneManager.GetActiveScene==)
        FindObjectOfType<AudioManager>().PlayBGM("Main BGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToGame()
    {
        FindObjectOfType<AudioManager>().PlayButton("Play");
        Loading.SetActive(true);
        FindObjectOfType<AudioManager>().StopBGM();
        FindObjectOfType<AudioManager>().PlaySFX("Loading");
        SceneManager.LoadScene("GAME");
    } 
}
