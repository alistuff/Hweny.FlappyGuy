#FlappyGuy
这是一个简单的2D游戏程序，基本上是游戏《FlappyBird》的克隆版本。

**e-mail：alistuff#163.com (`#` to `@`)**

[www.alistuff.com](www.alistuff.com)
##Implementation
* Microsoft Visual Studio 2010 + .Net framework 4.0
* C#
* GDI+
* Winform

##Game Framework
组成游戏框架的相关类简述如下：

1. `Game`：游戏基类，该类提供游戏初始化（`LoadContent`、`Initialize`）、更新（`Update`）、渲染（`Render`）（*GameLoop*）和清理（`UnLoadContent`）操作；具体游戏类必须继承它并实现相应的操作，实例化一个游戏对象并发送`Run`消息即可运行游戏。

2. `GameSceneManager`：游戏场景管理类，该类维护游戏所有场景，基于栈（`Stack`）的机制实现游戏场景的切换，`Push`操作设置当前场景、`Pop`操作返回上一个场景及`Replace`操作替换当前场景为新场景。

3. `GameScene`：游戏场景基类，每个游戏场景都有初始化（`Initialize`）、更新（`Update`）和渲染（`Render`）操作，每当进入场景时将响应`OnEnter`操作，当离开场景时将响应`OnLeave`操作；除此之外，每个场景维护着需要监听场景输入的监听者（`IMouseListener`，`IKeyListener`），通过`AddKeyListener`、`AddMouseListener`注册监听者；当游戏接收到输入消息时，便向当前场景发送游戏输入消息，监听者将接收到需要的输入数据。

4. `IKeyListener`：键盘监听者接口，需要监听游戏键盘输入（`KeyPressed`、`KeyReleased`）的类需要实现该接口。

5. `IMouseListener`：鼠标监听者接口，需要监听游戏鼠标输入（`MousePressed`、`MouseMoved`、`MouseReleased`）的类需要实现该接口。

##Graphics
*Assets*文件夹包含游戏所需要的图片资源，使用*Macromedia Fireworks 8*创建，所有人均可自由使用这些资源。

*编译该项目时请复制该文件夹到bin文件夹的Debug（调试模式）或Release（发布模式）文件夹中*
##Screenshots
游戏场景：GameLogo动画场景、GameMenu菜单场景、GameReady场景、GamePlay场景、GameOver场景。

###GameLogo
![GameLogo](http://alistuff.com/usr/uploads/2014/07/3324034681.png "GameLogo")
###GameMenu
![GameMenu](http://alistuff.com/usr/uploads/2014/07/2683706080.png "GameMenu")
###GameReady
![GameReady](http://alistuff.com/usr/uploads/2014/07/1526530366.png "GameReady")
###GamePlay
![GamePlay](http://alistuff.com/usr/uploads/2014/07/4152560611.png "GamePlay")
###GameOver
![GameOver](http://alistuff.com/usr/uploads/2014/07/1980618891.png "GameOver")

