using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]private float speedCameraMove;
    [SerializeField] private float cameraSensitivity;

    private float rotateX;
    private float rotateY;

    private Vector3 mousePreveousePos;

    private void Update()
    {
        MoveLogic();
        RotateLogic();
    }

    private void MoveLogic()
    {
        float inputShiftSpeed = 1f;
            if(Input.GetKey(KeyCode.LeftShift))
                {
                    inputShiftSpeed = 3f;
                }
        float rightPos = Input.GetAxisRaw("Horizontal");
        float forwardPos = Input.GetAxisRaw("Vertical");
        float upPos = 0;
            if(Input.GetKey(KeyCode.Z))
                 {
                    upPos = 1;
                 }
            else if(Input.GetKey(KeyCode.X))
                {
                    upPos = -1;
                }
        Vector3 offset = new Vector3(rightPos, upPos, forwardPos) * speedCameraMove * inputShiftSpeed * Time.unscaledDeltaTime;
        transform.Translate(offset); 
    }
    private void RotateLogic()
    {
        Vector3 mouseDelta;
            if(Input.GetMouseButtonDown(1))
                {
                    mousePreveousePos = Input.mousePosition;
                }
            if(Input.GetMouseButton(1))
                {
                    mouseDelta = Input.mousePosition - mousePreveousePos;
                    mousePreveousePos = Input.mousePosition;
                    rotateX -= mouseDelta.y * cameraSensitivity;
                    rotateY += mouseDelta.x * cameraSensitivity;
                    transform.localEulerAngles = new Vector3(rotateX, rotateY, 0);
                }
    }
}
