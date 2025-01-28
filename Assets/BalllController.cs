using System;
using UnityEngine;

public class BalllController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed = 3f;
    private Boolean onGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Calling the Start method");
    }
    public void MoveBall(Vector3 input)
    {
        Vector3 inputXYZPlane = new(input.x, input.y*10, input.z);
        Debug.Log(input.y);
        //if the ball jumps, set onGround to false
        if (inputXYZPlane.y > 0)
        {
            onGround = false;
        }
        
        //if the ball isn't on the ground, keep it from jumping
        if (onGround == false)
        {
            inputXYZPlane.y = 0;
        }
        
        Debug.Log(inputXYZPlane);
        Debug.Log("onGround=" + onGround);
        sphereRigidbody.AddForce(inputXYZPlane * ballSpeed);
        sphereRigidbody.AddForce(Physics.gravity * sphereRigidbody.mass);
    }

    //detecting if the ball is on the ground
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            Debug.Log("ground touched");
        }
    }
}
