using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class camera : MonoBehaviour
{
    public bool mouse = false;
    public Toggle togle_mouse;
    public int speed_mouse = 20;
    [Space]
    public Transform target;
    public float smoothSpeed = 0.125f;
    [Space]
    public Slider cam_value_slider_x;
    public Slider cam_value_slider_y;
    public Slider cam_value_slider_z;
    [Space]
    public Vector3 offset;


    void fixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);


    }


    void Start()
    {

    }


    void LateUpdate()
    {

        if (mouse)
        {
            offset.x += Input.GetAxis("Mouse X") * speed_mouse;
            offset.y += Input.GetAxis("Mouse Y") * speed_mouse;

            if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += speed_mouse;
            if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= speed_mouse;

            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        else
        {
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);

        cam_value_slider_x.value = offset.x;
        cam_value_slider_y.value = offset.y;
        cam_value_slider_z.value = offset.z;

        if (Input.GetMouseButtonDown(2)) togle_mouse.isOn =! togle_mouse.isOn;
        mouse = togle_mouse.isOn ;
    }


    public void slider_x_cam(float newValueCamX)
    {
        offset.x = newValueCamX;
    }


    public void slider_y_cam(float newValueCamY)
    {
        offset.y = newValueCamY;
    }


    public void slider_z_cam(float newValueCamZ)
    {
        offset.z = newValueCamZ;
    }

    public void toggle_mouse_cam(bool newValueToggle)
    {
        mouse = newValueToggle;
    }


}
