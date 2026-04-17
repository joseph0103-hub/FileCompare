# (C# 코딩) 파일 비교 프로그램 (FileCompare)

## 목차
1. 개요
2. 과제 1
3. 과제 2
4. 과제 3
5. 과제 4

---

## 1. 개요
본 실습은 C# Windows Forms(.NET) 환경에서 두 개의 폴더를 비교하고 파일을 복사하는 파일 비교 도구(File Compare Tool)를 구현하는 과제이다. Visual Studio를 사용하여 UI 구성, 파일 목록 표시, 파일 비교 및 복사 기능을 단계적으로 구현한다.

- 사용한 플랫폼  
  : C#, .NET Windows Forms, Visual Studio, GitHub

- 사용한 컨트롤  
  : Label, TextBox, Button, ListView, SplitContainer, Panel

- 사용한 기술과 구현 기능  
  : Visual Studio를 이용한 UI 디자인  
  : 파일 시스템 접근 (Directory, File 클래스)  
  : 이벤트 기반 프로그래밍

- 수업 중 사용한 주요 클래스  
  - Directory: 폴더 내 파일 목록 조회
  - File: 파일 복사 처리
  - DateTime: 파일 수정 시간 비교

- 실습 중 구현한 기능  
  : 두 폴더 파일 목록 비교  
  : 파일 존재 여부 및 수정일 기준 색상 표시  
  : 선택 파일 복사 기능  
  : 하위 폴더 포함 전체 복사 기능  

---

## 2. 과제 1

### 실행 화면
![패널1](img/Assignment_1_panel1.png)
![패널2](img/Assignment_1_panel2.png)
![패널3](img/Assignment_1_panel3.png)
![초기화면](img/Assignment_1_initial.png)

### 과제 내용
- SplitContainer를 이용하여 좌측과 우측 영역으로 화면을 분할하고 전체 UI 구조를 설계한다.
- Label, TextBox, Button 컨트롤을 배치하여 프로그램 이름과 폴더 경로 입력 영역을 구성한다.
- 중앙 영역에 Panel을 활용하여 화살표 버튼(파일 복사 버튼)을 배치하고 좌우 영역과 구분되도록 한다.
- ListView 컨트롤을 추가하여 좌측과 우측 폴더의 파일 목록이 표시될 수 있는 구조를 완성한다.
- 각 컨트롤은 lblAppName, txtLeftDir, txtRightDir, lvwLeftDir, lvwRightDir, btnCopyFromLeft, btnCopyFromRight 등 의미 있는 이름으로 지정한다.


### 구현 내용과 기능 설명
- SplitContainer를 중심으로 좌측(ListView + TextBox + Button)과 우측 영역을 대칭 구조로 구성하였다. :contentReference[oaicite:0]{index=0}
- Label(lblAppName)을 통해 프로그램 이름(File Compare)을 상단에 표시하여 UI의 목적을 명확히 하였다.
- 각 영역에는 TextBox(txtLeftDir, txtRightDir)와 Button(btnLeftDir, btnRightDir)을 배치하여 폴더 경로를 입력하거나 선택할 수 있도록 구현하였다.
- 중앙에는 Panel을 별도로 구성하고 그 안에 btnCopyFromLeft, btnCopyFromRight 버튼을 배치하여 위치가 흐트러지지 않도록 설계하였다.
- 좌우 영역 하단에는 ListView(lvwLeftDir, lvwRightDir)를 배치하여 이후 파일 목록을 출력할 수 있는 기반 UI를 완성하였다.
- 컨트롤 배치와 이름을 일관성 있게 구성하였다.
