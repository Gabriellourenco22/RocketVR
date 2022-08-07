using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartAnimationButton : MonoBehaviour
{

    [SerializeField] private int rayLenght = 3;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName ;

    [SerializeField] private ButtonController raycastedObj;

    [SerializeField] private PlayerInputActions playerInputActions;
   

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "StartButton";

    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        
    }

    private void Update()
    {
        PressButton();
    }

    void PressButton()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLenght, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                Debug.Log(hit.transform.tag);
                if (!doOnce)
                {
                   if(raycastedObj = hit.collider.gameObject.GetComponent<ButtonController>())
                    { 
                    playerInputActions.Player.MousePress.started += _ => raycastedObj.PlayAnimation();
                    CrosshairChange(true);
                    }
                }
                isCrosshairActive = true;
                doOnce = true;

            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }




    void CrosshairChange(bool on)
    {
        if(on && !doOnce)
        {
            crosshair.color = Color.red;
        }

        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;

        }
    }

}
