## TCP 서버와 클래스

- TcpListener <br/> 연결과 TcpClient 객체 생성
- TcpClient <br/> 데이터 전송
  - NetworkStream
- 동작방식
![동작방식](./static/1.png)
![multi](./static/2.png)
![flow](./static/untitled%20map%20(1).png)
-----
### TcpClient (Server and Client)
| Method      |               description               |
|-------------|:---------------------------------------:|
| Close()     |                TCP 연결 종료                |
| Connect()   |              TCP 서버 연결 시도               |
| GetStream() | 데이터 전송을 수신하는데 사용되는 Network Stream 객체 생성 |
| GetType()   |              현재 객체의 타입 검사               |
| ToString()  |          현재 객체를 String 객체로 변환           |

-----
### TcpListener(Server)
| Method      |               description               |
|-------------|:---------------------------------------:|
| Close()     |                TCP 연결 종료                |
| Connect()   |              TCP 서버 연결 시도               |
| GetStream() | 데이터 전송을 수신하는데 사용되는 Network Stream 객체 생성 |
| GetType()   |              현재 객체의 타입 검사               |
| ToString()  |          현재 객체를 String 객체로 변환           |

-----

## 개요

- 정보 클래스(클래스 지만 구조체 수준)
  - IPAddress : ip 주소 <-> long 형 변환
  - Dns : ip + domain
  - IPHostEntry : ip + hostname
  - IPEndPoint : ip + port
- 연결 클래스 (Socket 기반 (Winsock) )
  - TcpListener
    - 생성자 ip주소 포트번호 설정
    - Start, Stop, AcceptTcpClient(return type : TcpClient)
  - TcpClient
    - 생성자 : ip주소(string hostname) 포트(int port) 설정 => 연결 통로 설정
    - 연결 해제 : TcpClient.Close()
  - UdpClient
  - 생성자 외의 연결 요청 메소드
  ```c#
  public void Connect(IPAddress address, int port)
  public void Connect(IPAddress[] ipAddresses, int port)
  public void Connect(IPEndPoint remoteEP)
  public void Connect(string hostname, int port)
  ```
- 전송 클래스
  - NetworkStream
    - public NetworkStream GetStream()
  - StreamWriter/StreamReader
  - BinaryWriter/BinaryReader