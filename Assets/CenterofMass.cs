using UnityEngine;
using System.Collections;

public class CenterofMass : MonoBehaviour
{
    public Vector3 com;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {

        com = this.transform.position;

        rb.centerOfMass = com;
    }

}
