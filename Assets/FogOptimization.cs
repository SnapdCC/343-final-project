using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FogOptimization : MonoBehaviour
{
    float SpawnRate;
    public float TargetFramerateLow=24.0f;
    public float TargetFramerateHigh=60.0f;
    VisualEffect effect;
    // Start is called before the first frame update
    void Start()
    {
        effect=this.GetComponent<VisualEffect>();
        effect.SetVector3("Object Scale", this.transform.lossyScale);
        SpawnRate = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime<1.0f/TargetFramerateLow){
            SpawnRate=Mathf.Max(0.0f, SpawnRate-1.0f);
        }
        if(Time.deltaTime>1.0f/TargetFramerateHigh){
            SpawnRate++;
        }
        effect.SetFloat("Density", SpawnRate);
    }
}
