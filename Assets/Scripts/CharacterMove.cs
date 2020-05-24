using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public int characterSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {

            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

            if (hit.collider != null && hit.collider.gameObject != this.gameObject)
            {
                Vector3 vec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, hit.distance);
                Vector3 targetVec = Camera.main.ScreenToWorldPoint(vec);
                transform.position += ((targetVec - transform.position).normalized * Time.deltaTime * characterSpeed);

                Vector3 lookAtVec = new Vector3(targetVec.x, transform.position.y, targetVec.z);
                transform.LookAt(lookAtVec);
            }
        }
    }
}
