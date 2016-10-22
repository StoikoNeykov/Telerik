# Simple Facotry
### Creational Design Pattern

## Обобщение
Simple factory се използва, когато трябва да се централизира създаването на обекти на едно място.
Това помага за запазване на single responsibility принципа.
Често се използва за скриване на сложна логика около създаването на конкретния обект.
Дoбавянето на нови класове обикновено се случва с промяна на кода в самия клас. 
Възможно е да се постигне с наследяваме или с използването на Decorator patern. 

## Схема

![alt text](imgs/factory_pattern.jpg)

###### Simple Factory
~~~c#
public IShape GetShape(ShapeType type)
{
    switch(type)
    {
        case ShapeType.Circle: return new Circle();
        case ShapeType.Square: return new Square();
        case ShapeType.Triangle: return new Tringle();
        case ShapeType.Rectangle: return new Rectangle();
        default throw new ArgumentException("Invalid shape type")
    }
}
~~~
