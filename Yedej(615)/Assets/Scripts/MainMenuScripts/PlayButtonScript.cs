using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayButtonScript : MonoBehaviour
{
    public TMP_Text title;
    public void OnMouseOver()
    {
        title.color = Color.grey;
    }
    
}
