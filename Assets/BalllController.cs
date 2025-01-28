using UnityEngine;

public class BalllController : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public float ballSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Calling the Start method");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
            Debug.Log("User Input: W");
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
            Debug.Log("User Input: S");
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
            Debug.Log("User Input: A");
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
            Debug.Log("User Input: D");
        }
        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
        Debug.Log("Resultant Vector: " + inputVector);
        Debug.Log("Resultant 3D Vector: " + inputXZPlane);
    }
}
