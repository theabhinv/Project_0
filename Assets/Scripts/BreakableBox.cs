using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 4f;
    public GameObject BoxBreakEffect;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() && other.contacts[0].normal.y > 0.5f)
        {
           StartCoroutine( Pickup(other));
            
        }
    }

    IEnumerator Pickup(Collision2D player)
    {
        Instantiate(BoxBreakEffect,transform.position,Quaternion.identity);
        player.transform.localScale *= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new  WaitForSeconds(duration);
        player.transform.localScale /= multiplier;
        Destroy(gameObject);
    }
}
