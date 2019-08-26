using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Speed*Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Speed*Time.deltaTime;
        rb.AddForce(x, 0, z);
    }
}