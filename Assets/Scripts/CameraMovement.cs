using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 offset;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, 10*Time.deltaTime);
    }
}
