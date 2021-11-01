using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombine : MonoBehaviour
{
    private void Start()
    {
        cmb();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            cmb();
        }
    }

    void cmb()
    {
        Debug.Log("COMBINED");
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        var meshCombine = transform.GetComponent<MeshFilter>();
        meshCombine.mesh = new Mesh();
        meshCombine.mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);

        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

    }

}
