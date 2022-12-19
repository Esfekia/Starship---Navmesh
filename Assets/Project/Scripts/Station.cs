using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeTransparency(0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeTransparency(float value)
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            foreach (Material material in renderer.materials)
            {
                // set mode to transparent
                material.SetFloat("_Mode", 3);

                // change color
                Color currentColor = material.GetColor("_Color");
                currentColor.a = value;
                material.SetColor("_Color", currentColor);

                // rendering adjustments
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_Zwrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
              
            }
        }
    }
}
