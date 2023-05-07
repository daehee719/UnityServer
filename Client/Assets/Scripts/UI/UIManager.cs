using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    NetworkManager _network;

    [SerializeField]
    private Button _sendBtn;
    [SerializeField]
    private TMP_InputField _chatField;

    public TMP_Text _chatText;

    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
        _network = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        _sendBtn.onClick.AddListener(Send);
        GameObject obj = (GameObject)Resources.Load("Player");
        _chatText = obj.GetComponentInChildren<TMP_Text>();
    }

    // º¸³»±â.
    void Send()
    {
        if(_chatField.text.Length > 0)
        {
            C_Chat chat = new C_Chat();
            chat.chatTxt = _chatField.text;
            
            _network.Send(chat.Write());
        }
        _chatField.text = "";
    }
}
