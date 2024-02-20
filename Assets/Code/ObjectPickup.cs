using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public GameObject crosshair1, crosshair2;
    public Transform objTransform, cameraTransform;
    public bool interactable, pickedUp;
    public Rigidbody objRigidbody;
    public float throwAmount;

    void OnTriggerStay(Collider other){
        if(other.CompareTag("MainCamera")){
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable =true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("MainCamera")){
            if(pickedUp==false){
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable==true){
            if(Input.GetMouseButtonDown(0)){
                objTransform.parent = cameraTransform;
                objRigidbody.useGravity = false;
                pickedUp = true;
            }
            if(Input.GetMouseButtonUp(0)){
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                pickedUp = false;
            }
            if(pickedUp==true){
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                objRigidbody.velocity = cameraTransform.forward * throwAmount * Time.deltaTime;
                pickedUp = false;
            }
        }
        
    }
}
