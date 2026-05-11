
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public Rigidbody rb;
    /*public Rigidbody rbHead;
    public Rigidbody rbLAHigh;
    public Rigidbody rbRAHigh;
    public Rigidbody rbLThigh;
    public Rigidbody rbRThigh;
    public Rigidbody rbLALow;
    public Rigidbody rbRALow;
    public Rigidbody rbRCalf;
    public Rigidbody rbLCalf;*/

    private Transform objectGrabPointTransform;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
       /* rb.useGravity = false;
        rbHead.useGravity = false;
        rbLAHigh.useGravity = false;
        rbRAHigh.useGravity = false;
        rbLThigh.useGravity = false;
        rbRThigh.useGravity = false;
        rbLALow.useGravity = false;
        rbRALow.useGravity = false;
        rbRCalf.useGravity = false;
        rbLCalf.useGravity = false;
       */
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime*lerpSpeed);
            rb.MovePosition(newPosition);
        }

    }



}
