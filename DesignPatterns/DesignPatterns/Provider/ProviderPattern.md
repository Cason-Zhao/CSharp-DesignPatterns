# ProviderPattern
#### [Markdown Syntax](https://markdown.com.cn/basic-syntax/line-breaks.html)

#### 零、References  
> 1. [【博客园:MesssageProvider】](https://www.cnblogs.com/taotaodetuer/p/6182743.html)  
> 2. [【博客园:】](https://www.cnblogs.com/chucklu/p/4495527.html)  
> 3. [【CSDN:】](https://kb.cnblogs.com/page/45329/)
> 4. [【博客园:LogProvider】](https://www.cnblogs.com/time-is-life/p/6349250.html)  
> 5. [【慕课手记：】](https://www.imooc.com/article/50740)

#### 一、 概述
>	Provider Pattern（提供者模式）可视为由的两个设计模式融合而成的：Strategy（策略）和abstract factory（抽象工厂）。
	API定义好，其功能通过Strategy模式变异而来，是“可插（拔）”的，
	而功能被加载进内存则是通过大致地一个Abstract Factory设计模式而实现的。

1. API Class  
    这是一个通过静态方法定义和暴露所需功能的类，在API Class中并没有具体的实现。
    此类保持一个对Application Provider Base类的引用，这个base类会对API中的功能进行基本的包装（Wrap）。
2. Provider Base Class  
    这是一个内部抽象类，位于System.Configuration.Provider命名空间，用于定义一个Provider。  
    Initialize()方法用于从配置文件中获取必要的信息来构建具体的Provider。  
    我们在自己实现这个抽象类的时候要记的重写Initialize()方法。
3. Application Provider Base  
    这是一个从ProviderBase类继承来的一个抽象类，同时也是API类的一个“镜像”，通过在API中所暴露的方法来为父类定义抽象方法并在父类中实现。
4. Concrete Provider  
    Application Provider Base中所定义的方法在这个类中实现。
    Concrete Provider为了从配置文件中读取信息而会重写Initialize()方法。
---
>   这四个类是实现Provider模式所必须的。  
    其它的类则是用来定义一个Provider能提供什么东西或是在以后为这些对象提供服务的工具类，或是用于管理程序配置文件。
---

