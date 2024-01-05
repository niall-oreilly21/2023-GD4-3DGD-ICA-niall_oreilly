using System.Collections;
using GD.Controllers;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Player
{
    /// <summary>
    /// Unity MonoBehaviour for controlling the player character, handling navigation and animations.
    /// </summary>
    public class PlayerController : CharacterNavigationController
    {
        #region Fields
    
        private AudioSource audioSource;
    
        private const string IS_RUNNING = "isRunning";
        
        private bool isPlayingFootsteps;
    
        #endregion

        protected void Start()
        {
            base.Start();
            audioSource = GetComponent<AudioSource>();
            isPlayingFootsteps = false;
        }

        /// <summary>
        /// Sets the animation when going to the destination.
        /// </summary>
        protected override void SetAnimationWhenGoingToDestination()
        {
            animator.SetBool(IS_RUNNING, true);
        }

        /// <summary>
        /// Sets the animation when reaching the destination.
        /// </summary>
        protected override void SetAnimationWhenReachedDestination()
        {
            animator.SetBool(IS_RUNNING, false);
        }

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

        /// <summary>
        /// Plays the sound of footsteps on loop.
        /// </summary>
        private IEnumerator PlayFootsteps()
        {
            isPlayingFootsteps = true;
        
            audioSource.Play();

            // Wait for the length of the clip
            yield return new WaitForSeconds(audioSource.clip.length);

            isPlayingFootsteps = false;
        }
    }
}
