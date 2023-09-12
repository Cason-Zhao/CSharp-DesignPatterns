# 工厂演示示例

## 1、工厂的概念
一个含义模糊的术语，表示可以创建一些东西的方法或类。
一般而言，工厂创建的是对象（实例）。
但是，工厂也可创建文件等目标。

## 2、构建方法的概念
> 意指“创建对象的方法”，它其实只是对构造方法的封装（方法），其（该方法）可能只是起了一个意图表达明确的名称。
它使代码独立于构造方法的修改，可以包含一些特殊逻辑（比如返回已有对象，而不创建新对象）

## 3、工厂方法模式
> 一种创建型设计模式。其在父类中提供一个“创建对象的方法”，允许子类决定实例化对象的具体类型。

举例：部门雇佣员工、发工资
``` csharp
// 工厂方法模式
public class Client
{
	public static void Main(string[] args)
	{
		DepartmentBase depart = null;

		depart = new ITDepartment();
		depart.Hire("张三");
		
		depart = new FinanceDepartment();
		depart.Hire("张思思");
	}
}

// 抽象基类
internal abstract class DepartmentBase
{
	public abstract IEmployee CreateEmployee(string employeeName);// 定义创建对象的方法
	
	private List<IEmployee> EmployeeList { get; set; }

	public void Hire(string employeeName)
	{
		var newEmployee = this.CreateEmployee(employeeName);
		this.EmployeeList.Add(newEmployee);
		newEmployee.GetPaid();
	}
}

// IT部门：开发者
internal class ITDepartment: DepartmentBase
{
	public override IEmployee CreateEmployee(string employeeName)
	{
		return new Developer(employeeName);// 决定实例化对象的具体类型
	}
}

// 财务部门：会计人员
internal class FinanceDepartment: DepartmentBase
{
	public override IEmployee CreateEmployee(string employeeName)
	{
		return new Accountant(employeeName);// 决定实例化对象的具体类型
	}
}

// 市场部门：销售人员
internal class MarketingDepartment: DepartmentBase
{
	public override IEmployee CreateEmployee(string employeeName)
	{
		return new Salesperson(employeeName);// 决定实例化对象的具体类型
	}
}

// 职工接口
internal interface IEmployee
{
	string EmployeeName { get; set; }

	void GetPaid();
}

// 开发人员
internal class Developer: IEmployee
{
	public string EmployeeName { get; set; }

	public Developer(string employeeName)
	{
		this.EmployeeName = employeeName;
	}

	public void GetPaid()
	{
		// 开发工资
	}
}

// 会计人员
internal class Accountant: IEmployee
{
	public string EmployeeName { get; set; }

	public Accountant(string employeeName)
	{
		this.EmployeeName = employeeName;
	}

	public void GetPaid()
	{
		// 会计工资
	}
}


// 销售人员
internal class Salesperson: IEmployee
{
	public string EmployeeName { get; set; }

	public Salesperson(string employeeName)
	{
		this.EmployeeName = employeeName;
	}

	public void GetPaid()
	{
		// 销售工资
	}
}
```

**类图**  
![类图](.\\Resources\\Images\\工厂方法模式类图.png)  
**Creator：创建者，抽象基类“工厂”。**  
尽管此处名称为创建者，但其主要职责并不是产生实例——一般而言，其包含与产品相关的核心业务逻辑，工厂方法将些核心逻辑从具体产品类中剥离出来。
比如，某大型软件开发公司，有开发者培训部，但其主要职责是开发软件，而不是培训开发者

**ConcreteCreator：具体创建者，实现子类“工厂”**  
重写基础工厂方法，使其返回具体产品。
注意：并不是说一定创建一个新对象，可能来自于缓存、对象池、或其它来源的已有对象。

**Product：产品，抽象产品**  
对一类产品进行抽象，包含其功能方法的接口声明。

**ConcreteProduct：具体产品，实现产品**  
产品接口的不同实现

**应用：跨平台UI设计**  
![类图-跨平台UI设计](.\\Resources\\Images\\工厂方法模式类图-应用-跨平台UI设计.png)  

## 4、简单工厂
> 类中提供一个“创建对象的方法”，其方法体中具有大量条件语句，根据方法的参数来决定具体实例化对象的具体类型。通常没有子类。  
> 注意：即使其拥有子类，且其本身被声明为抽象的，其也不会变成抽象工厂模式。（为何如此说，看一下抽象工厂模式的具体内容）

``` csharp

// 工厂方法模式
public class Client
{
	public static void Main(string[] args)
	{
		IEmployee employee = null;

		employee = employee.CreateEmployee("IT", "张三");
		employee.GetPaid();
		
		employee = employee.CreateEmployee("Finance", "张思思");
		employee.GetPaid();
	}
}

internal class EmployeeFactory
{
	public static IEmployee CreateEmployee(string employeeType, string employeeName)// “创建对象的方法”
	{
		// 大量条件语句
		switch(employeeType) 
		{
			case "IT":
				return new Developer(employeeName);// 方法的参数决定实例化对象的具体类型
			case "Finance":
				return new Accountant(employeeName);// 方法的参数决定实例化对象的具体类型
			case "Marketing":
				return new Salesperson(employeeName);// 方法的参数决定实例化对象的具体类型
			default:
				throw new Exception($"未知的职工类型{employeeType}！请检查");
		}
	}
}
```
## 5、抽象工厂
> 是一种创建型设计模式，它能创建一系列相关或相互依赖的对象。
> 如：`运输工具+引擎+控制器`：电动车+电机+车把、汽车+内燃机+方向盘、 飞机+涡轮喷气发动机+操纵杆

## 6、静态工厂

## 7、策略模式

## 8、反射

## 9、反射+简单工厂+配置

## 10、

# 附
- [参考1](https://zhuanlan.zhihu.com/p/443953956)
- [参考2](https://blog.csdn.net/Marion158/article/details/115892451)

## 附1、杂：复杂、繁杂、庞杂
> 在开发工作中我们经常会听到：这个**业务**很复杂，这个**系统**很复杂，这个**逻辑**很复杂，只要是处理遇到困难的场景，似乎都可以使用复杂这个词进行描述。
> 但困难之所以困难，原因还是有所不同的，不能用复杂这个词笼而统之，有加以区分的必要。大体上可以分为**复杂**、**繁杂**、**庞杂**三个类型。

> 复杂和繁杂二者均包含分支多和逻辑多的含义，但是不同之处在于:
> - 复杂场景是可以理出头绪的，如果设计得当，是可以设计出很优雅的系统的。
> - 但是繁杂场景是难以理出头绪的，为了兼容只能打各种补丁，最终积重难返只能系统重构。  
>   
> 庞杂：当数量达到一定规模时，复杂和繁杂都可以演化为庞杂。虽然同样是庞杂，但是也有**复杂庞杂**和**繁杂庞杂**的区别。复杂和庞杂，只要加上数量维度就是庞杂。

> 我们在开发中可以写复杂的代码，要尽量避免繁杂的代码，其中代码耦合就是一种典型的繁杂场景，模块间高度耦合的代码导致最终根本无法维护。


## 附2、高内聚、低耦合
> 耦合主要描述模块之间的关系，内聚主要描述模块内部的关系。
> ![高内聚低耦合](.\\Resources\\Images\\高内聚低耦合.jpg)
> - 内聚：从功能的角度来度量**模块内**的联系，一个好的内聚模块应当**恰好做一件事**。它描述的是模块内的功能联系。
> - 耦合：软件结构中各**模块之间**相互连接的一种度量，耦合强弱取决于——模块间接口的复杂程度、进入或访问一个模块的点以及通过接口的数据。

> 模块——就是从逻辑上将系统分解为更细微的部分，分而治之，复杂问题拆分为若干简单问题，逐个解决。
> 模块的粒度可大可小，可以是系统、类、函数、功能块等。

### 附1.1、耦合
> 模块之间存在依赖，导致改动可能相互影响。如果模块间重重依赖，会极大降低开发效率
> 关系越紧密→耦合越强→模块独立性越差；模块独立性越强→可扩展性越高、可维护性越好；
> 

不同模块之间的关系就是耦合，根据耦合程度可以分为7种，耦合度依次变低。
- 内容耦合
- 公共耦合
- 外部耦合
- 控制耦合
- 标记耦合
- 数据耦合
- 非直接耦合

#### 附1.1.1、内容耦合
> 一个模块可以直接访问另一个模块的内部数据被称为内容耦合（又称病态耦合），这是耦合性最强的类型，这也是我们需要尽量避免的。

示例1：假设-模块A是订单模块、模块B是支付模块，如果支付模块可以直接访问订单数据表，那么至少会带来以下问题：
> ![内容耦合](.\\Resources\\Images\\耦合-1内容耦合.jpg)
- 存在重复的数据访问层代码，支付和订单模块都要写订单数据访问代码。
- 如果订单业务变动（需要变更订单数据字段），而此时支付模块没有跟着及时变更，那么可能会造成业务错误。
- 如果订单业务变动（需要分库分表拆分数据），而此时支付模块没有跟着及时变更，那么可能会造成支付模块严重错误。
- 业务入口没有收敛，访问入口到处散落，如果想要业务变更则需要多处修改，非常不利于维护。

示例2：车贩子买车、先检查车
> ```CSharp
> // 奔驰车
> public class BenZ
> {
> 	// 车架号
> 	public string VIN;
> 	// 里程
> 	public int MileAge;
> 	// 发动机
> 	public string Engine;
> 	// 轮胎
> 	public string Tyre;
> }
> // 车贩子
> public class CarDealers
> {
> 	// 车子
> 	private BenZ benz = new BenZ();
> 	// 检查车辆状况 
> 	public void Check()
> 	{
> 		// 查看车架号
> 		Console.WriteLine(benz.VIN);
> 		
> 		// 悄咪改了
> 		benz.MileAge += 100000;
> 		
> 		// 查看行驶里程
> 		Console.WriteLine(benz.MileAge);
> 		
> 		benz.Tyre = "破旧发动机（悄咪换）"
> 		
> 		// 查看发动机情况
> 		Console.WriteLine(benz.Engine);
> 		
> 		benz.Tyre = "破旧轮胎（悄咪换）"
> 		
> 		// 查看轮胎情况
> 		Console.WriteLine(benz.Tyre);
> 	}
> }
> ```

> ```CSharp
> // 奔驰车
> public class BenZ
> {
> 	// 车架号
> 	public string VIN;
> 	
> 	public int _mileAge;
> 	// 里程
> 	public int MileAge { get { return this._mileAge; } set { OperationLog.Add($"修改里程：从{this._mileAge}到{value}"); this._mileAge = value;} }
> 	
> 	private string _engine;
> 	// 发动机
> 	public string Engine { get { return this._engine; } set { OperationLog.Add($"修改发动机：从{this._engine}到{value}"); this._engine = value;} }
> 	
> 	// 轮胎
> 	public string _tyre;
> 	// 轮胎
> 	public string Tyre { get { return this._tyre; } set { OperationLog.Add($"修改轮胎：从{this._tyre}到{value}"); this._tyre = value;} }
> 	
> 	private List<string> OperationLog = new List<string>();
> }
> // 车贩子
> public class CarDealers
> {
> 	// 车子
> 	private BenZ benz = new BenZ();
> 	// 检查车辆状况
> 	public void Check()
> 	{
> 		// 查看车架号
> 		Console.WriteLine(benz.VIN);
> 		
> 		// 悄咪改了
> 		benz.MileAge += 100000;
> 		
> 		// 查看行驶里程
> 		Console.WriteLine(benz.MileAge);
> 		
> 		benz.Tyre = "破旧发动机（悄咪换）"
> 		
> 		// 查看发动机情况
> 		Console.WriteLine(benz.Engine);
> 		
> 		benz.Tyre = "破旧轮胎（悄咪换）"
> 		
> 		// 查看轮胎情况
> 		Console.WriteLine(benz.Tyre);
> 	}
> }
> ```

> ```CSharp
> // 车辆
> public interface ICar
> {
> 	// 里程
> 	int MileAge { get; set; }
> 	// 发动机
> 	string Engine { get; set; }
> 	// 轮胎
> 	string Tyre { get; set; }
> }
> 
> // 奔驰车
> public class BenZ: ICar
> {
> 	// 车架号
> 	public string VIN;
> 	
> 	public int _mileAge;
> 	// 里程
> 	public int MileAge { get { return this._mileAge; } set { OperationLog.Add($"修改里程：从{this._mileAge}到{value}"); this._mileAge = value;} }
> 	
> 	private string _engine;
> 	// 发动机
> 	public string Engine { get { return this._engine; } set { OperationLog.Add($"修改发动机：从{this._engine}到{value}"); this._engine = value;} }
> 	
> 	// 轮胎
> 	public string _tyre;
> 	// 轮胎
> 	public string Tyre { get { return this._tyre; } set { OperationLog.Add($"修改轮胎：从{this._tyre}到{value}"); this._tyre = value;} }
> 	
> 	private List<string> OperationLog = new List<string>();
> }
> 
> // 车贩子
> public class CarDealers
> {
> 	// 车子
> 	private ICar car = new BenZ();
> 	// 检查车辆状况
> 	public void Check()
> 	{
> 		// 查看车架号
> 		Console.WriteLine(car.VIN);
> 		
> 		// 悄咪改了
> 		car.MileAge += 100000;
> 		
> 		// 查看行驶里程
> 		Console.WriteLine(car.MileAge);
> 		
> 		car.Tyre = "破旧发动机（悄咪换）"
> 		
> 		// 查看发动机情况
> 		Console.WriteLine(car.Engine);
> 		
> 		car.Tyre = "破旧轮胎（悄咪换）"
> 		
> 		// 查看轮胎情况
> 		Console.WriteLine(car.Tyre);
> 	}
> }
> ```

> ```CSharp
> // 车辆
> public interface ICar
> {
> 	// 里程
> 	int MileAge { get; set; }
> 	// 发动机
> 	string Engine { get; set; }
> 	// 轮胎
> 	string Tyre { get; set; }
> }
> 
> // 奔驰车
> public class BenZ: ICar
> {
> 	// 车架号
> 	public string VIN;
> 	
> 	public int _mileAge;
> 	// 里程
> 	public int MileAge { get { return this._mileAge; } set { OperationLog.Add($"修改里程：从{this._mileAge}到{value}"); this._mileAge = value;} }
> 	
> 	private string _engine;
> 	// 发动机
> 	public string Engine { get { return this._engine; } set { OperationLog.Add($"修改发动机：从{this._engine}到{value}"); this._engine = value;} }
> 	
> 	// 轮胎
> 	public string _tyre;
> 	// 轮胎
> 	public string Tyre { get { return this._tyre; } set { OperationLog.Add($"修改轮胎：从{this._tyre}到{value}"); this._tyre = value;} }
> 	
> 	private List<string> OperationLog = new List<string>();
> }
> 
> // 车贩子
> public class CarDealers
> {
> 	// 车子
> 	private ICar _car;
> 	
> 	// DI 依赖注入car
> 	public void SetCar(ICar car)
> 	{
> 		this._car = car;
> 	}
> 	// 检查车辆状况
> 	public void Check()
> 	{
> 		// 查看车架号
> 		Console.WriteLine(this._car.VIN);
> 		
> 		// 悄咪改了
> 		this._car.MileAge += 100000;
> 		
> 		// 查看行驶里程
> 		Console.WriteLine(this._car.MileAge);
> 		
> 		this._car.Tyre = "破旧发动机（悄咪换）"
> 		
> 		// 查看发动机情况
> 		Console.WriteLine(this._car.Engine);
> 		
> 		this._car.Tyre = "破旧轮胎（悄咪换）"
> 		
> 		// 查看轮胎情况
> 		Console.WriteLine(this._car.Tyre);
> 	}
> }
> ```


#### 附1.1.2、公共耦合
> 多个模块都访问同一个公共数据环境被称为公共耦合。公共数据环境例如全局数据结构、共享通信区和内存公共覆盖区。  
> 如几个模块对同一个数据库的查询就属于这种耦合。  
> 公共耦合可以分为松散的公共耦合和紧密的公共耦合。  
> - 其中松散的公共耦合是单向操作，如两个或多个模块对同一个文件的读操作；  
> - 而紧密的公共耦合是双向的操作，如两个或多个模块对同一文件的读写操作； 

![公共耦合](.\\Resources\\Images\\耦合-2公共耦合.jpg)

#### 附1.1.3、外部耦合
> 多个模块都访问同一个全局简单变量（非全局数据结构）并且不是通过参数表传递此全局变量信息被称为外部耦合。

![外部耦合](.\\Resources\\Images\\耦合-3外部耦合.jpg)
示例：库存
``` CSharp
public class Inventory
{
	public static int Count = 1000;
}

public class Purchase()
{
	public void AddInventory()
	{
		Inventory.Count++;
	}
}

public class Sale
{
	public void ReduceInventory()
	{
		Inventory.Count--;
	}
}

```

#### 附1.1.4、控制耦合
> 模块之间传递信息中包含用于控制模块内部的信息被称为控制耦合。控制耦合可能会导致模块之间控制逻辑相互交织，逻辑之间相互影响，非常不利于代码维护。
> 一个模块调用另一个模块时，传递的是控制变量，被调用模块通过该控制变量的值有选择地执行模块内的某一功能。因此，被调用模块应具有多个功能，哪个功能起作用受调用模块控制。

![控制耦合](.\\Resources\\Images\\耦合-4控制耦合-2.jpg)
![控制耦合](.\\Resources\\Images\\耦合-4控制耦合.jpg)  
  

#### 附1.1.5、标记耦合
> 调用模块和被调用模块之间传递数据结构而不是简单数据，同时也称作特征耦合。
![标记耦合](.\\Resources\\Images\\耦合-5标记耦合.png)  
``` CSharp
public class A
{
	public int Operate(int num1, int num2)
	{
		OperateParam param = new OperateParam
		{
			Num1 = num1;
			Num2 = num2;
		};

		return new B().Operate(param);
	}
}

public class B
{
	public int Operate(OperateParam param)
	{
		
	}
}

public class OperateParam
{
	public int Num1 { get; set; }

	public int Num2 { get; set; }
}

```

#### 附1.1.6、数据耦合
> 两个模块调用时，传递的是简单的数据值，不是数据结构或者其他复杂变量。
> 如果一个模块访问另一个模块时，彼此之间是通过数据参数(不是控制参数、公共数据结构或外部变量)来交换输入、输出信息的，则称这种耦合为数据耦合。
> 在软件程序结构中至少必须有这类耦合。
![数据耦合](.\\Resources\\Images\\耦合-6数据耦合.jpg)  
``` CSharp
public class A
{
	public int Operate(int num1, int num2, int num3, int num4)
	{
		var sum1 = B.Add(num1, num2);
		var sum2 = B.Add(num3, num4);
		return B.Add(sum1,sum2);
	}
}

public class B
{
	public static int Add(int num1, int num2)
	{
		return num1 + num2;
	}
}

```

#### 附1.1.7、非直接耦合
> 多个模块之间没有直接联系，通过主模块的控制和调用实现联系被称为非直接耦合，这也是一种理想的耦合方式。
> 复杂业务之所以复杂，一个重要原因是涉及角色或者类型较多，很难平铺直叙地进行设计。如果非要进行平铺设计，必然会出现大量if else代码块。
![非直接耦合](.\\Resources\\Images\\耦合-7非直接耦合.jpg)  

场景分析：当前有ABC三种订单类型
 - A订单价格9折，物流最大重量不能超过9公斤，不支持退款。
 - B订单价格8折，物流最大重量不能超过8公斤，支持退款。
 - C订单价格7折，物流最大重量不能超过7公斤，支持退款。  

场景并不复杂，平铺直叙的方式可以实现
``` CSharp
public class OrderCmd
{
    public void createOrder(OrderInfo orderInfo) 
	{
        if (null == orderInfo) 
		{
            throw new ArgumentNullException("参数异常！");
        }
        if (!OrderTypeConst.ContainsKey(orderInfo.OrderType)) 
		{
            throw new Exception("订单类型数据非法！");
        }
		
        // A类型订单
        if (OrderTypeConst.A == orderInfo.OrderType) 
		{
            orderInfo.Price = orderInfo.Price * 0.9;
            if (orderInfo.Weight > 9) 
			{
                throw new Exception("超过物流最大重量");
            }
            orderInfo.IsSupportRefund = False;
        }
        // B类型订单
        if (OrderTypeConst.B == orderInfo.OrderType) 
		{
            orderInfo.Price = orderInfo.Price * 0.8;
            if (orderInfo.Weight > 8) 
			{
                throw new Exception("超过物流最大重量");
            }
            orderInfo.IsSupportRefund = True;
        }
        // C类型订单
        if (OrderTypeConst.C == orderInfo.OrderType) 
		{
            orderInfo.Price = orderInfo.Price * 0.7;
            if (orderInfo.Weight > 7) 
			{
                throw new Exception("超过物流最大重量");
            }
            orderInfo.IsSupportRefund = True;
        }
		
        // 保存数据
		SaveOrder(orderInfo);
    }
	
	public void SaveOrder(OrderInfo orderInfo)
	{
		// 保存
	}
}

public class OrderInfoModel
{
	public string OrderType { get; set; }
	
	public decimal Price { get; set; }
	
	public decimal Weight { get; set; }
	
	public bool IsSupportRefund { get; set; }
}

public class OrderTypeConst
{
	public string A = "A";
	public string B = "B";
	public string C = "C";
	
	private static readonly Dictionary<string, string> Names = new Dictionary<string, string>
	{
		{ A, "9公斤"},
		{ B, "8公斤"},
		{ C, "7公斤"},
	};
	
	public static bool ContainsKey(string key)
	{
		return key == null || !Names.ContainsKey(key) ? string.Empty: Names[key];
	}
}
```

上述代码从功能上完全可以实现业务需求，但是程序员不仅要满足于功能的实现，还需要思考代码的可维护性。
**需求变动**：如果新增一种订单类型，或者新增一个订单属性处理逻辑。
**问题出现**：那么我们就要在上述逻辑中新增代码，如果处理不慎就会影响原有逻辑。
**解决方案**：为了避免牵一发而动全身这种情况，设计模式中的开闭原则要求我们面向新增开放，面向修改关闭。
- 应对需求变化 应通过扩展的方式，而不是修改已有代码，这样就保证代码稳定性。
- 扩展也不是随意扩展，因为事先定义了框架，扩展也是根据框架扩展。
- 用抽象构建框架，用实现扩展细节。

如何改变平铺直叙的思考方式？


### 附1.2、内聚
- 偶然内聚
- 逻辑内聚
- 时间内聚
- 通信内聚
- 顺序内聚
- 功能内聚  

1.偶然内聚

   模块的各成分之间没有关联，只是把分散的功能合并在一起。

   例：A模块中有三条语句（一条赋值，一条求和，一条传参），表面上看不出任何联系，但是B、C模块中都用到了这三条语句，于是将这三条语句合并成了模块A。模块A中就是偶然内聚。

2.逻辑内聚

   逻辑上相关的功能被放在同一模块中。

   例：A模块实现的是将对应的人员信息发送给技术部，人事部和财政部，决定发送给哪个部门是输入的控制标志决定的。模块A中就是逻辑内聚。

3.时间内聚

   模块完成的功能必须在同一时间内执行，但这些功能只是因为时间因素才有关联。

   例：编程开始时，程序员把对所有全局变量的初始化操作放在模块A中。模块A中就是时间内聚。

4.过程内聚

   模块内部的处理成分是相关的，而且这些处理必须以特定的次序进行执行。

   例：用户登陆了某某网站，A模块负责依次读取用户的用户名、邮箱和联系方式，这个次序是事先规定的，不能改变。模块A中就是过程内聚。

5.通信内聚

   模块的所有成分都操作同一数据集或生成同一数据集。

   例：模块A实现将传入的Date类型数据转换成String类型，以及将Date类型数据插入数据库，这两个操作都是对“Date类型数据”而言的。模块A中就是通信内聚。

6.顺序内聚

   模块的各个成分和同一个功能密切相关，而且一个成分的输出作为另一个成分的输入。

   例：模块A实现将传入的Date类型数据转换成String类型，然后再将转换好的String类型数据插入数据库。模块A中就是顺序内聚。

7.功能内聚

   模块的所有成分对于完成单一的功能都是必须的。

   例：模块A实现将新注册的用户信息（用户名，密码，个性签名）全部转换成String类型并插入数据库。模块A中就是功能内聚。

