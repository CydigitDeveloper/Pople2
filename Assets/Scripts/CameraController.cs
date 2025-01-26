using Unity.Netcode;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    public float rotationSpeed = 1.0f;
    public Transform root;

    public ConfigurableJoint hipsJoint;
    public ConfigurableJoint stomachJoint;

    float mouseX, mouseY;

    public float stomachOffset;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (IsOwner)
        {
            CameraControl();
        }
    }

    private void CameraControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35f, 60f);

        Quaternion rootRotation = Quaternion.Euler(mouseY, mouseX, 0f);

        root.rotation = rootRotation;

        if (hipsJoint != null)
        {
            hipsJoint.targetRotation = Quaternion.Euler(0f, -mouseX, 0f);
        }

        if (stomachJoint != null)
        {
            stomachJoint.targetRotation = Quaternion.Euler(-mouseY + stomachOffset, 0f, 0f);
        }
    }
}
