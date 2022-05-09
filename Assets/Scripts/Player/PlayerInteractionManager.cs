using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    public List<CollectableObject> nearCollectableObjects;
    public int InventorySpace;
    public int MaxInventorySpace;
    public CollectableObject closestObject;
    public float closestObjectDistance;


    public void FindClosestObject()
    {
        if (nearCollectableObjects.Count>0)
        {
            closestObjectDistance = 0;
            closestObject = null;
            foreach (var item in nearCollectableObjects)
            {
                float distance = Vector3.Distance(item.gameObject.transform.position, gameObject.transform.position);
                if (closestObjectDistance == 0)
                {
                    closestObjectDistance = distance;
                    closestObject = item;
                }
                else
                {
                    if (distance < closestObjectDistance)
                    {
                        closestObjectDistance = distance;
                        closestObject = item;
                    }
                }

            }
        }
        else
        {
            closestObjectDistance = 0;
            closestObject = null;
        } 
    }

}
