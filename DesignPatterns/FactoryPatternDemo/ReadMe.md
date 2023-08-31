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
``` c#
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

