using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FogOptimization : MonoBehaviour
{
    float SpawnRate;
    public float TargetFramerate = 55.0f;
    float targetDT;
    VisualEffect effect;
    // Start is called before the first frame update
    void Start()
    {
        effect=this.GetComponent<VisualEffect>();
        //effect.SetVector3("Object Scale", this.transform.lossyScale);
        SpawnRate = .5f;
        targetDT = 1 / TargetFramerate;
    }

    // Update is called once per frame
    void Update()
    {
        //Basically, if your framerate is lower than desired, more fog is spawned
        SpawnRate += (1.0f - (Time.deltaTime / targetDT))/1000.0f;
        SpawnRate = Mathf.Clamp(SpawnRate, 0.1f, 1.5f);
        effect.SetFloat("Density", SpawnRate);
    }
}
