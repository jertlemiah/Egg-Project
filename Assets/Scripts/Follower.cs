using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] public Transform targetTransform;
    public bool exact = true;
    public bool matchRotation = false;
    public float followDistance;

    // Update is called once per frame
    void Update()
    {
        if(exact)
        {
            transform.position = targetTransform.position;
        }
        
    }
}
