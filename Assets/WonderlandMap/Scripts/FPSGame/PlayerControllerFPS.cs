using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFPS : MonoBehaviour
{

    private RotateToMouseFPS rotateToMouse;//���콺 �̵����� ī�޶�ȸ��
    private PistolFire weapon;

    private void Awake()
    {
        //���콺 Ŀ�� invisible, ��ġ����
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotateToMouse = GetComponent<RotateToMouseFPS>();
        weapon = GetComponentInChildren<PistolFire>();
    }

    private void Update()
    {
        UpdateRotate();
        UpdateWeaponAction();
    }

    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);


    }

    private void UpdateWeaponAction()
    {
        if (Input.GetMouseButtonDown(0))
        { weapon.StartWeaponAction(); }
        else if (Input.GetMouseButtonUp(0))
        { weapon.StopWeaponAction(); }
    }
}
