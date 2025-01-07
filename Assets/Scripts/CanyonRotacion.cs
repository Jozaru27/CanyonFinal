using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonRotacion : MonoBehaviour
{

    [SerializeField] Transform Cruceta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.LookAt(Cruceta.position, Vector3.up);
    }
}
