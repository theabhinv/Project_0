using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public ParticleSystem particle;
    public float moveDistance = 1f;
    public float defaultPosition;
    public GameObject CoinsEffect;
    public float moveSpeed = 0.2f;
    public float ScoreCount = 1f;
     void Update()
    {
        transform.position = new Vector3( transform.position.x, Mathf.Sin(Time.time * moveSpeed + transform.position.x) * moveDistance + defaultPosition, 0f);  
    }

    void Start()
    {
        defaultPosition =  transform.position.y;
    }
    private  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Instantiate(CoinsEffect,transform.position,Quaternion.identity);
            other.gameObject.GetComponent<PlayerMovement>().Score += ScoreCount;
            //Debug.Log(other.gameObject.GetComponent<PlayerMovement>().Score);
                        
            Destroy(gameObject);
        }    
        
                
    }   
   
}
