using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject[] patterns;      //���� ����
    [SerializeField]
    private GameObject hpPotion;        //ü��ȸ�� ������Ʈ
    private GameObject currentPattern;  //���� ��� ����
    private int[] patternIndexs;        //��ġ�� �ʴ� pattern.Length
    private int current = 0;            //patternIndexs �迭�� ����

    private void Awake()
    {
        //�����ϰ� �ִ� ���� ������ �����ϰ� �޸� �Ҵ�
        patternIndexs = new int[patterns.Length];

        //ó������ ������ ���������� �����ϵ��� ����
        for(int i = 0; i < patternIndexs.Length; i++)
        {
            patternIndexs[i] = i;
        }
    }

    private void Update()
    {
        if (gameController.IsGamePlay == false) return;

        //���� ������� ������ ����Ǿ� ������Ʈ�� ��Ȱ��ȭ�Ǹ�
        if(currentPattern.activeSelf == false)
        {
            //�������Ͻ���
            ChangePattern();
        }
    }

    public void GameStart()
    {
        ChangePattern();
    }

    public void GameOver()
    {
        //���� ������� ���ϸ� ��Ȱ��ȭ
        currentPattern.SetActive(false);
    }

    public void ChangePattern()
    {
        //���� ���� ����
        currentPattern = patterns[patternIndexs[current]];

        //���� ���� Ȱ��ȭ
        currentPattern.SetActive(true);

        current++;

        //4���� ������ Ŭ���������� ü��ȸ������ ����
        if(current == 4)
        {
            hpPotion.SetActive(true);
        }

        //������ �ѹ��� ��� �����ߴٸ� ���ϼ����� ��ġ�� �ʴ� ������ ���ڷ� ����
        if(current >= patternIndexs.Length)
        {
            patternIndexs = Utils.RandomNumbers(patternIndexs.Length, patternIndexs.Length);
            current = 0;

        }
    }


}
