using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    float angle = 0.0f;

    public float rotSpeed = 1.0f;
    Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = Vector3.back * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Player.position;
        playerPos.y += 1.0f;
        Quaternion vectorRot = Quaternion.identity;
        Vector3 forward = transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        Vector3 right = transform.right;
        right.y = 0.0f;
        right.Normalize();
        Vector3 lookVec = forward + right * Input.GetAxis("RightHorizontal") * 0.3f * rotSpeed;
        float inputAxisY = Input.GetAxis("RightVertical");
        float cameraPosY = transform.position.y - playerPos.y;
        Vector3 up = transform.up;
        up.Normalize();
        lookVec.y = inputAxisY * rotSpeed * 0.1f;
        if (transform.up.y < 0.5f)
        {
            if (cameraPosY > 0.0f && inputAxisY < 0.0f ||
                0.0f > cameraPosY && 0.0f < inputAxisY)
            {
                lookVec.y = 0.0f;
            }
        }
        vectorRot.SetFromToRotation(forward, lookVec);
        cameraPos = vectorRot * cameraPos;
        transform.position = playerPos + cameraPos;
        transform.LookAt(playerPos, Vector3.up);
    }
}
