
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PickupScript : MonoBehaviour
{
    InputAction pickupAction;
    [SerializeField] private Transform raycastSpawner;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask objectLayerMask;
    private ObjectGrabbable objectGrabbable;
    
    public float pickUpDistance;
    private void Start()
    {
        pickupAction = InputSystem.actions.FindAction("Attack");
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
           if (objectGrabbable == null)
            {
                if (Physics.Raycast(raycastSpawner.position, raycastSpawner.forward, out RaycastHit raycasthit, pickUpDistance, objectLayerMask))
                {
                    print(raycasthit.transform);
                    if (raycasthit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }

                }
            }
            
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
                
        }
    }
}
