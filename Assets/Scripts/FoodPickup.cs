using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    [SerializeField] public float size = 5;
    [SerializeField] public Color color;
    [SerializeField] public bool useMaterialColor = true;
    [SerializeField] public Collider groundCollider;

    void Awake()
    {
        if(useMaterialColor)
        {
            color = GetComponent<Renderer>().material.color;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		// if (other.gameObject.CompareTag ("PickUp"))
        if (other.gameObject.tag == "Rollable")
		{
			// groundCollider.enabled = false;
		}
	}
}
