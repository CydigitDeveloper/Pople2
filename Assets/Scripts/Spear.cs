using UnityEngine;

public class Spear : MonoBehaviour
{
    public Transform rightHand;
    public bool isEnemy;

    private void Update()
    {
        if (rightHand != null)
        {
            transform.position = rightHand.position;
            transform.rotation = rightHand.rotation;
        }
        else
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Part") && isEnemy)
        {
            ConnectRig otherRig = other.GetComponent<ConnectRig>();
            BubbleManager bubbleManager = other.transform.parent.GetComponent<BubbleManager>();
            ConfigurableJoint joint = other.transform.GetComponent<ConfigurableJoint>();

            if (joint != null && bubbleManager != null)
            {
                if (bubbleManager.joints.Contains(joint))
                {
                    bubbleManager.joints.Remove(joint);
                }
            }

            if (otherRig != null)
            {
                if (otherRig.rigs.Count == 0)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    for (int i = otherRig.rigs.Count - 1; i >= 0; i--)
                    {
                        if (otherRig.rigs[i] != null)
                        {
                            otherRig.rigs[i].connectedBody = null;
                            otherRig.rigs.RemoveAt(i);
                        }
                        else
                        {
                            otherRig.rigs.Remove(otherRig.rigs[i]);
                        }
                    }
                }

            }
        }
    }
}
