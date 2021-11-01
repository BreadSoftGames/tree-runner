using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyYourSelf : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", time);
    }

    void Death()
    {
        Destroy(transform.gameObject);
    }
}
