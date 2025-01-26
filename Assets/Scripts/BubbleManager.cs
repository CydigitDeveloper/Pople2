using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public List<ConfigurableJoint> joints = new List<ConfigurableJoint>();
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        foreach(ConfigurableJoint joint in joints)
        {
            if (joint.connectedBody == null)
            {
                joint.xMotion = ConfigurableJointMotion.Free;
                joint.yMotion = ConfigurableJointMotion.Free;
                joint.zMotion = ConfigurableJointMotion.Free;
                joint.angularXMotion = ConfigurableJointMotion.Free;
                joint.angularYMotion = ConfigurableJointMotion.Free;
                joint.angularZMotion = ConfigurableJointMotion.Free;
            }
        }
    }
}
