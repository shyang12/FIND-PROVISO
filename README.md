# FIND PROVISO
## ▶ UNITY를 사용한 방탈출 게임 만들기 (3D)
 
 - Unity에서 C#을 기반으로 방탈출 게임을 구현하는 프로젝트
 - 장르 : 1인칭 3D 어드벤쳐, 퍼즐

`Stack` `Player Animation` `Vector` `Conflict React` `asset`

## 1. Co-Development Environment   
### 1. 1 Environments
- Windows 10
- Unity / C#
- Visual Studio
- GitHub

### 1. 2 Driving
- Window Desktop

### 1. 3 Implement
- 사다리가 끊겨 있는 부분이나 가는 길에 오브젝트가 있을 경우는 점프를 해서 지나가고, 낮은 지형지물이 있을 경우 앉아서 통과해야 한다. 만약 올라가는 과정 중 떨어지게 된다면 다시 올라야 한다.
- 비밀번호 시스템을 이용하여 문제를 풀어 정확한 답을 입력하면 문이 열리고 비밀번호 시스템은 버튼 하나마다 `OnClick`함수를 만들어 각 버튼에 함수를 적용하였다.
- 각 스테이지에 있는 표지판을 무심코 지나치면 플레이의 방향성을 잃을 수 있으므로 꼭 확인하여야 한다. 충돌 판정으로 가까이 가면 텍스트가 켜지도록 만들었다.
- 박스나 문 같은 오브젝트는 충돌 범위 안에 들어와야 활성화되어 열거나 이벤트를 수행할 수 있다.
- 단순히 비밀번호로만 방의 문을 여는 것에 그치지 않고 열쇠를 찾아 문을 여는 것과 단서를 풀고 키보드 키를 활용하여 레버를 돌릴 수 있고, 영어로 된 문제를 풀어 영어 입력을 할 수 있다.
- 특정 시간이 지나면 긴박함을 주기위해 타이머 색상을 RED로 변경해 주었다.
- 스택과 열거형을 활용하여 인벤토리 시스템을 만들었다. 아이템을 열거형으로 총 6개로 지정을 한 다음 소모품은 스택에서 pop이 되도록 하고 단서같은 경우는 클릭했을 때 UI가 보이도록, 다시 한번 더 클릭하면 UI가 비활성화되도록 만들었다.
- 각 오브젝트들이 플레이어와 상호작용을 할 때 효과음을 넣어 더욱 생동감있게 만들었다.
- 플레이어에 애니메이션을 입혀 걷을 때, 뛸 때, 가만히 있을 때 각각 수행하게 하여 더욱 생동감이 있게 만들었다.

## 2. Play
### 2. 1 Control
- 캐릭터의 이동은 `W, A, S, D` 키로로 각각의 키가 상, 좌, 하, 우에 대응된다.
- `I`키를 사용하여 인벤토리를 열고 닫을 수 있다.
- `Shift`키를 사용하여 달릴 수 있다.
- `Ctrl`키를 사용하여 앉고 설 수 있다.
- `SpaceBar`키를 사용하여 점프할 수 있다.
- 상황에 따라 키보드의 키를 사용하여 이벤트를 실행할 수 있다.
- `ESC`키를 두 번 연속 누르면 게임이 종료된다.
- 플레이어는 마우스 왼쪽을 클릭하여 상자를 열거나 아이템을 획득할 수 있다. 잠금 시스템이 있어 마우스 클릭으로 정답을 클릭하여 입력할 수 있다.

### 2. 1 Object Event Start

![겜 플레이](https://github.com/shyang12/FIND-PROVISO/assets/85710913/083d1c6c-e7e4-4e2e-aa52-0d0c8875d55c)

## 3. Rules
- New Game 버튼을 통해 게임을 시작하면 타이머가 작동한다. 타이머는 제작자가 임의로 시간을 변경할 수 있도록 만들었고, 중간에 게임을 종료 해도 저장이 되지 않아 처음부터 플레이를 다시 해야한다.
- 총 5개의 문, 4개의 스테이지를 게임 흐름에 맞게 플레이해야만 이 탑 꼭대기의 문을 열 수 있다.
- 소모품은 꼭 사용해야 한다.
- 제한 시간이 끝나면 게임오버가 된다.
- 무분별한 답을 적는 것을 방지하여 4자리 이상의 숫자와 영어로된 답도 추가하였다.

## 4. Conceptual drawing  

![구상도](https://github.com/shyang12/FIND-PROVISO/assets/85710913/0757711e-5508-47ac-adcb-d48ce7daf295)

## 5. Proviso

![단서 1](https://github.com/shyang12/FIND-PROVISO/assets/85710913/dadc9d1f-a6e3-4fa6-a5bb-32d17c1a7e55)  ![단서 2](https://github.com/shyang12/FIND-PROVISO/assets/85710913/b52718af-c17a-4c89-bf1d-fe8c28780838)

![단서 3](https://github.com/shyang12/FIND-PROVISO/assets/85710913/97f642a3-27ba-4805-861d-7e3a784d9a1d)  ![단서 4](https://github.com/shyang12/FIND-PROVISO/assets/85710913/2bfe93fa-1b79-40a4-85f9-7a773d5b0061)

![단서 5](https://github.com/shyang12/FIND-PROVISO/assets/85710913/1950fdea-5602-4793-a0ae-dd20be58e8fc)  ![마지막 단서](https://github.com/shyang12/FIND-PROVISO/assets/85710913/b1f24904-9cc1-406c-9edf-354edc69745f)

## 6. Result
### 6.1 Start

![게임 시작](https://github.com/shyang12/FIND-PROVISO/assets/85710913/111608da-db97-43c1-8563-7b8ebc63209d)  ![스토리](https://github.com/shyang12/FIND-PROVISO/assets/85710913/8df570e2-5f99-4968-b62a-ba701169026d)

### 6.2 UI

![게임 화면 1](https://github.com/shyang12/FIND-PROVISO/assets/85710913/722d4710-485a-4b34-8466-7e16f490f6a2)

![게임 화면 1 1](https://github.com/shyang12/FIND-PROVISO/assets/85710913/b85e26d8-f713-425b-8028-bcf5ff64882e)  ![게임 화면 2](https://github.com/shyang12/FIND-PROVISO/assets/85710913/bcf75cd6-9ac5-410a-9ccd-26dfd20cb304)

### 6.3 Components

![게임 구성 1](https://github.com/shyang12/FIND-PROVISO/assets/85710913/b4195048-3059-4210-a568-f3d3b2196544)  ![게임 구성 2](https://github.com/shyang12/FIND-PROVISO/assets/85710913/10cd2e0f-2930-4be9-bc9c-0a13f5868738)

![게임 구성 3](https://github.com/shyang12/FIND-PROVISO/assets/85710913/7667959c-74c9-417c-8c4f-1cb26c85d662)  ![게임 구성 4](https://github.com/shyang12/FIND-PROVISO/assets/85710913/356341ec-6658-498b-a677-ef55b29a8ecc)

### 6.4 Ending
- Happy Ending

![엔딩 1](https://github.com/shyang12/FIND-PROVISO/assets/85710913/e56e0fc8-2d8e-4e52-9780-a8217c655f53)

- Bad Ending

![엔딩 2](https://github.com/shyang12/FIND-PROVISO/assets/85710913/25469aae-0aee-49af-abcd-506364797582)
