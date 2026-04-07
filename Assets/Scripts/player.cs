using UnityEngine;
using UnityEngine.InputSystem; // 새로운 입력 기능(New Input System)을 사용하기 위해 가져오는 도구함입니다!

public class player : MonoBehaviour
{
    // Inspector에서 쉽게 값을 수정할 수 있게 해주는 마법 같은 명령어입니다!
    [SerializeField] 
    private float jumpPower = 7f;

    // 플레이어의 물리(중력, 떨어짐 등)를 담당하는 부품(컴포넌트)을 저장할 공간입니다.
    private Rigidbody2D rigid;

    // 게임이 시작될 때 딱 한 번 실행되는 곳입니다.
    void Start()
    {
        // 이 스크립트가 붙어있는 오브젝트의 Rigidbody2D 부품을 찾아 rigid 변수에 넣습니다.
        rigid = GetComponent<Rigidbody2D>();
    }

    // 게임이 실행되는 동안 매 프레임(1초에 수십 번씩) 빠르게 계속 실행되는 곳입니다.
    void Update()
    {
        // 최신 입력 방식: 현재 연결된 키보드가 있고(null이 아님), 스페이스바가 방금 눌렸다면!
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // 기존의 X(가로) 속도는 유지하고, Y(세로) 속도를 우리가 정한 jumpPower로 바꿔줍니다! 위로 뿅 점프하게 됩니다.
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, jumpPower);
        }
    }
}
