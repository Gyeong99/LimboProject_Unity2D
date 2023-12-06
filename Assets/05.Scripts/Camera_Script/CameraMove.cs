using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    private Vector2 CameraPos;
    private Transform tr;
    public float dampTrace = 20.0f;
    public float cameraHeight = -10.0f;
    public Transform targetObject;
    public GameObject mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        mainCharacter = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //tr.position = Vector3.Lerp(tr.position, targetObject.position + (Vector3.forward * cameraHeight), Time.deltaTime * dampTrace);

        
        if (mainCharacter.GetComponent<CharacterController2D>().GetGroundedBool() || mainCharacter.GetComponent<CharacterController2D>().GetSideGroundedBool())
        {
            tr.position = Vector3.Lerp(tr.position, targetObject.position + (Vector3.forward * cameraHeight), Time.deltaTime * dampTrace);
            //tr.position = new Vector3(Mathf.Lerp(tr.position.x, targetObject.position.x, 0.05f), tr.position.y, tr.position.z);
            //tr.position = new Vector3(Mathf.Lerp(tr.position.y, targetObject.position.y, 0.05f) , tr.position.y , tr.position.z);
        }
        else
        {
            tr.position = new Vector3(Mathf.Lerp(tr.position.x, targetObject.position.x, 0.5f), tr.position.y, tr.position.z);
        }
        
        
    }
}
