using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool activated ;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            activated = true;
        }
    }
     /// <summary>
     /// Start is called on the frame when a script is enabled just before
     /// any of the Update methods is called the first time.
     /// </summary>
     void Start()
     {
         PlatformDown platformDown = GetComponent<PlatformDown>();
         
     }
    public bool Activate()
    {
        activated = true;
        return activated;
    }
}
