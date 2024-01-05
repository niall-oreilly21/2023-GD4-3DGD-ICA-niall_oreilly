using System.Collections;
using System.Collections.Generic;
using GD.Controllers;

public class PlayerContoller : CharacterNavigationController
{
    private const string IS_RUNNING = "isRunning";

    protected override void SetAnimationWhenGoingToDestination()
    {
        animator.SetBool(IS_RUNNING, true);
    }

    protected override void SetAnimationWhenReachedDestination()
    {
        animator.SetBool(IS_RUNNING, false);
    }
}
