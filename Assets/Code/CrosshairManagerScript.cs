using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairManagerScript : MonoBehaviour
{
    public GameObject crosshair_default, crosshair_pickable, crosshair_holding;
    private enum CrosshairState
    {
        Default,
        Pickable,
        Holding
    }

    private CrosshairState currentCrosshairState;

    void Start()
    {
        SetCrosshairState(CrosshairState.Default);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            SetCrosshairState(CrosshairState.Pickable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            SetCrosshairState(CrosshairState.Default);
        }
    }

    // Call this method from the ObjectPickup script when holding/unholding an object
    public void SetHoldingState(bool holding)
    {
        SetCrosshairState(holding ? CrosshairState.Holding : CrosshairState.Default);
    }

    private void SetCrosshairState(CrosshairState newState)
    {
        crosshair_default.SetActive(newState == CrosshairState.Default);
        crosshair_pickable.SetActive(newState == CrosshairState.Pickable);
        crosshair_holding.SetActive(newState == CrosshairState.Holding);
        currentCrosshairState = newState;
    }
}
