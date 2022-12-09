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
    }

    private IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {

            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;


            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
    }
}
