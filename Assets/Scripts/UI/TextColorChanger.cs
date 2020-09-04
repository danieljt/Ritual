using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
/// Change the text of a UI text component when selecting, deselecting, pressing or disabled
/// 
///</summary>
public class TextColorChanger : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        
    }
}
