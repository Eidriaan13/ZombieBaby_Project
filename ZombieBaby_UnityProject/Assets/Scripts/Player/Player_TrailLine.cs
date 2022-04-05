using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TrailLine : MonoBehaviour
{
    public Transform playerTr;
    public Transform pitchTr;
    public LineRenderer LR;
    private Vector3 m_PlayerPos;
    private Vector3 m_PitchPos;

    public Joystick rightJoystick;

    public Transform lookAtPoint;

    public float trailDistance;
    public float yValue = -1.45f;
    RaycastHit hit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightJoystick.IsJoystickPressed)
        {
            //lookAtPoint.position = new Vector3(rightJoystick.Horizontal + transform.position.x,0, rightJoystick.Vertical + transform.position.z);
            //transform.LookAt(new Vector3(lookAtPoint.position.x, 0, lookAtPoint.position.z));

            m_PlayerPos = new Vector3(playerTr.position.x, playerTr.position.y + yValue, playerTr.position.z);
            m_PitchPos = new Vector3(pitchTr.position.x, pitchTr.position.y + yValue, pitchTr.position.z);

            if (LR.gameObject.activeInHierarchy == false)
            {
                LR.gameObject.SetActive(true);
            }

            LR.SetPosition(0, m_PlayerPos);

            if (Physics.Raycast(m_PlayerPos,pitchTr.forward,out hit, trailDistance))
            {
                LR.SetPosition(1, hit.point);
            }
            else
            {
                LR.SetPosition(1, m_PitchPos + pitchTr.forward * trailDistance);
            }

        }
        else
        {
            if (LR.gameObject.activeInHierarchy == true)
            {
                LR.gameObject.SetActive(false);
            }
        }



    }
   
}
