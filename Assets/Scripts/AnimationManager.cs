using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public void TriggerShootVar()
    {
        //Reset the "walk" trigger
        animator.ResetTrigger("dodge");

        //Send the message to the Animator to activate the trigger parameter named "shoot"
        animator.SetTrigger("shoot");
    }
    public void TriggerDodgeVar()
    {
        //Reset the "walk" trigger
        animator.ResetTrigger("shoot");

        //Send the message to the Animator to activate the trigger parameter named "shoot"
        animator.SetTrigger("dodge");
    }
}
