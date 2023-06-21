using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouseFPS : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxisSpeed = 5;//x
    [SerializeField]
    private float rotCamYAxisSpeed = 3;//y

    private float limitMaxX = 50; // x축 최대범위
    private float limitMinX = -80; // x축 최소범위
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed;//좌우 카메라y축 회전
        eulerAngleX -= mouseY * rotCamXAxisSpeed;//상하 카메라x축 회전

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY,0);
    }

    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) { angle += 360; }
        if (angle > 360) { angle -= 360; }

        return Mathf.Clamp(angle, min, max);

    }
}
