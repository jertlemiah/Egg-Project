/* Author: Jeremiah Ashton Plauche
Original script by Unity Tutorials, heavily modified by Jeremiah

*/

using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour 
{
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed, growDuration = 2;
    [SerializeField] public int winAmount = 10;
    [SerializeField] [Range(0, 1)] public float growAmount = 0.5f;
    [SerializeField] private float currentScale, startScale, targetScale;
    [SerializeField] Slider eggSlider;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;

    InputActions inputActions;
    public Vector3 direction;
    [SerializeField] GameObject arrowGO;

	// At the start of the game..
	
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Quit.performed += ctx => WinGame();

    }
    void Start ()
	{
		// controller = GetComponent<CharacterController>();
        // // inputManager = InputManager.Instance;
        // cameraTransform = Camera.main.transform;
        
        // Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText ();
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        currentScale = gameObject.transform.localScale.x;
        startScale = currentScale;
        targetScale = currentScale;
	}

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        // currentScale = Mathf.Lerp(startScale,targetScale,growDuration);
        // gameObject.transform.localScale = new Vector3 (currentScale, currentScale, currentScale);
        // transform.DOScale(new Vector3 (targetScale, targetScale, targetScale),growDuration);
    }

	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		// direction = new Vector3 (movementX, 0.0f, movementY);
        // // float angle = Vector2.Angle(movementX*Vector2.right, movementY*Vector2.up);
        // float angle = Vector3.SignedAngle(direction,Vector3.left,Vector3.down);
        if(direction.magnitude > 0)
        {
            // arrowGO.transform.rotation = Quaternion.Euler(arrowGO.transform.rotation.x,angle,arrowGO.transform.rotation.z);
            rb.AddForce (direction * speed);
        }
        
		
	}

	// void OnTriggerEnter(Collider other) 
	// {
	// 	// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
	// 	if (other.gameObject.CompareTag ("PickUp"))
	// 	{
	// 		other.gameObject.SetActive (false);
    //         // Destroy(other);

	// 		// Add one to the score variable 'count'
	// 		count = count + 1;

	// 		// Run the 'SetCountText()' function (see below)
	// 		SetCountText ();
    //         GrowEgg();
	// 	}
	// }

    void GrowEgg()
    {
        // float 
        // float newScale = currentScale+growAmount;
        // gameObject.transform.localScale = new Vector3(newScale,newScale,newScale);
        currentScale = gameObject.transform.localScale.x;
        // targetScale = currentScale+growAmount;
        targetScale = currentScale + growAmount * currentScale;
        // targetScale = currentScale*(1+growAmount);
        startScale = currentScale;

        transform.DOScale(new Vector3 (targetScale, 0.9f*targetScale, targetScale),growDuration);
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
        direction = new Vector3 (movementX, 0.0f, movementY);
        if(v.magnitude > 0)
        {
            
            // float angle = Vector2.Angle(movementX*Vector2.right, movementY*Vector2.up);
            float angle = Vector3.SignedAngle(direction,Vector3.right,Vector3.down);
            // arrowGO.transform.rotation = Quaternion.Euler(arrowGO.transform.rotation.x,angle,arrowGO.transform.rotation.z);
            // arrowGO.transform.DORotate(newDirection,growDuration);
            arrowGO.transform.DORotateQuaternion(Quaternion.Euler(arrowGO.transform.rotation.x,angle,arrowGO.transform.rotation.z),growDuration);
            // direction = newDirection;
        }
        
    }

    public void WinGame()
    {
        winTextObject.SetActive(true);
    }

    void SetCountText()
	{
		countText.text = count.ToString()+"% full!";

		// if (count >= winAmount) 
        if (count >= 1f) 
		{
            // Set the text value of your 'winText'
            WinGame();
		}
	}
}
