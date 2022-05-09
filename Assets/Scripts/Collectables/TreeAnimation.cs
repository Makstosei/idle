using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimation : MonoBehaviour
{

    CollectableObject collectableObject;

    void Start()
    {
        collectableObject = transform.parent.GetComponent<CollectableObject>();
    }


    public void ResourceFilled()
    {
        collectableObject.ResourceAdd();
    }

}
