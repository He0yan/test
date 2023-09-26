using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float distance = 10.0f;//目标物体与摄像机之间在世界坐标基础上保持水平上的距离
    public float height = 5.0f;//摄像机与目标物体之间的高度差
    public float heightDamping = 2.0f;//高度变化阻尼
    public float rotationDamping = 3.0f;//旋转变化阻尼
    public float offsetHeight = 1.0f;//在摄像机采用lookAt（）方法时让他关注的坐标向上偏移1个单位
    Transform selfTransform;//定义一个对自身的引用

    public Transform Target;//目标物体引用

    // Start is called before the first frame update
    void Start()
    {
        selfTransform = GetComponent<Transform>();//获得自身的组件信息
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target)
            return;//安全保护

        float wantedRotationAngle = Target.eulerAngles.y;//目标物体的角度
        float wantedHeight = Target.position.y + height;//目标物体的高度

        float currentRotationAngle = selfTransform.eulerAngles.y;//当前摄像机的角度
        float currentHeight = selfTransform.position.y;//当前摄像机的高度

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);//执行每一帧时为达到平滑变化的目的，采用线性插值方法每次变化一点

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);//如上

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);//因为旋转角的变化不好用具体的变化角度表示，而四元数刚好可以表示角度绕哪个轴旋转多少度，表示角度的变化值

        selfTransform.position = Target.position;//这一步是整个跟随算法核心的步骤，目的是将目标物体的世界坐标位置付给摄像机，如此摄像机的位置就和目标位置重叠，此时只需要根据上面存储的摄像机的位置信息，恢复摄像机的应有位置即可。再次注意，此处改变只是世界坐标的position改变，并没有涉及摄像机自身的镜头朝向，及旋转。所以说可以利用上面记录的旋转角的变化量（四元数）来处理摄像机的变化。
        selfTransform.position -= currentRotation * Vector3.forward * distance;//摄像机此时的位置参数减去角度变化的四元数乘以水平偏移量的积，如此就可以得出摄像机在目标物体后方的位置及状态。

        Vector3 currentPosition = transform.position;//把上面已变化一部分的摄像机位置信息暂存下来
        currentPosition.y = currentHeight;//改变高度
        selfTransform.position = currentPosition;//改变过的信息给摄像机

        selfTransform.LookAt(Target.position + new Vector3(0, offsetHeight, 0));//使摄像机关注目标物体的坐标中心且是用摄像机的本地坐标，另外需要注意的是，摄像机关注的是物
    }
}
