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
    private Transform target;         //�÷��̾�
    [SerializeField]
    private float liveCycle = 5f;        //�����ֱ�

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
        // ���� ���� �� ��� ����ϴ� �ð�
        yield return new WaitForSeconds(1);

        

        // �÷��̾� ������Ʈ ����
        StartCoroutine(nameof(Follow));
        yield return new WaitForSeconds(liveCycle);



        // ���� ������Ʈ ��Ȱ��ȭ
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
