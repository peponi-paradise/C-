﻿using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Text;

// 값 형식 예제

// 할당

int a = 1;
int b = a;
a = 2;

Console.WriteLine($"a = {a}, b = {b}"); // a = 2, b = 1

// 메서드 인수 전달

ChangeInt(b);

void ChangeInt(int val)
{
    val = 500;
    Console.WriteLine($"val = {val}");
}

Console.WriteLine($"b = {b}");

// 메서드 리턴

Console.WriteLine($"a = {ChangeAndReturnInt(a)}");

Console.WriteLine($"a = {a}");

int ChangeAndReturnInt(int val)
{
    val = 100;
    return val;
}

// 정수 100을 초기화

int binaryInt = 0b_0110_0100;
int binaryInt2 = 0b01100100;

int decimalInt = 100_00;

int hexInt = 0x64;

var int1 = 9_999;    // int
var int2 = 2_999_999_999;      // uint
var int3 = 9_999_999_999;      // long
var int4 = 9_999_999_999_999_999_999;       // ulong

short short1 = 30000;
//short short2 = 99999;   // CS0031: '99999' 상수 값을 'short`(으)로 변환할 수 없습니다.

var byte1 = (byte)15;
var long1 = (uint)15;

var floatValue = 0.1F;

var doubleValue = 0.1;
var doubleValue2 = 0.1D;

var decimalValue = 0.1M;

double castingDouble = 1.6;
int castingInt = (int)castingDouble;    // castingInt = 1

double castingDouble2 = 1.5;
int castingInt2 = (int)Math.Round(castingDouble2);    // castingInt2 = 2

Console.WriteLine(castingInt);
Console.WriteLine(castingInt2);

double X = 1.0;
decimal Y = 1M;

double Z = X + (double)Y;
decimal W = (decimal)X + Y;

Console.WriteLine(Z);
Console.WriteLine(W);

//const int X = 500;
//float Y = X;
//byte Z = X;     // CS0031: '500' 상수 값을 'byte`(으)로 변환할 수 없습니다.

bool XX = false;
string convertString = XX.ToString();
int convertInt = Convert.ToInt32(XX);

char AA = 'A';
char BB = '\uAC01';
BB = (char)(BB - (char)2);

BB = (char)(AA + BB);

double XXXX = BB;

char C = '\uAC00';       // 80

int AC = C;
double BC = C;
short SC = (short)C;

test BBBA = default;
int testEnum = 0;
test parsed = (test)Enum.Parse(typeof(test), testEnum.ToString());
Console.WriteLine(BBBA.ToString());

int sadasd = 10;
StatusCode code = (StatusCode)13;  // 13
code = Enum.Parse<StatusCode>("Warning");      // 키가 정의되어 있지 않은 경우 예외가 발생한다. 여기서는 방법만 소개한다.
bool isSuccess = Enum.TryParse<StatusCode>("Warning", out StatusCode code2);
bool isDefined = Enum.IsDefined(typeof(StatusCode), "Hello");
Console.WriteLine($"{code}, {(int)code}");
code = StatusCode.Run;
code = StatusCode.Error;

bool boolean = Convert.ToBoolean("TrUe");
var bt = Convert.ToBoolean(-4.156);

testStruct st = new testStruct(10, "ads");
st.a = 1;
Console.WriteLine($"{st.a}, {st.b}");

//var coordinate = new CartesianCoordinate();
//Console.WriteLine($"{coordinate.X}, {coordinate.Y}");
//var coordinate1 = coordinate with { X = 5 };
//Console.WriteLine($"{coordinate1.X}, {coordinate1.Y}");
//var coordinate2 = default(CartesianCoordinate);
//Console.WriteLine($"{coordinate2.X}, {coordinate2.Y}");

int? A = 1;
int B = (int)A;

A = null;

object AAA = 1;
object BBB = "A";
object CCC = new MyClass(10);
Console.WriteLine(CCC.Equals(new MyClass(10)));   // True
Console.WriteLine(CCC.Equals(10));   // False

object DDD = CCC;
Console.WriteLine(Object.ReferenceEquals(CCC, DDD));

// String literal

string string1 = "Sample string";
string string2 = @"Sample Path : C:\Temp\SampleText.txt";
string string3 = "Sample Path : C:\\Temp\\SampleText.txt";

// From char

char[] chars = { 'A', 'B', 'C' };
string string4 = new string(chars);

// Repeated string

string string5 = new string('A', 5);

// From byte

byte[] bytes = { 0x41, 0x42, 0x43 };    // { A, B, C }
string string6 = Encoding.Default.GetString(bytes);

// Raw string literal

string string7 = """This is "Raw string literal".""";
string jsonString = """
    {
        "SampleValue": 1
    }
    """;
Console.WriteLine(string7);
Console.WriteLine(jsonString);

string stringCheck1 = null;
string stringCheck2 = string.Empty;
string stringCheck3 = " ";
string stringCheck4 = "ABC";

// 1. string.IsNullOrEmpty(string)

Console.WriteLine(string.IsNullOrEmpty(stringCheck1));          // True
Console.WriteLine(string.IsNullOrEmpty(stringCheck2));          // True
Console.WriteLine(string.IsNullOrEmpty(stringCheck3));          // False
Console.WriteLine(string.IsNullOrEmpty(stringCheck4));          // False

// 2. string.IsNullOrWhiteSpace(string)

Console.WriteLine(string.IsNullOrWhiteSpace(stringCheck1));     // True
Console.WriteLine(string.IsNullOrWhiteSpace(stringCheck2));     // True
Console.WriteLine(string.IsNullOrWhiteSpace(stringCheck3));     // True
Console.WriteLine(string.IsNullOrWhiteSpace(stringCheck4));     // False

MyClass classTest = new MyClass(10);
var AAAA = classTest;
var BBBB = classTest;

Console.WriteLine($"{AAAA.X}, {BBBB.X}");       // 10, 10

classTest.X = 20;

Console.WriteLine($"{AAAA.X}, {BBBB.X}");       // 20, 20

//// Without dynamic

//object providerObj = container.GetDataProvider();
//Type hostType = providerObj.GetType();
//object dataObj = hostType.InvokeMember(
//    "GetData",
//    BindingFlags.InvokeMethod,
//    null,
//    providerObj,
//    null
//);
//int data = Convert.ToInt32(dataObj);

//// With dynamic

//dynamic host = container.GetDataProvider();
//int data = host.GetData();

//CartesianCoordinate coordinate = new(1, 2);

//// record 출력

//Console.WriteLine(coordinate.X);    // 1
//Console.WriteLine(coordinate.Y);    // 2
//Console.WriteLine(coordinate);      // CartesianCoordinate { X = 1, Y = 2 }

//var (X11, Y11) = coordinate;

//Console.WriteLine($"{X11},{Y11}");

//CartesianCoordinate coordinate1 = coordinate with { X = 3 };
//Console.WriteLine(coordinate1);

//coordinate1 = coordinate with { };

//Console.WriteLine(coordinate == coordinate1);   // True
//Console.WriteLine(object.ReferenceEquals(coordinate, coordinate1));     // False

var phoneNumbers = new string[2];
Person person1 = new("Nancy", "Davolio", phoneNumbers);
Person person2 = new("Nancy", "Davolio", phoneNumbers);
Console.WriteLine(person1 == person2); // output: True

Console.WriteLine(person1.PhoneNumbers[0]);
Console.WriteLine(person2.PhoneNumbers[0]);
person1.PhoneNumbers[0] = "555-1234";
Console.WriteLine(person1 == person2); // output: True
Console.WriteLine(person1.PhoneNumbers[0]);
Console.WriteLine(person2.PhoneNumbers[0]);

Console.WriteLine(ReferenceEquals(person1, person2)); // output: False

CargoList cargo = new("My Container", new List<string>() { "Stone", "Fish" });

Console.WriteLine(cargo);               // CargoList { ContainerName = My Container, Items = System.Collections.Generic.List`1[System.String] }
Console.WriteLine(cargo.Items[0]);     // Stone

cargo.Items[0] = "TV";

Console.WriteLine(cargo.Items[0]);      // TV

Log.WriteLog("Log message");

var itemsa = new List<CartesianCoordinate>();

var coordinateData = from itema in itemsa
                     where itema.Series.Contains("2D")
                     select new { itema.X, itema.Y };
foreach (var data in coordinateData)
{
    Console.WriteLine(string.Join(',', data.X));
    Console.WriteLine(string.Join(',', data.Y));
}

StockItem item = new StockItem
{
    Name = "Company",
    Code = "AAA-001",
    Price = 50,
};

Log.WriteLog(item.Name + " " + item.Code + " " + item.Price);

DerivedClass derived = new();
Console.WriteLine(derived.DataA);
//Console.WriteLine(derived.DataB);   // CS0122
//Console.WriteLine(derived.DataC);   // CS0122

List<IDataService> list = new List<IDataService>();
list.Add(new CSVData());
list.Add(new YAMLData());
foreach (var file in list) file.SaveData();
Console.WriteLine(list[0]);
Console.WriteLine(list[1]);

AbstractDerived abstractTest = new();
abstractTest.Message = abstractTest.ConsoleRead() ?? "Read failed";
abstractTest.ConsoleWrite(abstractTest.Message);

PartialClass partialClass = new PartialClass { A = 1, B = 2, C = 3 };

Console.WriteLine(partialClass.Sum());
Console.WriteLine(partialClass);

PrintClass.PrintConsole("AAA");

var varTest = "ABC";
//varTest = null;
Console.WriteLine(varTest);
string Combine(string str1, string str2) => str1 + str2;

// delegate 인스턴스화

StringCombineDelegate del = new StringCombineDelegate(Combine);

// delegate 호출

Console.WriteLine(del.Invoke("A", "B"));
Console.WriteLine(del("A", "B"));

void Combines(string str1, string str2, ConsoleWriteDelegate del) => del(str1 + str2);
void ConsoleWrite(string message) => Console.WriteLine(message);

// delegate 인스턴스화

ConsoleWriteDelegate sdel = new ConsoleWriteDelegate(ConsoleWrite);

// delegate 호출

Combines("A", "B", sdel);     // AB

Sender sender = new();
Receiver receiver = new(sender);
sender.Action();

public delegate string StringCombineDelegate(string str1, string str2);

public delegate void ConsoleWriteDelegate(string message);

public class ANT
{
    public int A = 0;
    public double B = 0;
}

public record Person(string FirstName, string LastName, string[] PhoneNumbers);

public record CargoList(string ContainerName, List<string> Items);

public record CartesianCoordinate(string Series, List<double> X, List<double> Y);

//public class CartesianCoordinate
//{
//    public string Series { get; init; }
//    public double X { get; init; }
//    public double Y { get; init; }

//    public CartesianCoordinate(double x, double y)
//    {
//        X = x;
//        Y = y;
//    }

//    public void Deconstruct(out double x, out double y)
//    {
//        x = X;
//        y = Y;
//    }

//    public override string ToString()
//    {
//        StringBuilder stringBuilder = new StringBuilder();
//        stringBuilder.Append(nameof(CartesianCoordinate));
//        stringBuilder.Append(" { ");

//        if (PrintMembers(stringBuilder))
//        {
//            stringBuilder.Append(" ");
//        }

//        stringBuilder.Append("}");

//        return stringBuilder.ToString();
//    }

//    protected virtual bool PrintMembers(StringBuilder stringBuilder)
//    {
//        stringBuilder.Append($"X = {X}, ");
//        stringBuilder.Append($"Y = {Y}");
//        return true;
//    }
//}

internal class MyClass
{
    public int X { get; set; }

    public MyClass(int x) => X = x;

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        return obj is MyClass && X == ((MyClass)obj).X;
    }

    public override string ToString() => X.ToString();

    public override int GetHashCode() => X.GetHashCode();
}

internal enum test
{
    a = 1,
    b = 2,
    c = 3,
}

[Flags]
internal enum StatusCode
{
    None = 0,       // 0
    Idle = 0b1,         // 1
    Run = 2,        // 2
    Warning = 4,   // 4
    Error = 0b_1000        // 8
}

internal struct testStruct
{
    public int a;
    public readonly string b;

    public testStruct(int a, string b)
    {
        this.a = a; this.b = b;
    }
}

//public record struct CartesianCoordinate
//{
//    public float X { get; init; }
//    public float Y { get; init; }

//    public CartesianCoordinate(float X, float Y)
//    {
//        this.X = X;
//        this.Y = Y;
//    }
//}

public static class Log
{
    public static void WriteLog(string message) => System.IO.File.AppendAllText(@"C:\Log\LogFile.txt", $"{DateTime.Now} - {message}");
}

public class Item
{
    public string Name;
    public double Price;
}

public sealed class StockItem : Item
{
    public string Code;
}

//public class StockDetails : StockItem
//{
//    public string Description;
//    public bool NeedToBuy;
//}

public class BaseClass
{
    public int DataA { get; set; }
    protected int DataB { get; set; }
    private int DataC { get; set; }
}

public class DerivedClass : BaseClass
{
    public int GetBaseClassSum()
    {
        int sum = 0;
        sum += DataA;
        sum += DataB;
        //sum += DataC;     // CS0122: 보호 수준 때문에 'BaseClass.DataC'에 액세스할 수 없습니다.
        return sum;
    }
}

public class BaseClass2
{ }

public class CSV
{ }

public class YAML
{ }

public interface IDataService
{
    public T LoadData<T>(string path);

    public void SaveData();
}

public class CSVData : IDataService
{
    private CSV Data;

    public CSVData()
    {
        Data = new();
        Data = LoadData<CSV>("CSVData.csv");
    }

    public T LoadData<T>(string path)
    {
        T data = default;
        // data loading...
        return data;
    }

    public void SaveData()
    {
        // data saving...
    }
}

public class YAMLData : IDataService
{
    private YAML Data;

    public YAMLData()
    {
        Data = new();
        Data = LoadData<YAML>("YAMLData.yaml");
    }

    public T LoadData<T>(string path)
    {
        T data = default;
        // data loading...
        return data;
    }

    public void SaveData()
    {
        // data saving...
    }
}

public abstract class AbstractBase
{
    public string Message { get; set; } = string.Empty;

    public abstract void ConsoleWrite(string message);

    public virtual string? ConsoleRead() => Console.ReadLine();
}

public class AbstractDerived : AbstractBase
{
    public override void ConsoleWrite(string message) => Console.WriteLine(message);    // 반드시 override 해야한다.

    public override string? ConsoleRead() => base.ConsoleRead();     // 추상 클래스의 정의를 이용
}

public partial class PartialClass
{
    // Fields

    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
}

public partial class PartialClass
{
    // Methods

    public int Sum() => A + B + C;

    public override string ToString() => $"A = {A}, B = {B}, C = {C}";
}

internal interface IPrintable
{
    static abstract void PrintConsole(string message);
}

internal class PrintClass : IPrintable
{
    public static void PrintConsole(string message) => Console.WriteLine(message);
}

internal interface IBase
{
    void Print(string message);
}

internal interface IDerived : IBase
{
    void PrintDerived(string message);
}

internal class InterfaceDerived : IDerived
{
    public void Print(string message) => Console.WriteLine("IBase.Print");

    public void PrintDerived(string message) => Console.WriteLine("IDerived.Print");
}

public class MessageEventArgs : EventArgs
{
    public string Message { get; set; }

    public MessageEventArgs(string message) => Message = message;
}

// Publishing class

public class Sender
{
    public delegate void MessageEventHandler(object sender, MessageEventArgs args);

    public event MessageEventHandler RaiseMessageEvent;

    public void Action() => RaiseMessageEvent?.Invoke(this, new MessageEventArgs("Send message"));
}

// Receiving class

public class Receiver
{
    public Receiver(Sender sender) => sender.RaiseMessageEvent += MessageReceived;

    private void MessageReceived(object sender, MessageEventArgs e) => Console.WriteLine($"Receiver received : {e.Message}");
}