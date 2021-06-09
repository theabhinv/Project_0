using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   public float EnemySpeed;

   [HideInInspector]
   public bool Patrol_m;
   private bool Turn;

   public Rigidbody2D rigidbody2D;
   public Transform GroundCheck;
   public LayerMask layerMask;
   public Collider2D bodycollider2d;

   
   void Start()
   {
       Patrol_m = true;
   }
   
   void Update()
   {
      if(Patrol_m)
      {
         Patrol();
      }   
   }

   
   void FixedUpdate()
   {
      if(Patrol_m)
      {
         Turn = !Physics2D.OverlapCircle(GroundCheck.position,0.5f,layerMask);
      }    
   }
   
   void Patrol()
   {
       if(Turn || bodycollider2d.IsTouchingLayers(layerMask))
       {
          Flip();
       }
      rigidbody2D.velocity = new Vector2(EnemySpeed * Time.fixedDeltaTime,rigidbody2D.velocity.y);
       
   }

   void Flip()
   {
      Patrol_m = false;
      transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y);
      EnemySpeed *= -1;
      Patrol_m = true;

   }

}
