/* Author: Jeremiah Ashton Plauche
Original script by Unity Tutorials, heavily modified by Jeremiah

*/
using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	[SerializeField] private Vector3 spinVector, startVector = new Vector3(15, 30, 45), endVector;
    [SerializeField] private float lerpTime = 5f, lowerAngle = 0, upperAngle = 180;
    [SerializeField] private int dirX = 1, dirY = 1, dirZ = 1;

    void Awake()
    {
        int[] directions = {-1,1};
        dirX = directions[Random.Range(0,2)];
        dirY = directions[Random.Range(0,2)];
        dirZ = directions[Random.Range(0,2)]; 
        startVector = new Vector3(dirX*Random.Range(lowerAngle,upperAngle),dirY*Random.Range(lowerAngle,upperAngle),dirZ*Random.Range(lowerAngle,upperAngle));
        
        spinVector = startVector;
    }

    // Before rendering each frame..
	void Update () 
	{
		if (spinVector == endVector)
        {
            startVector = spinVector;
            endVector = new Vector3(dirX*Random.Range(lowerAngle,upperAngle),dirY*Random.Range(lowerAngle,upperAngle),dirZ*Random.Range(lowerAngle,upperAngle));
        }
        spinVector = Vector3.Lerp(startVector,endVector,lerpTime);

        transform.Rotate (spinVector * Time.deltaTime);
        // Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		// transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}	