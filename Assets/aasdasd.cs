using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aasdasd : MonoBehaviour
{
    public meta _meta;
    // Start is called before the first frame update
    void Start()
    {
        _meta = GetComponent<meta>();
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            _meta.enabled = true;
        }
    }
}
