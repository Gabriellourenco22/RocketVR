using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorPress : MonoBehaviour
{
    [SerializeField] private Animator animatorController;

    //Moves this GameObject 2 units a second in the forward direction
    void Update()
    {

    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
         
            animatorController.SetBool("Open", true);
        }
    }

   
}
