using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern05 : MonoBehaviour
{
    [SerializeField]
    private MovementTransform2D boss;
    [SerializeField]
    private GameObject bossbullet;
    [SerializeField]
    private float attackRate = 1;
    [SerializeField]
    private int maxFireCount = 5;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        boss.GetComponent<MovingEntity>().Reset();

        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        //���� ���� �� ���ð�
        yield return new WaitForSeconds(1f);

        //������ �Ʒ��� �̵�
        yield return StartCoroutine(nameof(MoveDown));
        //���� �¿��̵�
        StartCoroutine(nameof(MoveLeftAndRight));
        //���� ����
        int count = 0;
        while(count < maxFireCount)
        {
            CircleFire();

            count++;

            yield return new WaitForSeconds(attackRate);
        }

        //���� ������Ʈ ��Ȱ��ȭ
        boss.gameObject.SetActive(false);

        //���� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
    private IEnumerator MoveDown()
    {
        //��ǥ ��ġ
        float bossDestinationY = 2;

        //���� ������Ʈ Ȱ��ȭ
        boss.gameObject.SetActive(true);

        //������ ��ǥ���� �̵��ߴ��� �˻�
        while(true)
        {
            if(boss.transform.position.y <= bossDestinationY)
            {
                boss.MoveTo(Vector3.zero);

                yield break;
            }

            yield return null;
        }
    }
    private IEnumerator MoveLeftAndRight()
    {
        //���� ������Ʈ�� �� �ٱ����� �̵����� �ʵ����ϴ� ����ġ��
        float xWeight = 3;

        //ó�� �̵� ������ ���������� ����
        boss.MoveTo(Vector3.right);

        while(true)
        {
            //������ ��ġ�� ���� �ּ� ������ �Ѿ�� �̵� ������ ���������� ����
            if(boss.transform.position.x <= Constants.min.x + xWeight)
            {
                boss.MoveTo(Vector3.right);
            }
            //������ ��ġ�� ������ �ִ� ������ �Ѿ�� �̵������� �������� ����
            else if( boss.transform.position.x >= Constants.max.x - xWeight)
            {
                boss.MoveTo(Vector3.left);
            }

            yield return null;
        }
    }
    private void CircleFire()
    {
        int count = 30;                     //�߻�ü ���� ����
        float intervalAngle = 360 / count;  //�߻�ü ������ ����

        //�� ���·� ����ϴ� �߻�ü ����
        for(int i = 0; i < count; ++i)
        {
            //�߻�ü ���� 
            GameObject clone = Instantiate(bossbullet, boss.transform.position, Quaternion.identity);

            //�߻�ü �̵�����
            float angle = intervalAngle * i;
            //�߻�ü �̵����� (����)
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
            //�߻�ü �̵����� ����
            clone.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x, y));

        }
    }
}
