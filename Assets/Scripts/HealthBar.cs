using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    private Slider slider;
    private float targetHealth = 0f;
    public float FillSpeed = 0.5f;
    private ParticleSystem particleSys;
    private  void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSys = GameObject.Find("coinsParticles").GetComponent<ParticleSystem>();

    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementHealthBar(0.7f); 
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value < targetHealth)
        {
            slider.value += FillSpeed * Time.deltaTime;
            if(!particleSys.isPlaying)
            {
                particleSys.Play();
            }
            else{
                particleSys.Stop();
            }
        }
            
    }

    public void IncrementHealthBar(float HealthProgress)
    {
        targetHealth = slider.value + HealthProgress;
    }
}
