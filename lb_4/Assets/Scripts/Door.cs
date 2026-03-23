using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform posOpen;
    public Transform posDefault;
    bool open = false;
    bool button1 = false;
    bool button2 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OpenDoor()
    {
        if(!open)
        {
            transform.position = posOpen.transform.position;
            transform.rotation = posOpen.transform.rotation;
            open = true;
            Invoke("CloseDoor", 10f);
        }
    }

    // Update is called once per frame
    public void CloseDoor()
    {
        if(open)
        {
            transform.position = posDefault.transform.position;
            transform.rotation = posDefault.transform.rotation;
            open = false;
        }
    }

    public void ActivateButton1()
    {
        button1 = true;
        if(button2)
        {
            OpenDoor();
        }
    }

    public void ActivateButton2()
    {   
        button2 = true;
        if(button1)
        {
            OpenDoor();
        }
    }

    public void DeactivateButton1() => button1 = false;

    public void DeactivateButton2() => button2 = false;
}
