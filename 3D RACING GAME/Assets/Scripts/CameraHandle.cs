using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    public Animator Blackout,animator321;
    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<CarEngine>().enabled=false;
        FindObjectOfType<movement>().enabled=false;
        // FindObjectOfType<CarEngine>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
