using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    [SerializeField] Transform rayOrigin;
    public float Distance = 20;
    public Wall CurrentSelectable;
    public LayerMask layerMask;

    void Update()
    {

        Ray ray = new Ray(rayOrigin.transform.position, transform.forward);
        ////ray.origin = rayOrigin.transform.position;
        ////ray.direction = transform.forward;

        Debug.DrawRay(rayOrigin.transform.position, transform.forward * 20f, Color.yellow);
        RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, Distance, layerMask))
        if (Physics.Raycast(ray, out hit, Distance, layerMask))
        {
           Wall selectable = hit.collider.gameObject.GetComponent<Wall>();

            if (selectable)
            {
                if (CurrentSelectable && CurrentSelectable != selectable)
                {
                    CurrentSelectable.White();
                }
                CurrentSelectable = selectable;
                selectable.Green();
                
            }
            else
            {
                if (CurrentSelectable)
                {
                    CurrentSelectable.White();
                    CurrentSelectable = null;
                }
            }
        }
        else
        {
            if (CurrentSelectable)
            {
                CurrentSelectable.White();
                CurrentSelectable = null;
            }
        }


        //if (Physics.Raycast(ray, out hit))
        //{
        //    Pointer.position = hit.point;
        //}
        //if (GetComponent<Collider>().Raycast(ray, out hit, 20f))
        //{
        //    //прописать, что должно произойти при соприкосновении с лучом
        //}
    }
}
