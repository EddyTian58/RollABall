using System;
using UnityEngine;

public class BalllController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed = 3f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float gravityMuliplier = 0.5f;
    private Boolean onGround = false;

    public void MoveBall(Vector3 input)
    {
        Vector3 inputXYZPlane = new(input.x, input.y*jumpForce, input.z);
        Debug.Log(input.y);
        
        if (onGround == false)
        {
            inputXYZPlane.y = 0;
        }
        
        Debug.Log("Resultant vector:" + inputXYZPlane);
        sphereRigidbody.AddForce(inputXYZPlane * ballSpeed);
        sphereRigidbody.AddForce(Physics.gravity * (sphereRigidbody.mass*gravityMuliplier));
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
    
    //detecting if the ball has left the ground
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
            Debug.Log("We have liftoff!");
        }
    }
}
