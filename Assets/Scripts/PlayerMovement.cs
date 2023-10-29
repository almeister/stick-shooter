using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField, Range(0, 100)] float movementSpeed = 30f;
  [SerializeField] float rotationSpeed = 5f;

  public Transform head;

  private float yaw = 0f;
  private float pitch = 0f;


  // Update is called once per frame
  void Update()
  {
    ProcessMovement();
  }

  void LateUpdate()
  {
    ProcessMouseMovement();
  }

  private void ProcessMovement()
  {
    float xAxis = Input.GetAxis("Horizontal");
    Debug.Log($"xAxis: {xAxis}");
    float zAxis = Input.GetAxis("Vertical");
    Debug.Log($"zAxis: {zAxis}");

    Vector3 movement = new Vector3(xAxis, 0, zAxis);
    transform.Translate(movementSpeed * Time.deltaTime * movement, transform);
  }

  private void ProcessMouseMovement()
  {
    yaw += Input.GetAxis("Mouse X") * rotationSpeed;
    transform.eulerAngles = new Vector3(0, yaw, 0);

    pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
    pitch = Mathf.Clamp(pitch, -80f, 80f);
    head.transform.localEulerAngles = new Vector3(pitch, 0, 0);
  }
}
