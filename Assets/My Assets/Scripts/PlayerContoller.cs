using System.Collections;
using System.Collections.Generic;
using GD.Controllers;
using UnityEngine;

public class PlayerContoller : CharacterNavigationController
{

        private static readonly string IS_RUNNING = "isRunning";
        
        protected override void SetAnimationWhenGoingToDestination()
    {
        animator.SetBool(IS_RUNNING, true);
    }

    protected override void SetAnimationWhenReachedDestination()
    {
        animator.SetBool(IS_RUNNING, false);
    }
}
