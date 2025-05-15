using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class movement : MonoBehaviour
{
    // public WheelCollider fullbody,frontLW,frontRW,backLW,backRW;
    // public Vector3 offrotaion;
    // float trunangle=0f;
    // Start is called before the first frame update
    // void Update(){
    //     if(Input.GetKey("w")){
    //         frontLW.AddForce(2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         frontRW.AddForce(2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         backLW.AddForce(2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         backRW.AddForce(2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         fullbody.AddForce(2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //     }
    //     if(Input.GetKey("s")){
    //         frontLW.AddForce(-2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         frontRW.AddForce(-2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         backLW.AddForce(-2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         backRW.AddForce(-2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //         fullbody.AddForce(-2*Time.deltaTime,0,0,ForceMode.VelocityChange);
    //     }
    //     if(Input.GetKey("d")){
    //         frontLW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //         frontRW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //         backLW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //         backRW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //         fullbody.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //         // offrotaion.y+=5;
    //         trunangle+=1f;
    //         frontRW.GetComponent<WheelCollider>().steerAngle = trunangle;
    //         frontLW.GetComponent<WheelCollider>().steerAngle = trunangle;
    //         // fullbody.GetComponent<WheelCollider>().steerAngle = trunangle;
    //     }

    //     // if(Input.GetKey("d") && Input.GetKey("w") ){
    //     //     frontLW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //     //     frontRW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //     //     backLW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //     //     backRW.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //     //     fullbody.AddForce(0,0,-2*Time.deltaTime,ForceMode.VelocityChange);
    //     //     offrotaion.y+=1;
    //     //     frontRW.GetComponent<Transform>().rotation = offrotaion;
    //     // }


    //     if(Input.GetKey("a")){
    //         frontLW.AddForce(0,0,2*Time.deltaTime,ForceMode.VelocityChange);
    //         frontRW.AddForce(0,0,2*Time.deltaTime,ForceMode.VelocityChange);
    //         backLW.AddForce(0,0,2*Time.deltaTime,ForceMode.VelocityChange);
    //         backRW.AddForce(0,0,2*Time.deltaTime,ForceMode.VelocityChange);
    //         fullbody.AddForce(0,0,2*Time.deltaTime,ForceMode.VelocityChange);
    //     }
    // }
    [Header("Wheels Transform")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Car Engine")]
    public float maxTorque = 30f;
    public float preTorque;
    public float brakeTorque = 30000f;
    public float preBreakTorque;
    private float currentBrakeForce;
    private bool isBraking;

    [Header("Car Handling")]
    public float maxSteerAngle = 40f;
    static float presentSteerAngle;
    public float DownForceValue = 50f;
    public Rigidbody rb;
    float currentSpeed;
    Quaternion normal;
    private bool isCorrecting = false;
    // && transform.rotation.z<250
    // && transform.rotation.x<250
    void Start()
    {
        normal = transform.rotation;
    }
    void FixedUpdate()
    {
        addDownForce();
        Ifcarrotates();
    }
    void Update()
    {
        currentSpeed = (float)(2 * Mathf.PI * frontLeftWheelCollider.rpm * frontLeftWheelCollider.radius * 60 / 1000);
        // Debug.Log(currentSpeed);
        // if(Input.GetAxis("Horizontal")!=0){
        //     HandleSteering();
        // }
        // if(Input.GetAxis("Vertical")!=0){
        //     Movecar();
        // }
        // Movecar();
        // if(Input.GetAxis("Vertical")>0){

        // }
        // else if(Input.GetAxis("Vertical")<0 && frontRightWheelCollider.motorTorque>0){
        //     ApplyBraking();
        // }
        Movecar();
        HandleSteering();
        ApplyBraking();
        // Debug.Log(frontLeftWheelCollider.motorTorque);

    }
    // void Ifcarrotates()
    // {
    //     Vector3 rotation;
    //     rotation = transform.rotation.eulerAngles;
    //     // Debug.Log(rotation);
    //     // if((rotation.z>90 )|| (rotation.z<-90)){
    //     //     Debug.Log("carupsidedown");
    //     //     transform.rotation=normal;
    //     // }
    //     // else if((rotation.x>90 ) || (rotation.x<-90 )){
    //     //     Debug.Log("carupsidedown");
    //     //     transform.rotation=normal;
    //     // }

    // }
    private void Movecar()
    {
        // if(Input.GetAxis("Vertical")>0){

        // }
        currentSpeed = rb.velocity.magnitude;
        preTorque = maxTorque * Input.GetAxis("Vertical");
        if (currentSpeed < 25)
        {
            frontRightWheelCollider.motorTorque = preTorque;
            frontLeftWheelCollider.motorTorque = preTorque;
            backLeftWheelCollider.motorTorque = preTorque;
            backRightWheelCollider.motorTorque = preTorque;
        }
        else
        {
            // Debug.Log("High Speed");
            frontRightWheelCollider.motorTorque = 0f;
            frontLeftWheelCollider.motorTorque = 0f;
            backLeftWheelCollider.motorTorque = 0f;
            backRightWheelCollider.motorTorque = 0f;
        }
        // Debug.Log(frontLeftWheelCollider.motorTorque);
    }
    public void HandleSteering()
    {
        presentSteerAngle = maxSteerAngle * Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentSteerAngle;
        frontRightWheelCollider.steerAngle = presentSteerAngle;
    }

    private void ApplyBraking()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            preBreakTorque = brakeTorque;
        }
        else
        {
            preBreakTorque = 0f;
        }
        // preBreakTorque=brakeTorque*Input.GetAxis("Vertical");
        frontRightWheelCollider.brakeTorque = preBreakTorque;
        frontLeftWheelCollider.brakeTorque = preBreakTorque;
        backRightWheelCollider.brakeTorque = preBreakTorque;
        backLeftWheelCollider.brakeTorque = preBreakTorque;

    }

    void addDownForce()
    {
        Debug.Log(rb.velocity.magnitude);
        rb.AddForce(-transform.up * DownForceValue * rb.velocity.magnitude);
    }
    private void Ifcarrotates()
    {
        // Check if the car is upside down
        if (Vector3.Dot(transform.up, Vector3.down) > 0.7f && !isCorrecting)
        {
            // Start the correction coroutine
            StartCoroutine(CorrectUpsideDown());
        }
    }
    private IEnumerator CorrectUpsideDown()
    {
        isCorrecting = true;

        // Wait for a short duration to ensure the car is fully upside down
        yield return new WaitForSeconds(1.0f);

        // Gradually rotate the car back to its normal position
        Quaternion targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        float elapsedTime = 0f;
        float correctionDuration = 2.0f;

        while (elapsedTime < correctionDuration)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (elapsedTime / correctionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        rb.velocity = Vector3.zero; // Optional: Reset velocity to prevent sliding
        rb.angularVelocity = Vector3.zero; // Optional: Reset angular velocity

        isCorrecting = false;
    }

}





