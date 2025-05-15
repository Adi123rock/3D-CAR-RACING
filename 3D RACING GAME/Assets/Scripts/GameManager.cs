using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayBGM("game bgm");
        Debug.Log("Play");
    }
    public void Restart()
    {
        SceneManager.LoadScene("GAME");
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
