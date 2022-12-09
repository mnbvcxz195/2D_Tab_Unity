using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    //싱클톤 처리를 위한 instance 변수 선언
    public static ShakeCamera instance;

    //외부에서 Get 접근만 가능하도록 Instance 프로퍼티 선언
    public static ShakeCamera Instance => instance;

    private float shakeTime;
    private float shakeIntensity;

    //Main Camera 오브젝트에 컴포넌트로 적용하면
    //게임을 실행할 때 메모리 할당 / 생성자 메소드 실행
    //이 때 자기 자신의 정보를 instance 변수에 저장

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
