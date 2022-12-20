using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

    public int requiredMinerals = 10;
    private bool active = false;
    public bool IsActive { get { return active; } }


    // Start is called before the first frame update
    void Start()
    {
        ChangeTransparency(0.1f);
    }

    // Update is called once per frame
    public void Activate()
    {
        active = true;
        ChangeTransparency(1f);
    }        

    void ChangeTransparency(float value)
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            foreach (Material material in renderer.materials)
            {
                // set rendering mode transparent if value less than 1 / otherwise opaque
                material.SetFloat("_Mode", value <1.0 ? 3: 0);

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
                material.renderQueue = 3000;
            }
        }
    }
}
