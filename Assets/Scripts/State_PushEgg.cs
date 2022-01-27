using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PushEgg : MonoBehaviour
{
    public GameObject eggGO;
    public NewPlayerController controller;
    public float radius = 1f, armsDistance = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float radius;
        Vector3 dir = (eggGO.transform.position - transform.position).normalized;

        // dir = Vector3.MoveTowards(transform.position,eggGO.transform.position,1f);

        // controller.movement = new Vector2(dir.x, dir.y);
        radius = eggGO.GetComponent<SphereCollider>().radius*eggGO.transform.localScale.y;
        transform.position = eggGO.transform.position - dir*(radius + armsDistance);
    }
}
