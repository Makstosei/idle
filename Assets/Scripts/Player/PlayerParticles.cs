using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public GameObject woodHitEffect, mineHitEffect,mineHitSmoke;
    PlayerInteractionManager playerInteractionManager;

    private void Start()
    {
        playerInteractionManager = GetComponent<PlayerInteractionManager>();
    }

    void HitEffect()
    {
        if (playerInteractionManager.closestObject!=null)
        {
            switch (playerInteractionManager.closestObject.resourceTypes)
            {
                case CollectableObject.ResourceTypes.Wood:
                    woodHitEffect.SetActive(true);
                    woodHitEffect.transform.position = playerInteractionManager.closestObject.transform.position + new Vector3(0, 1, 0);
                    mineHitSmoke.SetActive(true);
                    mineHitSmoke.transform.position = playerInteractionManager.closestObject.transform.position + new Vector3(0, 1, 0);           
                    break;
                case CollectableObject.ResourceTypes.Gold:
                    mineHitEffect.SetActive(true);
                    mineHitEffect.transform.position = playerInteractionManager.closestObject.transform.position + new Vector3(0, 1, 0);
                    mineHitSmoke.SetActive(true);
                    mineHitSmoke.transform.position = playerInteractionManager.closestObject.transform.position + new Vector3(0, 1, 0);
                    break;
                default:

                    break;
            }
        }    
    }

    void EffectDisable()
    {
        woodHitEffect.SetActive(false);
        mineHitEffect.SetActive(false);
        mineHitSmoke.SetActive(false);

    }
}
