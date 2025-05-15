using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheelmotion : MonoBehaviour
{
    public WheelCollider wheel;
    private Vector3 wheelPosition= new Vector3();
    private Quaternion wheelrotation=new Quaternion();
    void Update()
    {
        wheel.GetWorldPose(out wheelPosition,out wheelrotation);
        transform.position=wheelPosition;
        transform.rotation=wheelrotation;
    }
}
