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
    Vector3 startPosition; //позици€ креплени€ пружинки (позици€ м€чика)
    Vector3 endPosition; //позици€ точки, до которой раст€нули пружинку
    // Update is called once per frame
    void Update()
    {
        
        
        //если мы нажали на левую кнопку мышки
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, planeMask))
            {
                //получаем позицию объекта, с котором столкнулс€ луч, другими словами - позицию объекта, на который наведен курсор
                Vector3 point = raycastHit.point;
                startPosition = point;

                lineRenderer.SetPosition(0, point); //задаем координаты второму концу пружинки
            }
            lineRenderer.gameObject.SetActive(true);
            //lineRenderer.SetPosition(0, transform.position);
            //startPosition = transform.position;
        }
        //когда держим зажатую левую кнопку мышки (раст€гиваем пружинку)
        if (Input.GetMouseButton(0))
        {

            // lineRenderer.SetPosition(1, null);
            //           endPosition = transform.position;

            //выпкускаем луч от курсора к игровому миру
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //»щем объект, с которым столкнулс€ выпущенный луч
            //Mathf.Infinity означает, что длина луча будет бесконечной
            //out RaycastHit raycastHit - создаем переменную, в которую запишетс€ информаци€ о позиции объекта, с которым столкнулс€ луч
            //метод возвращает true, если нашлось столкновение
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, planeMask))
            {
                //получаем позицию объекта, с котором столкнулс€ луч, другими словами - позицию объекта, на который наведен курсор
                Vector3 point = raycastHit.point;
                endPosition = point;
                
                lineRenderer.SetPosition(1, point); //задаем координаты второму концу пружинки
            }
        }
        //когда отпустили кнопку (пружинку)
        if (Input.GetMouseButtonUp(0))
        {
            //когда отпускаем кнопку мышки, скрываем пружинку
            lineRenderer.gameObject.SetActive(false);
            endPosition.y = 0;
            startPosition.y = 0;
            Debug.Log(endPosition + " " + startPosition);
            gameObject.GetComponent<Rigidbody>().AddForce((startPosition- endPosition) *speed, ForceMode.Impulse);
            musicController.PlayHit();
        }


        
    }


}
