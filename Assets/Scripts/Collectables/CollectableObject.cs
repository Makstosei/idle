using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public GameObject spawnObject;
    public CollectableObject.ResourceTypes resourceTypes;
    public enum ResourceTypes { Wood, Gold }
    public int resourceAmount = 3;
    public int MaxResourceAmount = 3;
    public bool resourceFinished;
    public Animator resourceAnimator;


    private void Awake()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
        GameObject spawnedObject = Instantiate(spawnObject, gameObject.transform);
        spawnObject.transform.position = Vector3.zero;
        resourceAnimator = spawnedObject.GetComponent<Animator>();
    }
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!other.GetComponent<PlayerInteractionManager>().nearCollectableObjects.Contains(this))
            {
                other.GetComponent<PlayerInteractionManager>().nearCollectableObjects.Add(this);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerInteractionManager>().nearCollectableObjects.Contains(this))
            {
                other.GetComponent<PlayerInteractionManager>().nearCollectableObjects.Remove(this);
            }
        }
    }

 

    public void GetHit()
    {
        StartCoroutine(HitCouroutine());

    }

    IEnumerator HitCouroutine()
    {
        if (resourceAmount - 1 > 0)
        {
            resourceAmount -= 1;
            switch (resourceTypes)
            {
                case ResourceTypes.Wood:
                    resourceAnimator.SetBool("GetHit", true);
                    break;
                case ResourceTypes.Gold:
                    break;
                default:
                    break;
            }

        }
        else
        {
            resourceFinished = true;
            resourceAnimator.SetBool("Destroy", true);
            Debug.Log("Devrildi");
            resourceAmount = 0;
        }
        yield return new WaitForSecondsRealtime(0.2f);
        resourceAnimator.SetBool("GetHit", false);
        resourceAnimator.SetBool("Destroy", false);
    }


    public void ResourceAdd()
    {
        resourceAmount = MaxResourceAmount;
        resourceFinished = false;
    }


}



