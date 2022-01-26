using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform PlayerTransform;
    private Vector3 cameraOffset;

    private const float Y_Angle_Max = 50.0f;
    private const float Y_Angle_Min = -50.0f;

    private float currentY = 0.0f;
    [SerializeField, Range(0.01f, 1.0f)] private float SmoothFactor = 0.5f;
    [SerializeField] private bool RotateAroundPlayer;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private bool LookAtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
            currentY = Input.GetAxis("Mouse Y");
            currentY = Mathf.Clamp(currentY, Y_Angle_Min, Y_Angle_Max);
            Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camTurnAngleY =  Quaternion.AngleAxis(currentY * RotationSpeed, Vector3.left);
            cameraOffset = (camTurnAngleX * camTurnAngleY) * cameraOffset;
        }
        Vector3 newPos = PlayerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos,SmoothFactor);

        if(LookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
