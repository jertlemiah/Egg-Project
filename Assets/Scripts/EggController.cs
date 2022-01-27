using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class EggController : MonoBehaviour
{
    [SerializeField] public float scaleMin = 0.1f, scaleMax = 1;
    [SerializeField] public float currentSize = 10f, fillMax = 100;
    [SerializeField] private float currentScale, startScale, targetScale;
    [SerializeField] public float eatModifier = 0.7f;
    [SerializeField] public float growDuration = 2;

    [SerializeField] Slider eggSlider;
    public Color eggColor;
    public GameObject sliderFill;

    public List<Color> eatenColors = new List<Color>();
    public TextMeshProUGUI countText;
    [SerializeField] PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        scaleMin = gameObject.transform.localScale.x;
        eatenColors.Add(eggColor);
        GrowEgg();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		// if (other.gameObject.CompareTag ("PickUp"))
        FoodPickup foodPickup;
        collision.gameObject.TryGetComponent<FoodPickup>(out foodPickup);
        if (foodPickup && foodPickup.size*eatModifier < currentSize)
		{
			// collision.transform.parent = transform;
            // // other.gameObject.SetActive (false);
            // FixedJoint joint = collision.gameObject.AddComponent<FixedJoint>();
            // joint.connectedMassScale = 0f;
            // joint.connectedBody = gameObject.GetComponent<Rigidbody>();
            

			// Add one to the score variable 'count'
			// count = count + 1;
            currentSize += foodPickup.size;
            if (currentSize > fillMax)
                currentSize = fillMax;

			// Run the 'SetCountText()' function (see below)
			// SetCountText ();
            eatenColors.Add(foodPickup.color);
            GrowEgg();
            Destroy(collision.gameObject);
            
            // GetComponent<Renderer>().material.color = foodPickup.color;
		}
	}

    void GrowEgg()
    {
        // float 
        // float newScale = currentScale+growAmount;
        // gameObject.transform.localScale = new Vector3(newScale,newScale,newScale);
        currentScale = gameObject.transform.localScale.y;
        // targetScale = currentScale+growAmount;
        targetScale = (currentSize/fillMax) * (scaleMax-scaleMin) + scaleMin;
        // targetScale = currentScale + growAmount * currentScale;
        // targetScale = currentScale*(1+growAmount);
        startScale = currentScale;

        transform.DOScale(new Vector3 (targetScale*1.2f, targetScale, targetScale*1.2f),growDuration);
        // eggSlider.value = (fillLevel/fillMax);
        eggSlider.DOValue((currentSize/fillMax),growDuration);
        // eggSlider.
        float r = 0, g = 0, b = 0;
        foreach(Color c in eatenColors)
        {
            r += c.r;
            g += c.g;
            b += c.b;
        }
        float num = eatenColors.Count;
        // GetComponent<Renderer>().material.color = new Color(r/num,g/num,b/num);
        eggColor = new Color(r/num,g/num,b/num);
        GetComponentInChildren<Renderer>().material.DOColor(eggColor,growDuration);
        sliderFill.GetComponent<Image>().DOColor(eggColor,growDuration);
        SetCountText();
    }

    void SetCountText()
	{
		int per = (int)((currentSize/fillMax)*100);
        countText.text = per.ToString()+"% full!";

        if (per >= 98) 
		{
            playerController.WinGame();
		}
	}
}
