using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackControl : MonoBehaviour
{
    public float lifespan = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
