using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    private float Speed;
    private float x;//x方向のInput値
    private float z;//z方向のInput値

    private Vector3 Player_pos;

    // Start is called before the first frame update
    void Start()
    {
        Player_pos = GetComponent<Transform>().position;//プレイヤーポジション取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }   
    private void FixedUpdate()
    {
         x = Input.GetAxis("Horizontal") * Speed;
         z = Input.GetAxis("Vertical") * Speed;
        rb.AddForce(x, 0, z);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 diff = transform.position - Player_pos;

        if(diff.magnitude>0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }
        Player_pos = transform.position;

       


    }
}