using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKArmControl : MonoBehaviour
{
    
    protected Animator animator;
    
    public bool ikActive = false;
    public Transform eggObj = null;
    public Transform IKTargetLeftHand = null;
    public Transform IKTargetRightHand = null;
    public Transform lookObj = null;

    void Start () 
    {
        animator = GetComponent<Animator>();
    }
    
    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if(animator) {
            
            //if the IK is active, set the position and rotation directly to the goal. 
            if(ikActive) {

                // Set the look target position, if one has been assigned
                // if(lookObj != null) {
                //     animator.SetLookAtWeight(1);
                //     animator.SetLookAtPosition(lookObj.position);
                // }    

                // Set the right hand target position and rotation, if one has been assigned
                if(eggObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1);  
                    animator.SetIKPosition(AvatarIKGoal.RightHand,IKTargetRightHand.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand,IKTargetRightHand.rotation);

                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
                    animator.SetIKPosition(AvatarIKGoal.LeftHand,IKTargetLeftHand.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand,IKTargetLeftHand.rotation);
                }        
                
            }
            
            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else {          
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 
                animator.SetLookAtWeight(0);
            }
        }
    }    
}
