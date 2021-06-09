using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDistroy : MonoBehaviour
{
    public float intensity= 5f;
    public float time = 0.1f;
    public float moveSpeed = 0.2f;
    public float moveDistance = 1f;
    public float defaultPosition;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position = new Vector3( transform.position.x, Mathf.Sin(Time.time * moveSpeed + transform.position.x) * moveDistance + defaultPosition, 0f);
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => defaultPosition = transform.position.y;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<PlayerMovement>().health -= 5;
            Debug.Log(other.gameObject.GetComponent<PlayerMovement>().health);
            CameraShake.Instance.ShakeCamera(intensity,time);
        }
    }
    
    
}
