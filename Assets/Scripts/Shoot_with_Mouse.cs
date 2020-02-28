using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_with_Mouse : MonoBehaviour
{
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))// 발사 버튼(마우스 왼쪽 버튼)이 클릭 되면
        {
            Interact();// 상호작용 메서드 호출
        }
    }
    
    void Interact()// Raycast를 이용한 상호작용
    {
        RaycastHit hit;// 충돌 기록
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range)){// 카메라 방향의 앞쪽(forward)으로 range만큼 거리에서 충돌 처리가 될 경우 
            OpenPortal open_portal = hit.transform.GetComponent<OpenPortal>();// 충돌된 오브젝트의 Button_Color_Change 클래스를 참조
            Message_Interact_A message_Interact_A = hit.transform.GetComponent<Message_Interact_A>();
            if (open_portal != null) open_portal.Activate_Portal();// Button_Color_Change 클래스 내에 change_color 메서드 호출
            if (message_Interact_A != null) message_Interact_A.Activate_Portal_by_Message();
        }
    }
}
