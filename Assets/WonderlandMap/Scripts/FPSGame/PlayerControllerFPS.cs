using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFPS : MonoBehaviour
{

    private RotateToMouseFPS rotateToMouse;//마우스 이동으로 카메라회전
    private PistolFire weapon;

    private void Awake()
    {
        //마우스 커서 invisible, 위치고정
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
