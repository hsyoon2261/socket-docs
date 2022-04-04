# Delegate

### 메서드 참조형

- 복수 또는 단일 메서드를 대신하여 호출
- 같은 형식이어야 한다.
- 메서드만 호출 가능
- 형식
> [접근 한정자] delegate return type_name (param)
```c#
delegate int DelegateType(string Name)
```
- delegate 사용
```c#
DelegateType DelegateMethod = Function;
```
- source
```c#
using System;

namespace DelegateAndEvent
{
    delegate void PrintPlus(string str);
    class DelegateEx
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            DelegateEx Test = new DelegateEx();
            PrintPlus DelMethod1 = Test.Print;
            //or using(before c#2.0)
            //PrintPlus DelMethod1 = new PrintPlus(Test.Print);
            DelMethod1("Hello delegate");
        }
    }
}
```

-----
<br/>

### delegate chain
- 데이터를 여러개의 메서드에게 동시에 보내다.
- source code
```c#
    //DelegateMethod += Function;
    // Function return, param type은 같아야함.
    // 위의 예제로 치면 return type : void , param : str   
```
--- 

# Event
- **특정 상황 발생 시** 데이터 동시 다발적 호출
- 이벤트 발생시키는 클래스 : 게시자
- 이벤트 받거나 처리하는 클래스 : 구독자
- 델리게이트 기반 (메서드 호출)
- 이벤트는 메서드 안에서만 사용가능(핸들러)

- 형식
> [접근 한정자] event type_name event_name
```c#
delegate void DelegateType(string message);
class EventEx
{
    public event DelegateType EventHandler;
    //EventHandler는 반드시 Func 메서드 안에서 호출!!
    public void Func(string Message)
    // Func = 이벤트 핸들러를 포함하는 객체
    {
        EventHandler(Message);
    }
}
```
- event 사용

객체.이벤트핸들러 += 객체.메서드명;
```c#
    delegate void PrintPlus(string str);
    
    class A
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public void Print2(string str)
        {
            Console.WriteLine("adding event");
            Console.WriteLine(str);
        }

        public event PrintPlus EventHandler; //이름은 달라도 된다.

        public void PrintEvent(String str)
        {
            EventHandler(str);
        }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------event start----------");
            A Test2 = new A();
            Test2.EventHandler += Test.Print;
            Test2.EventHandler += Test.Print2;
            Test2.PrintEvent("Hello event");
       
        }
    }
```

### event 정리
1. event에(여기서는 EventHandler) delegate method를 연결하고(여기서는 PrintPlus)
2. EventHandler 는 delegate method type의 method를 구독한다.<br/>
   (여기서는 Print, Print2)
3. 이벤트 발생시 이벤트 핸들러를 포함하는 객체(여기서는 PrintEvent)를 통해 데이터를 구독된 메서드에 담아 호출 

https://huiyu.tistory.com/entry/C-%EA%B8%B0%EC%B4%88-%EC%9D%B4%EB%B2%A4%ED%8A%B8%EC%99%80-%EB%8D%B8%EB%A6%AC%EA%B2%8C%EC%9D%B4%ED%8A%B8-Event-Delegate

EventArgs, EventHandler
http://ojc.asia/bbs/board.php?bo_table=Cyber&wr_id=10974

### 추가로 알아야 할 사항
- 윈폼 + event 
- 인덱서 + array
- https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/indexers/