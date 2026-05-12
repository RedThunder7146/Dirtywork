
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{


    public  Transform objectGrabPointTransform;
    public Rigidbody pelvis;
    public Rigidbody lArmUp;
    public Rigidbody lArmDown;
    public Rigidbody rArmUp;
    public Rigidbody rArmDown;
    public Rigidbody rThigh;
    public Rigidbody lThigh;
    public Rigidbody rCalf;
    public Rigidbody lCalf;
    public Rigidbody head;




    public void Grab()
    {
        transform.parent = objectGrabPointTransform.transform;
        pelvis.useGravity = false;
        lArmUp.useGravity = false;
        lArmDown.useGravity = false;
        rArmUp.useGravity = false;
        rArmDown.useGravity = false;
        lCalf.useGravity = false;
        head.useGravity = false;
        lThigh.useGravity = false;
        rCalf.useGravity = false;
        rThigh.useGravity = false;

        pelvis.linearVelocity = Vector3.zero;
        lArmUp.linearVelocity = Vector3.zero;
        lArmDown.linearVelocity = Vector3.zero;
        rArmUp.linearVelocity = Vector3.zero;
        rArmDown.linearVelocity = Vector3.zero;
        lCalf.linearVelocity = Vector3.zero;
        head.linearVelocity = Vector3.zero;
        lThigh.linearVelocity = Vector3.zero;
        rCalf.linearVelocity = Vector3.zero;
        rThigh.linearVelocity = Vector3.zero;
    }

    public void Drop()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;

        pelvis.useGravity = true;
        lArmUp.useGravity = true;
        lArmDown.useGravity = true;
        rArmUp.useGravity = true;
        rArmDown.useGravity = true;
        lCalf.useGravity = true;
        head.useGravity = true;
        lThigh.useGravity = true;
        rCalf.useGravity = true;
        rThigh.useGravity = true;
    }



    



}
