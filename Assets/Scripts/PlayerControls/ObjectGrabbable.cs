
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{


    public Transform objectGrabPointTransform;
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
    public Transform pelvisTrans;






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

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }

    public void Drop()
    {
        transform.parent = pelvisTrans;
        GetComponent<Rigidbody>().useGravity = true;

        GetComponent<Rigidbody>().isKinematic = false;
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
