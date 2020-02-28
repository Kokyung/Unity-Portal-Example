using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_Interact_A : MonoBehaviour
{
    public GameObject Portal_A;
    public GameObject Portal_B;
    public GameObject Portal_B_2;
    public GameObject Portal_C;



    public Animation Click_Animation;

    private bool clicked = false;
    private bool portalActivated = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Activate_Portal_by_Message()
    {
        if (Click_Animation.IsPlaying("fade_out")||Click_Animation.IsPlaying("fade_in")) return;
        else
        {
            if (clicked)
            {
                Click_Animation.Play("fade_in");
                clicked = false;
            }
            else
            {
                Click_Animation.Play("fade_out");
                clicked = true;

                if (portalActivated == true) return;
                else
                {
                    Portal_A.SetActive(false);
                    Portal_B.SetActive(false);
                    Portal_B_2.SetActive(true);
                    Portal_C.SetActive(true);

                    portalActivated = true;
                }
            }
        }
    }
}
