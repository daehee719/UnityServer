using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int PlayerId { get; set; }
    public string PlayerChat { get; set; }

    public TMP_Text _chatText;

    protected float moveForce = 7.0f;
    protected float x_Axis;
    protected float z_Axis;
    public virtual void Start()
    {
        _chatText = transform.Find("Canvas").Find("Image").Find("Text").GetComponent<TMP_Text>();
        _chatText.text = "";
    }


    void Update()
    {
        SetChat();
    }

    protected virtual void SetChat()
    {
        if(PlayerChat != null)
            _chatText.text = PlayerChat;
    }


    
}
