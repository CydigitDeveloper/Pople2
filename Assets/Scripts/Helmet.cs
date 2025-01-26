using UnityEngine;

public class Helmet : MonoBehaviour
{
    public Transform head;

    private void Update()
    {
        if (head != null)
        {
            transform.position = head.position;
            transform.rotation = head.rotation;
        }
        else
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
