using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask planeMask;
    [SerializeField] float speed=1;
    [SerializeField] MusicController musicController;
    void Start()
    {
        
    }
    Vector3 startPosition; //������� ��������� �������� (������� ������)
    Vector3 endPosition; //������� �����, �� ������� ��������� ��������
    // Update is called once per frame
    void Update()
    {
        
        
        //���� �� ������ �� ����� ������ �����
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, planeMask))
            {
                //�������� ������� �������, � ������� ���������� ���, ������� ������� - ������� �������, �� ������� ������� ������
                Vector3 point = raycastHit.point;
                startPosition = point;

                lineRenderer.SetPosition(0, point); //������ ���������� ������� ����� ��������
            }
            lineRenderer.gameObject.SetActive(true);
            //lineRenderer.SetPosition(0, transform.position);
            //startPosition = transform.position;
        }
        //����� ������ ������� ����� ������ ����� (����������� ��������)
        if (Input.GetMouseButton(0))
        {

            // lineRenderer.SetPosition(1, null);
            //           endPosition = transform.position;

            //���������� ��� �� ������� � �������� ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //���� ������, � ������� ���������� ���������� ���
            //Mathf.Infinity ��������, ��� ����� ���� ����� �����������
            //out RaycastHit raycastHit - ������� ����������, � ������� ��������� ���������� � ������� �������, � ������� ���������� ���
            //����� ���������� true, ���� ������� ������������
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, planeMask))
            {
                //�������� ������� �������, � ������� ���������� ���, ������� ������� - ������� �������, �� ������� ������� ������
                Vector3 point = raycastHit.point;
                endPosition = point;
                
                lineRenderer.SetPosition(1, point); //������ ���������� ������� ����� ��������
            }
        }
        //����� ��������� ������ (��������)
        if (Input.GetMouseButtonUp(0))
        {
            //����� ��������� ������ �����, �������� ��������
            lineRenderer.gameObject.SetActive(false);
            endPosition.y = 0;
            startPosition.y = 0;
            Debug.Log(endPosition + " " + startPosition);
            gameObject.GetComponent<Rigidbody>().AddForce((startPosition- endPosition) *speed, ForceMode.Impulse);
            musicController.PlayHit();
        }


        
    }


}
