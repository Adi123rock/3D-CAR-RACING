using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class followpllayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    float turnangle;
    void Update(){
        // turnangle=player.rotation.y-90;
        // offset.x=player.rotation.x;
        // offset.x=10*Mathf.Sin(turnangle);
        // if(offset.x>0){

        // }
        // offset.z=10*Mathf.Cos(turnangle);
        // offset=player.position+new Vector3(-10,2,0);
        // transform.position=offset;
        // player.rotation.x=0;
        transform.LookAt(player);
    // Debug.Log("value:"+(player.rotation.y-90));
        // transform.rotation=player.rotation;
    }
}
