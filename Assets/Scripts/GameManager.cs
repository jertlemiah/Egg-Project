using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Camera currentCam;
    [SerializeField] public GameObject playerGO;
    [SerializeField] public GameObject currentEgg;
    public InputActions inputActions;
    // Start is called before the first frame update
    // void OnEnable()
    // {
    //     inputActions.Enable();
    // }

    // void OnDisable()
    // {
    //     inputActions.Disable();
    // }
    void Start()
    {
        currentCam = Camera.main;
        inputActions = new InputActions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CameraAngleToPlayer()
    {

    }

}
