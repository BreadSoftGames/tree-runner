using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    public Material woodMat;

    public bool activated;
    public bool activatedFlag;
    public GameObject character;
    public GameObject[] logs;

    void Start()
    {
        if (transform.parent == null)
        {
            activated = false;
            activatedFlag = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activatedFlag)
        {
            for (int i = 0; i < logs.Length; i++)
            {
                logs[i].GetComponent<MeshRenderer>().material = woodMat;
            }
            activatedFlag = false;
        }

        if (activated && character.transform.rotation.eulerAngles.y != 0f)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward);
            character.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2 * Time.deltaTime);
        }
    }
}
