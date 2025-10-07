using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
	//플레이어 상태
	public enum EState
	{
		None,
		Idle,
		Move,
	}

	//트레이에 쌓은 오브젝트 종류
	public enum ETrayObject
	{
		None,
		Trash,
		Burger,
	}

	//손님 상태
	public enum EGuestState
	{
		None,
		Queuing,
		Serving,
		Eating,
		Leaving,
	}

	//테이블 상태
	public enum ETableState
	{
		None,
		Reserved,
		Eating,
		Dirty,
	}

	// TEMP, 차후 고칠 수 있는 수치 변수 모음
	public const float GRILL_SPAWN_BURGER_INTERVAL = 0.5f;
	public const int GRILL_MAX_BURGER_COUNT = 20;

	public const float MONEY_SPAWN_INTERVAL = 0.1f;
	public const float TRASH_SPAWN_INTERVAL = 0.1f;
	public const float GUEST_SPAWN_INTERVAL = 1f;
	public const int GUEST_MAX_ORDER_BURGER_COUNT = 2;

	public static Vector3 GUEST_LEAVE_POS = new Vector3(0, 0, 0);

	public static int IDLE = Animator.StringToHash("Idle");
	public static int MOVE = Animator.StringToHash("Move");
	public static int SERVING_IDLE = Animator.StringToHash("ServingIdle");
	public static int SERVING_MOVE = Animator.StringToHash("ServingMove");
	public static int EATING = Animator.StringToHash("Eating");
}