using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip footstepLeft, footstepRight;
    public AudioSource audioSource;
    public List<AudioClip> WoodHitSounds, MineHitSounds;
    private PlayerInteractionManager playerInteractionManager;

    private void Start()
    {
        playerInteractionManager = GetComponent<PlayerInteractionManager>();
    }




    void LeftFootstep()
    {
        audioSource.PlayOneShot(footstepLeft);
    }

    void RightFootstep()
    {
        audioSource.PlayOneShot(footstepRight);
    }

    void woodHit()
    {
        int randomint = Random.Range(0, WoodHitSounds.Count);
        audioSource.PlayOneShot(WoodHitSounds[randomint]);
        playerInteractionManager.closestObject.GetHit();
    }
    void mineHit()
    {
        int randomint = Random.Range(0, MineHitSounds.Count);
        audioSource.PlayOneShot(MineHitSounds[randomint]);
        playerInteractionManager.closestObject.GetHit();
    }

}
