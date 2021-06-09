using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    private float damage = 1f;
    public float intensity= 5f;
    public float time = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().health -= damage;
            Debug.Log(collision.gameObject.GetComponent<PlayerMovement>().health);
            CameraShake.Instance.ShakeCamera(intensity,time);
            
            
        }
    }
    

    
    
}
