using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BobbingRotator : MonoBehaviour
{
    [SerializeField] public Vector3 spinVector = new Vector3(0f,45f,0f);
    [SerializeField] public float bobAmount = 0.75f;
    [SerializeField] public float bobSpeed = 0.001f;
    private Vector3 currentVector,startVector,targetVector;
    // Start is called before the first frame update
    void Start()
    {
        startVector = transform.localPosition;
        // currentVector = targetVector;
    }

    // Update is called once per frame
    void Update()
    {
        // int[] directions = {-1,1};
        // dirX = directions[Random.Range(0,2)];
        // dirY = directions[Random.Range(0,2)];
        // dirZ = directions[Random.Range(0,2)]; 
        // startVector = new Vector3(dirX*Random.Range(lowerAngle,upperAngle),dirY*Random.Range(lowerAngle,upperAngle),dirZ*Random.Range(lowerAngle,upperAngle));
        // if(transform.localPosition.y == startVector.y)
        // {
        //     transform.DOMoveY(startVector.y+bobAmount,bobDuration);               
        // }
        // else if(transform.localPosition.y == startVector.y+bobAmount)
        // {
        //     transform.DOMoveY(startVector.y,bobDuration);
        // }
        if(transform.localPosition == startVector)
        {
            // transform.DOMoveY(startVector.y+bobAmount,bobDuration);    
            targetVector =  startVector + new Vector3(0,bobAmount,0);          
        }
        else if(transform.localPosition == startVector + new Vector3(0,bobAmount,0))
        {
            targetVector =  startVector;
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetVector, bobSpeed);
        // spinVector = startVector;
        transform.Rotate (spinVector * Time.deltaTime);
    }
}
