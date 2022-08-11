using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator jumpAnim = null;

    private bool jump = false;

    [SerializeField] private string jumpAnimationName = "Jump";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    //Faz uma pausa para que de tempo de finalizar a animaçao toda antes de inciar a proxima.
    private IEnumerator PauseJumpInteracation()
    {
        jump = false;
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
        jumpAnim.SetBool("JumpActive", false);
    }

    //Faz acontecer a animação do Robo.
    public void PlayAnimation()
    {
        if(!jump && !pauseInteraction)
        {
            jumpAnim.Play(jumpAnimationName, 0, 0.0f);
            jumpAnim.SetBool("JumpActive", true);
            jump = true;
            StartCoroutine(PauseJumpInteracation());
            
        }
    }
}
