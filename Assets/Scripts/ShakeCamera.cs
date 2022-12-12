using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    //��Ŭ�� ó���� ���� instance ���� ����
    public static ShakeCamera instance;

    //�ܺο��� Get ���ٸ� �����ϵ��� Instance ������Ƽ ����
    public static ShakeCamera Instance => instance;

    private float shakeTime;
    private float shakeIntensity;

    public new Camera camera;

    bool isChange = false;

    //Main Camera ������Ʈ�� ������Ʈ�� �����ϸ�
    //������ ������ �� �޸� �Ҵ� / ������ �޼ҵ� ����
    //�� �� �ڱ� �ڽ��� ������ instance ������ ����

    public ShakeCamera()
    {
        instance = this;
    }


    ///<param name=" shakeTime">
    ///<param name=" shakeIntensity">
    public void OnShakeCamera(float shakeTime = 0.1f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");

        StartCoroutine("ChangeBackGroundColor");
    }

    IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
            isChange = true;
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;


            shakeTime -= Time.deltaTime;
            

            yield return null;
        }

        transform.position = startPosition;
    }


    IEnumerator ChangeBackGroundColor()
    {
        while (isChange)
        {
            isChange = false;
            camera.backgroundColor = new Color32(255, 0, 0, 255);

            yield return null;
        }
       camera.backgroundColor = new Color32(213, 255, 255, 0);
    }
}
