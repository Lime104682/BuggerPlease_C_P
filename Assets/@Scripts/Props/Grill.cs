using System.Collections;
using UnityEngine;

// 1. 패티 에니메이션 (OK)
// 2. 햄버거 주기적으로 생성 (OK)
// 3. [Collider] 길찾기 막기 (OK)
// 4. Burger Pile (OK)
// 5. [Trigger] 햄버거 영역 안으로 들어오면, 플레이어가 갖고감.
public class Grill : MonoBehaviour
{
	//버거 쌓기
	private BurgerPile _burgers;

	void Start()
	{
        //자식 오브젝트들 중에서 첫번째로 발견한 BurgerPile 컴포넌트를 할당
        _burgers = Utils.FindChild<BurgerPile>(gameObject);

		// 햄버거 인터랙션.
		PlayerInteraction interaction = _burgers.GetComponent<PlayerInteraction>();
		interaction.InteractInterval = 0.2f;
		interaction.OnPlayerInteraction = OnPlayerBurgerInteraction;

		// 햄버거 스폰.
		StartCoroutine(CoSpawnBurgers());
	}

	IEnumerator CoSpawnBurgers()
	{
		while (true)
		{
			yield return new WaitUntil(() => _burgers.ObjectCount < Define.GRILL_MAX_BURGER_COUNT);

			GameObject go = GameManager.Instance.SpawnBurger();
			_burgers.AddToPile(go);
            /*
			 * _burgers.AddToPile(go); 코드 없다면
			 * -> BurgerRoot 오브젝트의 위치에서 혹은 0.0.0에서 혹은 Burger 프리팹의 원본 Transform위치값에서 생성됨을 확인  
			 */

            yield return new WaitForSeconds(Define.GRILL_SPAWN_BURGER_INTERVAL);
		}
	}

	void OnPlayerBurgerInteraction(PlayerController pc)
	{
		// 쓰레기 운반 상태에선 안 됨.
		if (pc.Tray.CurrentTrayObject == Define.ETrayObject.Trash)
			return;

        //버거를 RemoveFromPile해서 가져오고
        GameObject go = _burgers.RemoveFromPile();
		if (go == null)
			return;

		//그거를 플레이어의 트레이에 쌓는다
		pc.Tray.AddToTray(go.transform);
	}
}
