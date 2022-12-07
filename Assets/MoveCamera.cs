using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    private Transform tr;

    public GameObject character;
    public float offsetX = 0.0f;
    public float offsetY = 11.0f;
    public float offsetZ = -6.0f;
    public float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�
    Vector3 TargetPos;                      // Ÿ���� ��ġ

    

    // Update is called once per frame
    void FixedUpdate()
    {
        // character = GameObject.Find("Character").transform.GetChild(0).gameObject;
        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            character.transform.position.x + offsetX,
            character.transform.position.y + offsetY,
            character.transform.position.z + offsetZ
            );
        if(TargetPos.x >= 2.25)
        {
            TargetPos.x = 2.25f;
        }else if (TargetPos.x <= 1.0f)
        {
            TargetPos.x = 1.0f;
        }
        //Debug.Log(TargetPos + "ī�޶� ��ġ");
        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Slerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
    // Start is called before the first frame update
    void Start()
    {
        // ���� �ű�
        character = GameObject.Find("Character").transform.GetChild(0).gameObject;

        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //tr.position = new Vector3(target.position.x - 0.52f, tr.position.y, target.position.z - 6.56f);

        //tr.LookAt(target);
    }
}
