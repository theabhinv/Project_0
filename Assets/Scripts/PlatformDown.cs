using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour
{
    [SerializeField]
    private Transform platformCheck, platforGround;
    public LayerMask PlayerLayerMask;
    public float PlayerCehckRadius=0.2f;
    public float speed = 1f;
    public bool switching = false;
    public GameObject PlayerMovementScript;

    
    // Start is called before the first frame update
    void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(platformCheck.position,PlayerCehckRadius,PlayerLayerMask);
        //Debug.DrawRay(platformCheck.position,Vector3.up,Color.red);
        
        
        if(hit == true)
        {
            PlayerMovementScript.transform.parent = transform;
            transform.position = Vector3.MoveTowards(transform.position,platforGround.position,speed*Time.deltaTime);
        }
        else 
        {
            PlayerMovementScript.transform.parent = null;
            switching = false;
        }        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
