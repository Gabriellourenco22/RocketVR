using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorPress : MonoBehaviour
{
    [SerializeField] private Animator animatorController;

    //Se houver colissao com o quadrado, a porta se abre.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
         
            animatorController.SetBool("Open", true);
        }
    }

   
}
