# MuteOZWL
K에듀파인 설치 후 컴퓨터 부팅 시 OZWebLauncher 알림이 뜨지 않도록 도와줍니다! 

## 사용법
MuteOZWL.zip 파일을 다운받으신 후 압축을 풀어 MuteOZWL.exe 파일을 실행합니다.

`알림 끄기 적용` 버튼을 클릭하면 부팅 시 알림이 안뜨게 하며 `알림 끄기 취소` 버튼을 클릭하면 알림이 안뜨게 하는 설정을 제거합니다.

## 원리
윈도우즈 사용자 계정 컨트롤(UAC)에 의해서 아래와 같은 OZWebLauncher(1028) 관련 알림이 뜨고 `예`를 누를 때까지 계속 창이 떠서 물어봅니다. 이것은 해당 프로그램이 관리자 권한(Administrator)을 필요로 하여 사용자에게 요청하는 것으로 매번 컴퓨터를 킬 때마다 떠서 여간 귀찮은 것이 아닙니다.
![image](https://user-images.githubusercontent.com/1307187/77643251-63ebbc00-6fa2-11ea-9644-0de5ab7cdc43.png)

이를 해결하기 위한 방법으로 관리자 권한을 주면 됩니다. 윈도우 메뉴를 통해서 정석적으로 설정하는 방법은 다음과 같습니다.

[![뻔뻔한 구글쌤 - 성가신 oz web launcher 안나오게 하는 법 (feat. 케에~듀파인)](https://i.ytimg.com/vi/23Gsk3yg4r4/hqdefault.jpg?sqp=-oaymwEZCNACELwBSFXyq4qpAwsIARUAAIhCGAFwAQ==&rs=AOn4CLAhpOkK2MYCUG6N6BR-jXjUSBFJ_A)](https://www.youtube.com/watch?v=23Gsk3yg4r4&feature=youtu.be&fbclid=IwAR39ZFfA2bDts7_SHbJlt42gdxHV-sSLWDNEXdvMdsKInQnaCZMS2pRSodo)

위와 관련해서 해당 설정을 하면 윈도우 레지스트리 값이 추가된다는 것을 박지우 선생님이 알려주셨습니다.
![image](https://user-images.githubusercontent.com/1307187/77643592-02781d00-6fa3-11ea-96f4-15fb41fdc210.png)

위 정보를 바탕으로 이 프로그램은 아래와 같은 위치의 레지스트리에 키-값을 하나 저장해주거나 삭제해주는 역할을 하도록 만들었습니다.
![image](https://user-images.githubusercontent.com/1307187/77643978-a6fa5f00-6fa3-11ea-8854-39f010ba14ff.png)

레지스트리 위치
> 컴퓨터\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers 

키
> C:\Program Files (x86)\FORCS\OZWebLauncher\OZWLBridge.exe

값
> ~ RUNASADMIN

## 관련 문서
아래 링크의 C# 관련 글들을 참고하여 만들었습니다.

### C#에서 레지스트리 읽고 쓰고 삭제하기
 * https://happyguy81.tistory.com/47

### C# 관리자 권한상승 설정
 * https://returngoto.tistory.com/18
