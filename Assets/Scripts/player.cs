using UnityEngine;
using UnityEngine.InputSystem; // 새로운 입력 기능(New Input System)을 사용하기 위해 가져오는 도구함입니다!

public class player : MonoBehaviour
{
    // Inspector에서 쉽게 값을 수정할 수 있게 해주는 마법 같은 명령어입니다!
    [SerializeField] 
    private float jumpPower = 7f;

    // 플레이어의 물리(중력, 떨어짐 등)를 담당하는 부품(컴포넌트)을 저장할 공간입니다.
    private Rigidbody2D rigid;

    // 우리가 지금 바닥에 서 있는지, 아니면 공중에 떠 있는지 기억해 두는 '스위치' 같은 변수입니다.
    private bool isGrounded = true;

    // 게임이 시작될 때 딱 한 번 실행되는 곳입니다.
    void Start()
    {
        // 이 스크립트가 붙어있는 오브젝트의 Rigidbody2D 부품을 찾아 rigid 변수에 넣습니다.
        rigid = GetComponent<Rigidbody2D>();
    }

    // 게임이 실행되는 동안 매 프레임(1초에 수십 번씩) 빠르게 계속 실행되는 곳입니다.
    void Update()
    {
        // 바닥에 닿아있는 상태이고(isGrounded == true), 동시에(&&) 스페이스바가 방금 눌렸다면!
        if (isGrounded && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // 기존의 X(가로) 속도는 유지하고, Y(세로) 속도를 우리가 정한 jumpPower로 바꿔줍니다! 위로 뿅 점프하게 됩니다.
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, jumpPower);
        }
    }

    // 플레이어의 몸통이 무언가(주로 바닥)와 '처음 부딪혀 닿았을 때' 유니티가 알아서 실행해주는 곳입니다.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 안전하게 착지했으므로, 다시 점프를 할 수 있게 스위치를 켭니다(true).
        isGrounded = true;
    }

    // 플레이어의 몸통이 맞닿아 있던 곳에서 '완전히 떨어졌을 때' 유니티가 알아서 실행해주는 곳입니다.
    void OnCollisionExit2D(Collision2D collision)
    {
        // 발이 땅에서 떨어졌으므로, 허공에서 다시 뛰지 못하게 스위치를 끕니다(false).
        isGrounded = false;
    }
}
