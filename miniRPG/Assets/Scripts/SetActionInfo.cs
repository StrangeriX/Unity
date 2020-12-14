using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActionInfo : MonoBehaviour
{
    public Text textinfo;
    public void SetInfo(Text info)
    {
        textinfo.GetComponent<Text>().text = "info";
    }
}
