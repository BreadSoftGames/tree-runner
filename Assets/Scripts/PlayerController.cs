using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject raftDeathEffect;
    public GameObject raftParent;

    Rigidbody rb;

    float startPosBall;
    Vector3 clickStart;
    float ratio;

    public float speed;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

        if (Screen.width == 750)
        {
            ratio = 105f;
        }
        else if (Screen.width == 1125)
        {
            ratio = 156f;
        }
        else if (Screen.width == 1242)
        {
            ratio = 172.5f;
        }
        else
        {
            ratio = 150f;
        }
    }

    void Update()
    {
        InputChecker();
        Vector3 targetPos = transform.position + new Vector3(0f, 0f, speed * 50f) * Time.fixedDeltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
    }

    void InputChecker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosBall = raftParent.transform.position.x;
            clickStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            MoveForward();
        }
        else if (Input.GetMouseButtonUp(0))
        {

        }
    }

    void MoveForward()
    {
        if (clickStart.x - Input.mousePosition.x < 0)
        {
            Vector3 pos = raftParent.transform.localPosition;
            pos.x = Mathf.Clamp(startPosBall + Mathf.Abs(clickStart.x - Input.mousePosition.x) / ratio, -5f, 5f);
            pos.y = 0;
            pos.z = 0;
            raftParent.transform.localPosition = Vector3.Lerp(raftParent.transform.localPosition, pos, 0.5f);
        }
        else if (clickStart.x + Input.mousePosition.x > 0)
        {
            Vector3 pos = raftParent.transform.localPosition;
            pos.x = Mathf.Clamp(startPosBall - Mathf.Abs(clickStart.x - Input.mousePosition.x) / ratio, -5f, 5f);
            pos.y = 0;
            pos.z = 0;
            raftParent.transform.localPosition = Vector3.Lerp(raftParent.transform.localPosition, pos, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Raft" && !collision.transform.GetComponent<Raft>().activated)
        {
            collision.transform.GetComponent<Raft>().activated = true;
            collision.transform.GetComponent<Raft>().activatedFlag = true;
            collision.transform.SetParent(raftParent.transform);
        }
        if(collision.transform.tag == "Rock")
        {
            Collider myCollider = collision.contacts[0].thisCollider;
            Instantiate(raftDeathEffect, myCollider.transform.position, Quaternion.identity);
            Destroy(myCollider.gameObject);
            Debug.Log(myCollider.name);
        }
    }
}
