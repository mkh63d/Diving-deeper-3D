using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform objTransform, cameraTrans;
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;
    public float throwAmount;

    private CrosshairManagerScript crosshairManager;

    void Start()
    {
        crosshairManager = GameObject.FindWithTag("CrosshairManager").GetComponent<CrosshairManagerScript>(); //Find crosshair manager
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshairManager.SetHoldingState(false); // Not holding an object
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("MainCamera")){
            if (!pickedup){
                crosshairManager.SetHoldingState(false); // Not holding an object
                interactable = false;
            }
            else{
                if (pickedup && Input.GetMouseButtonUp(0)){
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    pickedup = false;
                    crosshairManager.SetHoldingState(false); // Not holding an object
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
                crosshairManager.SetHoldingState(true); // Holding an object
            }

            // Drop the object
            if (Input.GetMouseButtonUp(0))
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                pickedup = false;
                crosshairManager.SetHoldingState(false); // Not holding an object
            }

            // Throw the object
            if (pickedup && Input.GetMouseButtonDown(1))
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                objRigidbody.velocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                pickedup = false;
                crosshairManager.SetHoldingState(false); // Not holding an object
            }
        }
    }
}
