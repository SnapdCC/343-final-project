using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SplashScript : MonoBehaviour
{
    VisualEffect effect;
    float FlowRate;
    float dt;
    // Start is called before the first frame update
    void Start()
    {
        effect=this.GetComponent<VisualEffect>();
        dt=0;
        FlowRate=0;
    }

    // Update is called once per frame
    void Update()
    {
        FlowRate=Mathf.Lerp(1, 0, dt);
        effect.SetFloat("FlowRate", FlowRate);
        dt=dt-Time.deltaTime;
    }
    void OnTriggerEnter(){
        dt=1;
    }
}
