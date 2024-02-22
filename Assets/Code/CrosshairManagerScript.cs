using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairManagerScript : MonoBehaviour
{
    public GameObject crosshair_default, crosshair_pickable, crosshair_holding;
    private GameObject[] pickableObjects;
    private enum CrosshairState
    {
        Default,
        Pickable,
        Holding
    }

    private CrosshairState currentCrosshairState;

    void Start()
    {
        pickableObjects=GameObject.FindGameObjectsWithTag("Pickable");
        SetCrosshairState(CrosshairState.Default);
    }

    void Update(){
        foreach (GameObject obj in pickableObjects){
            if(obj.GetComponent<ObjectPickup>().interactable){
                SetCrosshairState(CrosshairState.Pickable);

                if(obj.GetComponent<ObjectPickup>().pickedup){
                    SetCrosshairState(CrosshairState.Holding);
                }
                break;                
            }else
                SetCrosshairState(CrosshairState.Default); 
        }
    }

    private void SetCrosshairState(CrosshairState newState)
    {
        Debug.Log("SetCrosshairState with newState: "+ newState);
        crosshair_default.SetActive(newState == CrosshairState.Default);
        crosshair_pickable.SetActive(newState == CrosshairState.Pickable);
        crosshair_holding.SetActive(newState == CrosshairState.Holding);
        currentCrosshairState = newState;
    }
}
