using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    private ConfigurableJoint joint;
    public bool mirror;

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
        if (!mirror)
        {
            joint.targetRotation = targetLimb.rotation;
        }
        else
        {
            joint.targetRotation = Quaternion.Inverse(targetLimb.rotation);
        }
    }
}
