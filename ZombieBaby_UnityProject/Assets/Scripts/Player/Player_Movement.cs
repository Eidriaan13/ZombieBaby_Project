using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.
    public float rotationSpeed = 6f;            // The speed that the player will move at.

    Vector3 movement;   //The vector to store the position of the next step of the player
    Vector3 playerDirection;                   // The vector to store the direction of the player's pitch.
    
     Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

    public Joystick joystick1;  //Left joystick
    public Joystick joystick2;   //Right joystick

    public Transform pitchTransform;
    public GameObject gunShadow;


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Store the input axes.
        float h = joystick1.Horizontal;
        float v = joystick1.Vertical;

        float h2 = joystick2.Horizontal;
        float v2 = joystick2.Vertical;

        // Turn the player to face the mouse cursor.
        // Move the player around the scene.
        Move(h, v, h2, v2);
        //Turning(h2,v2);
    }

    void Move(float h, float v,float h2, float v2)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        transform.position += movement * Time.deltaTime * speed;
        
        if (joystick2.IsJoystickPressed)
        {
            gunShadow.SetActive(true);

            // Determine which direction to rotate towards
            playerDirection.Set(h2, 0f, v2);

            // The step size is equal to speed times frame time.
            float singleStep = rotationSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(playerDirection, pitchTransform.position, singleStep, 0.0f);
            Vector3 newForward = new Vector3(newDirection.x, 0, newDirection.z);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            pitchTransform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            gunShadow.SetActive(false);

            if (joystick1.IsJoystickPressed)
            {
                // Determine which direction to rotate towards
                playerDirection.Set(h, 0f, v);

                // The step size is equal to speed times frame time.
                float singleStep = rotationSpeed * Time.deltaTime;

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(playerDirection, pitchTransform.position, singleStep, 0.0f);
                Vector3 newForward = new Vector3(newDirection.x, 0, newDirection.z);

                // Calculate a rotation a step closer to the target and applies rotation to this object
                pitchTransform.rotation = Quaternion.LookRotation(newDirection);
            }
            
        }    
    }

    void Turning(float h,float v)
    {

        // Create a ray from the mouse cursor on screen in the direction of the camera.
        //Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        //RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        //if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        //{
        // Create a vector from the player to the point on the floor the raycast from the mouse hit.

        // Determine which direction to rotate towards
        //gunDirection.Set(h, 0f, v);

        // The step size is equal to speed times frame time.
        //float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        //Vector3 newDirection = Vector3.RotateTowards(gunTransform.forward, gunDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        //gunTransform.rotation = Quaternion.LookRotation(gunDirection);

        
    }
}
