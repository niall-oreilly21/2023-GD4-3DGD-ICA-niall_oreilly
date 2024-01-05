using System.Collections;
using System.Collections.Generic;
using GD.Controllers;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerContoller : CharacterNavigationController
{
    
    private AudioSource audioSource;
    
    private const string IS_RUNNING = "isRunning";

    protected void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void SetAnimationWhenGoingToDestination()
    {
        animator.SetBool(IS_RUNNING, true);
    }

    protected override void SetAnimationWhenReachedDestination()
    {
        animator.SetBool(IS_RUNNING, false);
    }

    private bool isPlayingFootsteps = false;

    protected void Update()
    {
        base.Update();
        if (animator.GetBool(IS_RUNNING))
        {
            if (!isPlayingFootsteps)
            {
                StartCoroutine(PlayFootsteps());
            }
        }
    }

    private IEnumerator PlayFootsteps()
    {
        isPlayingFootsteps = true;
        
        audioSource.Play();

        // Wait for the length of the clip
        yield return new WaitForSeconds(audioSource.clip.length);

        isPlayingFootsteps = false;
    }
}
