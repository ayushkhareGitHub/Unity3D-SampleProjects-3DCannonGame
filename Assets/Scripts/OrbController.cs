using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OrbController : MonoBehaviour
{
    public Action onOrbDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.name);

        if (c.gameObject.GetComponent<FloorController>() != null)
        {
            GameObject.Destroy(this.gameObject);
            onOrbDestroyed();
        }

        if (c.gameObject.GetComponent<BulletController>() != null)
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(c.gameObject);
            onOrbDestroyed();
        }
    }
}
