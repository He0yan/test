using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float distance = 10.0f;//Ŀ�������������֮����������������ϱ���ˮƽ�ϵľ���
    public float height = 5.0f;//�������Ŀ������֮��ĸ߶Ȳ�
    public float heightDamping = 2.0f;//�߶ȱ仯����
    public float rotationDamping = 3.0f;//��ת�仯����
    public float offsetHeight = 1.0f;//�����������lookAt��������ʱ������ע����������ƫ��1����λ
    Transform selfTransform;//����һ�������������

    public Transform Target;//Ŀ����������

    // Start is called before the first frame update
    void Start()
    {
        selfTransform = GetComponent<Transform>();//�������������Ϣ
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target)
            return;//��ȫ����

        float wantedRotationAngle = Target.eulerAngles.y;//Ŀ������ĽǶ�
        float wantedHeight = Target.position.y + height;//Ŀ������ĸ߶�

        float currentRotationAngle = selfTransform.eulerAngles.y;//��ǰ������ĽǶ�
        float currentHeight = selfTransform.position.y;//��ǰ������ĸ߶�

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);//ִ��ÿһ֡ʱΪ�ﵽƽ���仯��Ŀ�ģ��������Բ�ֵ����ÿ�α仯һ��

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);//����

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);//��Ϊ��ת�ǵı仯�����þ���ı仯�Ƕȱ�ʾ������Ԫ���պÿ��Ա�ʾ�Ƕ����ĸ�����ת���ٶȣ���ʾ�Ƕȵı仯ֵ

        selfTransform.position = Target.position;//��һ�������������㷨���ĵĲ��裬Ŀ���ǽ�Ŀ���������������λ�ø��������������������λ�þͺ�Ŀ��λ���ص�����ʱֻ��Ҫ��������洢���������λ����Ϣ���ָ��������Ӧ��λ�ü��ɡ��ٴ�ע�⣬�˴��ı�ֻ�����������position�ı䣬��û���漰���������ľ�ͷ���򣬼���ת������˵�������������¼����ת�ǵı仯������Ԫ����������������ı仯��
        selfTransform.position -= currentRotation * Vector3.forward * distance;//�������ʱ��λ�ò�����ȥ�Ƕȱ仯����Ԫ������ˮƽƫ�����Ļ�����˾Ϳ��Եó��������Ŀ������󷽵�λ�ü�״̬��

        Vector3 currentPosition = transform.position;//�������ѱ仯һ���ֵ������λ����Ϣ�ݴ�����
        currentPosition.y = currentHeight;//�ı�߶�
        selfTransform.position = currentPosition;//�ı������Ϣ�������

        selfTransform.LookAt(Target.position + new Vector3(0, offsetHeight, 0));//ʹ�������עĿ���������������������������ı������꣬������Ҫע����ǣ��������ע������
    }
}
