using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{

    public Renderer RenderPlane_A;
    public Renderer RenderPlane_B;

    public BoxCollider ColliderPlane_A;
    public BoxCollider ColliderPlane_B;

    public BoxCollider ColliderReset_A;
    public BoxCollider ColliderReset_B;

    public Animation Click_Animation;

    // Start is called before the first frame update
    void Start()
    {
        RenderPlane_A.enabled = false;
        RenderPlane_B.enabled = false;
        ColliderPlane_A.enabled = false;
        ColliderPlane_B.enabled = false;
        ColliderReset_A.enabled = false;
        ColliderReset_B.enabled = false;
    }

    // Update is called once per frame
    public void Activate_Portal()
    {
        if (Click_Animation.IsPlaying("Button_Click")) return;
        else Click_Animation.Play("Button_Click");

        RenderPlane_A.enabled = !RenderPlane_A.enabled;
        RenderPlane_B.enabled = !RenderPlane_B.enabled;
        ColliderPlane_A.enabled = !ColliderPlane_A.enabled;
        ColliderPlane_B.enabled = !ColliderPlane_B.enabled;
        ColliderReset_A.enabled = !ColliderReset_A.enabled;
        ColliderReset_B.enabled = !ColliderReset_B.enabled;
    }
}
