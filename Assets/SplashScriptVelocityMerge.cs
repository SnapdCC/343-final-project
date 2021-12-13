using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SplashScriptVelocityMerge : MonoBehaviour
{
    VisualEffect effect;
    float FlowRate;
    float dt;
    float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        effect=this.GetComponent<VisualEffect>();
        dt=0.0f;
        FlowRate=0.0f;
        magnitude = 1;
    }

    // Update is called once per frame
    void Update()
    {
        FlowRate=Mathf.Lerp(1.0f, 0.0f, dt*4.0f);
        
        effect.SetFloat("FlowRate", FlowRate);
        dt = Mathf.Min(.25f, dt + Time.deltaTime);
        if (Input.GetButtonDown("Fire2")){
            dt = 0.0f;
        }
    }
    void OnTriggerEnter(Collider other){
        Rigidbody rb = other.GetComponent<Rigidbody>();
        magnitude = rb.velocity.magnitude * rb.mass / 3;
        effect.SetFloat("Magnitude", magnitude);
        Debug.Log(magnitude);
        dt = 0.0f;
    }
}
