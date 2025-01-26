using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;
    private Vector3 direction;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundedLayerMask;
    
    public Animator animator;
    public Rigidbody hips, stomach, torso, head;
    public bool isGrounded;

    public Transform root;
    public Camera playerCamera;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            playerCamera.enabled = false;
            playerCamera.GetComponent<CameraController>().enabled = false;
            Destroy(playerCamera.GetComponent<AudioListener>());
        }
    }

    private void FixedUpdate()
    {
        if (IsOwner)
        {
            Move();
        }
    }

    private void Move()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundedLayerMask);
        }

        Vector2 currentInput = new Vector2(Input.GetAxis("Horizontal") * strafeSpeed, Input.GetAxis("Vertical") * speed);

        if (hips != null)
        {
            direction = (hips.transform.right * currentInput.x) + (hips.transform.forward * currentInput.y);
        }
        else if (hips == null && stomach != null)
        {
            stomach.transform.GetComponent<ConfigurableJoint>().connectedBody = root.GetComponent<Rigidbody>();
            stomach.transform.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
            stomach.transform.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked;
            stomach.transform.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
            direction = (stomach.transform.right * currentInput.x) + (stomach.transform.forward * currentInput.y);
        }
        else if (hips == null && stomach == null && torso != null)
        {
            torso.transform.GetComponent<ConfigurableJoint>().connectedBody = root.GetComponent<Rigidbody>();
            torso.transform.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
            torso.transform.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked;
            torso.transform.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
            direction = (torso.transform.right * currentInput.x) + (torso.transform.forward * currentInput.y);
        }
        else if (hips == null && stomach == null && torso == null && head != null)
        {
            head.transform.GetComponent<ConfigurableJoint>().connectedBody = root.GetComponent<Rigidbody>();
            head.transform.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
            head.transform.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked;
            head.transform.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
            direction = (head.transform.right * currentInput.x) + (head.transform.forward * currentInput.y);
        }
        else if(hips == null && stomach == null && torso == null && head == null)
        {
            root.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("isWalk", true);
            if (hips != null)
            {
                hips.AddForce(direction);
            }
            else if(hips == null && stomach != null)
            {
                stomach.AddForce(direction);
            }
            else if(hips == null && stomach == null && torso != null)
            {
                torso.AddForce(direction);
            }
            else if(hips == null && stomach == null && torso == null && head != null)
            {
                head.AddForce(direction);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (hips != null)
            {
                hips.AddForce(jumpForce * Vector3.up);
            }
            else if (hips == null && stomach != null)
            {
                stomach.AddForce(jumpForce * Vector3.up);
            }
            else if (hips == null && stomach == null && torso != null)
            {
                torso.AddForce(jumpForce * Vector3.up);
            }
            else if (hips == null && stomach == null && torso == null && head != null)
            {
                head.AddForce(jumpForce * Vector3.up);
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("isLeftHandUp", true);
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("isRightHandUp", true);
        }
        else if(Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("isLeftHandUp", true);
            animator.SetBool("isRightHandUp", true);
        }
        else
        {
            animator.SetBool("isLeftHandUp", false);
            animator.SetBool("isRightHandUp", false);
        }
    }
}
