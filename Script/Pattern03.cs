using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyFollow;   
    [SerializeField]
    private GameObject warningImage;
    [SerializeField]
    private Transform target;         //플레이어
    [SerializeField]
    private float liveCycle = 5f;        //생명주기

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }
    private void OnDisable()
    {        
        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        // 패턴 시작 전 잠시 대기하는 시간
        yield return new WaitForSeconds(1);

        

        // 플레이어 오브젝트 생성
        StartCoroutine(nameof(Follow));
        yield return new WaitForSeconds(liveCycle);



        // 패턴 오브젝트 비활성화
        gameObject.SetActive(false);
       
    }
    private IEnumerator Follow()
    {

        GameObject warningClone = Instantiate(warningImage, target.position, Quaternion.identity);
        warningClone.transform.localScale = new Vector3(2, 2, 0);

        yield return new WaitForSeconds(0.5f);

        GameObject enemyClone = Instantiate(enemyFollow, warningClone.transform.position, Quaternion.identity);
        Destroy(warningClone);
        Destroy(enemyClone, liveCycle);


    }

}
