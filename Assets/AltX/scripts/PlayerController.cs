using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AltX.scripts
{
    public class PlayerController : MonoBehaviour
    {


        private CharacterController characterController;

        [SerializeField]
        private float speed = 3.0f;
        [SerializeField]
        private float jumpSpeed = 8.0f;
        [SerializeField]
        private float gravity = 0.01f;

        private Vector2 cameraRotation = Vector2.zero;

        [SerializeField]
        private float lookSpeed = 3;

        private Vector3 moveDirection = Vector3.zero;
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (characterController.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
                else
                {
                }
            }

            Look();
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);

        }

        private void Look()
        {
            cameraRotation.y += Input.GetAxis("Mouse X");
            cameraRotation.x += -Input.GetAxis("Mouse Y");
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, -15f, 15f);
            transform.eulerAngles = new Vector2(0f, cameraRotation.y) * lookSpeed;
            Camera.main.transform.localRotation = Quaternion.Euler(cameraRotation.x * lookSpeed, 0, 0);
        }


    }
}