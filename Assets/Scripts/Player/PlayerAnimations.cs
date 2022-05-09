using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Rigidbody playerRB;
    Animator playerAnimator;
    PlayerInteractionManager playerInteractionManager;
    PlayerController playerController;
    public GameObject playerAxe, playerPickaxe;
    PlayerParticles playerParticles;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerInteractionManager = GetComponent<PlayerInteractionManager>();
        playerController = GetComponent<PlayerController>();
        playerParticles = GetComponent<PlayerParticles>();
    }
    void Update()
    {
        if (playerRB.velocity.magnitude>=0.01)
        {
            playerAnimator.SetFloat("Speed", playerRB.velocity.magnitude);
        }
        else
        {
            playerAnimator.SetFloat("Speed",0);
        }

        switch (PlayerStateManager.Instance.playerState)
        {
            case PlayerStateManager.PlayerStates.Idle:
                if (playerInteractionManager.closestObject != null&& !playerInteractionManager.closestObject.resourceFinished)
                {
                    transform.LookAt(playerInteractionManager.closestObject.transform);

                    switch (playerInteractionManager.closestObject.resourceTypes)
                    {
                        case CollectableObject.ResourceTypes.Wood:
                            playerAnimator.SetBool("Chop", true);
                            playerAxe.SetActive(true);
                            break;
                        case CollectableObject.ResourceTypes.Gold:
                            playerAnimator.SetBool("Mine", true);
                            playerPickaxe.SetActive(true);
                            break;
                        default:

                            break;
                    }

                }
                else
                {
                    StopAllEffects();
                }
                break;

            case PlayerStateManager.PlayerStates.Run:
                StopAllEffects();
                break;
            case PlayerStateManager.PlayerStates.Chop:

                break;
            case PlayerStateManager.PlayerStates.Mine:
                break;
            default:
                break;
        }
    }


    void StopAllEffects()
    {
        playerAnimator.SetBool("Mine", false);
        playerAnimator.SetBool("Chop", false);
        playerAxe.SetActive(false);
        playerPickaxe.SetActive(false);
        playerParticles.mineHitEffect.SetActive(false);
        playerParticles.mineHitSmoke.SetActive(false);
        playerParticles.woodHitEffect.SetActive(false);
    }
   

}
