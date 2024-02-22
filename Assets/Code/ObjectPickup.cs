using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform objTransform, cameraTrans;
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;
    public float throwAmount;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("MainCamera")){
            if (!pickedup){
                interactable = false;
            }
            else{
                if (pickedup && Input.GetMouseButtonUp(0)){
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    pickedup = false;
                }
            }
        }
    }

    void Update()
    {
        if (interactable)
        {
            // Hold the object
            if (Input.GetMouseButtonDown(0))
            {
                objTransform.parent = cameraTrans;
                objRigidbody.useGravity = false;
                pickedup = true;
            }

            // Drop the object
            if (Input.GetMouseButtonUp(0))
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                pickedup = false;
            }

            // Throw the object
            if (pickedup && Input.GetMouseButtonDown(1))
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                objRigidbody.velocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                pickedup = false;
            }
        }
    }
}
