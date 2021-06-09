using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDisable : MonoBehaviour
{
    public GameObject BoxBreakEffect;
    //public GameObject WallBreakEffect;
        public wallDistroy wall;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" && other.contacts[0].normal.y > 0.5f)
        {
            Instantiate(BoxBreakEffect,transform.position,Quaternion.identity);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);
            Destroy(GameObject.FindWithTag("Wallie"));

            
           
            
            
        }
    }
}
