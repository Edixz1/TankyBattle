using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class TankController : MonoBehaviour
{
    public InputAction move;
    public InputAction rotate;
    public InputAction shoot;
    public float speed = 5;
    public float rotateSpeed = 100;
    public UnityEvent onShoot;

    private bool isMoving = false;
    private bool isRotating = false;
    private bool isShooting = false;
    void Start()
    {
        move.Enable();
        move.started += _ => isMoving = true;
        move.canceled += _ => isMoving = false;

        rotate.Enable();
        rotate.started += _ => isRotating = true;
        rotate.canceled += _ => isRotating = false;

        shoot.Enable();
        shoot.started += _ => isShooting = true;
        shoot.canceled += _ => isShooting = false;
    }

    void Update()
    {
        float deltaMove = move.ReadValue<float>();
        float deltaRotate = rotate.ReadValue<float>();
        float tempSpeed = speed;

        if (deltaMove < 0)
            tempSpeed = speed / 2;
        if (isRotating)
            Rotate(deltaRotate);
        if (isMoving)
            Move(new Vector2(deltaMove,0),tempSpeed);
        if (isShooting)
            onShoot.Invoke();
    }
    private void Move(Vector2 delta,float speed) => transform.Translate(delta * (speed * Time.deltaTime),Space.Self);
    private void Rotate(float delta) => transform.Rotate(0,delta * (rotateSpeed * Time.deltaTime),0);

}
