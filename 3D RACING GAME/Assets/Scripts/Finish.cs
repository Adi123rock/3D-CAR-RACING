using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject lose,win;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collisioninfo)
    {
        if(collisioninfo.gameObject.tag=="Player")
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }
        
    }
}
