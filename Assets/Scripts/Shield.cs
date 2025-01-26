using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform leftHand;

    private void Update()
    {
        if (leftHand != null)
        {
            transform.position = leftHand.position;
            transform.rotation = leftHand.rotation;
        }
        else
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
