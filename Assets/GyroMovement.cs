using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMovement : MonoBehaviour
{
    CharacterController controller;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.rotation = Input.gyro.attitude;
        camera.transform.Rotate(0f, 0f, 180f, Space.Self);
        camera.transform.Rotate(90f, 180f, 0f, Space.World);
        if (Input.touchCount > 0)
        {
            controller.Move(camera.transform.forward * 2 * Time.deltaTime);
        }
        else
        {
            controller.Move(Vector3.zero);
        }

    }

    void RotateCam()
    {
        camera.transform.rotation = GyroConvert(Input.gyro.attitude);
    }

    Quaternion GyroConvert(Quaternion q)
    {
        return new Quaternion(q.x*0.5f, q.z, 0, -q.w);
    }
}
