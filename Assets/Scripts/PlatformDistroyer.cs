using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDistroyer : MonoBehaviour
{
    public float Health = 2f;
    public ParticleSystem particle;

    private void Awake()
    {
       // particle = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            Health--;
            if (Health == 0)
            {
                GameObject particleDestroy = Instantiate(particle.gameObject);
                particle.Emit(30);
                Destroy(particleDestroy,10f); 
                

                Destroy(this.gameObject);
                //Debug.LogError("particle");
            }
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
}
