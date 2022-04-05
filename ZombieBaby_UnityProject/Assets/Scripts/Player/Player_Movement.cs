using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.
    public float rotationSpeed = 6f;            // The speed that the player will move at.
    private float m_VerticalSpeed = 0f;

    Vector3 movement;   //The vector to store the position of the next step of the player
    Vector3 playerDirection;                   // The vector to store the direction of the player's pitch.
    
    CharacterController characterController;
    public Joystick joystick1;  //Left joystick
    public Joystick joystick2;   //Right joystick

    public Transform pitchTransform;
    private Vector3 newForward;
    
    

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        // Store the input axes.
        float h = joystick1.Horizontal;
        float v = joystick1.Vertical;

        float h2 = joystick2.Horizontal;
        float v2 = joystick2.Vertical;

        // Move the player around the scene.
        Move(h, v, h2, v2);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(float h, float v,float h2, float v2)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        //transform.position += movement * Time.deltaTime * speed;

        //Gravity 
        m_VerticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y = m_VerticalSpeed * Time.deltaTime;
        CollisionFlags l_CollisionFlags = characterController.Move(movement);
        if ((l_CollisionFlags & CollisionFlags.Below) != 0)
        {
            m_VerticalSpeed = 0.0f;
        }
        if ((l_CollisionFlags & CollisionFlags.Above) != 0 && m_VerticalSpeed > 0.0f)
        {
            m_VerticalSpeed = 0.0f;
        }

        //characterController.Move(movement * Time.deltaTime * speed);

        if (joystick2.IsJoystickPressed)
        {
            // Determine which direction to rotate towards
            playerDirection.Set(h2, 0f, v2);

            // The step size is equal to speed times frame time.
            float singleStep = rotationSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(playerDirection, pitchTransform.position, singleStep, 0.0f);
            newForward = new Vector3(newDirection.x, 0, newDirection.z);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            pitchTransform.rotation = Quaternion.LookRotation(newForward);
        }
        else
        {

            if (joystick1.IsJoystickPressed)
            {
                // Determine which direction to rotate towards
                playerDirection.Set(h, 0f, v);

                // The step size is equal to speed times frame time.
                float singleStep = rotationSpeed * Time.deltaTime;

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(playerDirection, pitchTransform.position, singleStep, 0.0f);
                newForward = new Vector3(newDirection.x, 0, newDirection.z);

                // Calculate a rotation a step closer to the target and applies rotation to this object
                pitchTransform.rotation = Quaternion.LookRotation(newForward);
            }
            
        }    
    }


    public Vector3 GetForward()
    {
        return pitchTransform.forward;
    }

}
