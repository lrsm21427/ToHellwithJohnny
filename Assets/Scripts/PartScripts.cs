using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "object";
            GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -1;
            // 执行操作或者初始化
        }
        else
        {
            Debug.LogError("ParticleSystem component is missing on this object!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
