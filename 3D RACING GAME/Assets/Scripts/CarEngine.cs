using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 1;
    public Vector3 centreofMass;
    [Header("Wheel Collider")]
    public WheelCollider frontLW;
    public WheelCollider frontRW;
    public WheelCollider backLW;
    public WheelCollider backRW;

    [Header("Wheel Values")]
    public float maxTorque = 300f;
    public float maxSteerAngle = 40f;
    public float maxSpeed=50f;
    private float currentSpeed;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centreofMass;
        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {//this checks that nodes will not contain its own transform
                nodes.Add(pathTransform[i]);
            }
        }
    }

    void FixedUpdate()
    {
        posnChk();
        steerCar();
        moveCar();
        Braking();
        // Debug.Log(currentSpeed);
    }
    void posnChk()
    {
        if ((Vector3.Distance(transform.position, nodes[currentNode].position)) < 5f)
        {
            if (currentNode == nodes.Count - 1)//finsih line cleared
            {
                maxTorque = 0f;
            }
            else
            {
                currentNode++;
                // Debug.Log("Position increased");
            }

        }
        // if(transform.position.z>nodes[currentNode].position.z)
        // {
        //     currentNode++;
        // }
    }
    void steerCar()
    {
        Vector3 node = transform.InverseTransformPoint(nodes[currentNode].position);
        node /= node.magnitude;
        // Debug.Log(node);
        frontLW.steerAngle = node.x * maxSteerAngle;
        frontRW.steerAngle = node.x * maxSteerAngle;
    }
    void moveCar()
    {
        currentSpeed = (float)(2 * Mathf.PI * frontLW.rpm * frontLW.radius * 60 / 1000);
        if (currentSpeed < maxSpeed)
        {
            frontLW.motorTorque = maxTorque;
            frontRW.motorTorque = maxTorque;
            backLW.motorTorque = maxTorque;
            backRW.motorTorque = maxTorque;
        }
        else
        {
            // Debug.Log("High Speed");
            frontLW.motorTorque = 0f;
            frontRW.motorTorque = 0f;
            backLW.motorTorque = 0f;
            backRW.motorTorque = 0f;
        }
    }
    void Braking()
    {

    }
}
