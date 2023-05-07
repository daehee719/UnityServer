using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyPlayer : Player
{
	NetworkManager _network;

    public float moveSpeed = 10f; // 이동 속도
    public Rigidbody rb; // RigidBody 컴포넌트

    private Vector3 movement; // 플레이어가 움직일 방향

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        StartCoroutine("CoSendPacket");
		_network = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		C_Move movePacket = new C_Move();
		movePacket.posX = Random.Range(-50, 50);
		movePacket.posY = 0f;
		movePacket.posZ = Random.Range(-50, 50);
		_network.Send(movePacket.Write());
    }

    void Update()
    {
        Debug.Log(_chatText);
        // SetChat();
		//  if(PlayerChat.Length > 0)
        _chatText.text = PlayerChat;
    }
    void FixedUpdate()
    {
        // RigidBody2D를 이용한 이동 처리
        Move();
    }


    //0.02초마다 서버에 위치값 보냄
    IEnumerator CoSendPacket()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.02f);
			//클라 패킷 만들고, 전송
			C_Move movePacket = new C_Move();
			movePacket.posX = transform.position.x;
			movePacket.posY = transform.position.y;
			movePacket.posZ = transform.position.z;
			_network.Send(movePacket.Write());
		}
	}

    
    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
