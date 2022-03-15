using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopUp : MonoBehaviour
{
    // Start is called before the first frame update
   virtual public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
