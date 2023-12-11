using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movimietno_Daniel : MonoBehaviour
{
    public SimpleTouchController leftController;
    public SimpleTouchController rightController;
    public Transform playerTransform; // Transform del objeto que se va a mover (representa al jugador)
    public Transform cameraPivot; // Punto de pivote para la cámara
    public float movementSpeed = 5f;
    public float rotationSpeed = 300f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        rightController.TouchEvent += RightController_TouchEvent;
    }

    private void RightController_TouchEvent(Vector2 value)
    {
        //UpdateAim(value);
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(leftController.GetTouchPosition.x, 0f, leftController.GetTouchPosition.y).normalized;
        Vector3 movement = playerTransform.TransformDirection(moveDirection) * movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void RotatePlayer()
    {
        Vector3 rotateDirection = new Vector3(rightController.GetTouchPosition.x, 0f, rightController.GetTouchPosition.y);
        Vector3 cameraForward = cameraPivot.forward;
        cameraForward.y = 0; // Eliminar el componente Y para evitar inclinaciones no deseadas

        Quaternion toRotation = Quaternion.LookRotation(cameraForward, Vector3.up);
        playerTransform.rotation = Quaternion.RotateTowards(playerTransform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        rightController.TouchEvent -= RightController_TouchEvent;
    }
}
