using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject rockModel;
    public GameObject rockOreModel;

    public float pulseScale = 0.1f;
    public int minerals = 6;
    public float pulseDuration = 0.3f;

    private float pulseTimer;

    // Start is called before the first frame update
    void Start()
    {
        rockModel.SetActive(false);
        rockOreModel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        pulseTimer -= Time.deltaTime;

        float extraScale = pulseScale * Mathf.Max(pulseTimer / pulseDuration, 0);
        transform.localScale = new Vector3(1 + extraScale, 1 + extraScale, 1 + extraScale);
    }
    
    public void Mine()
    {
        minerals--;
        pulseTimer = pulseDuration;
        if (minerals == 0)
        {
            rockModel.SetActive(true);
            rockOreModel.SetActive(false);
        }
    }
}
