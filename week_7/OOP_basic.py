# 1
class Dog:
    """
    Represents a dog with a name that can bark.
    """
    def __init__(self, name):
        self.name = name

    def bark(self):
        return self.name + " says woof"

rex = Dog("rex")
# print(rex.bark())


# 2
class Rectangle:
    """
    docstring
    """
    def __init__(self, width, height):
        self.width = width
        self.height = height

    def area(self):
        return self.height * self.width

area1 = Rectangle(3, 4)
# print(area1.area())


# 3
class Counter:
    """

    """
    def __init__(self, counter = 0):
        self.counter = counter

    def value(self):
        return self.counter

    def increment(self):
        self.counter += 1

c = Counter()
c.increment()
c.increment()
# print(c.value())


# 4
class Point:
    """
    docstring
    """
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __str__(self):
        return f"({self.x}, {self.y})"

c1 = Point(5, 6)
# print(c1)


# 5
class BankAccount:
    """
    Represents a simple bank account with deposit and withdraw functionalities.
    """
    def __init__(self, balance = 0):
        self.balance = balance

    def deposit(self, amount):
        self.balance = self.balance + amount
        return self.balance

    def withdraw(self, amount):
        if amount < self.balance:
            self.balance = self.balance - amount
            return self.balance
        else:
            return self.balance


# 6
class Temperature:
    """
    docstring
    """
    def __init__(self, temp):
        self.temp = temp

    def to_fahrenheit(self):
        return self.temp * (9/5) + 32

c2 = Temperature(100)
# print(c2.to_fahrenheit())


# 7
class Student:
    school = "Kodcode"
    def __init__(self, name):
        self.name = name

    def __str__(self):
        return self.name

dudi = Student("dudi")
yoel = Student("yoel")

dudi.name = "david"
# print(dudi)
# print(yoel)

# 8
class Player:
    """
    docstring
    """
    counter = 0
    def __init__(self, name):
        self.name = name
        Player.counter += 1


a = Player("d")
b = Player("b")
# print(Player.counter)


# 9
class Money:
    """
    docstring
    """
    def __init__(self, amount):
        self.amount = amount

    def is_more_than(self, other):
        return self.amount > other.amount

m1 = Money(100)
m2 = Money(50)
# print(m1.is_more_than(m2))


# 10
class Playlist:
    """
    docstring
    """
    def __init__(self, list_of_song_file):
        self.list_of_song_file = list_of_song_file

    def add(self, title):
        self.list_of_song_file.append(title)

    def remove(self, title):
        if title in self.list_of_song_file:
            self.list_of_song_file.remove(title)

    def count(self):
        sumi = 0
        for i in self.list_of_song_file:
            sumi += 1
        return sumi

    def __str__(self):
        return f"{self.list_of_song_file}"

# p1 = Playlist(["menucha_vesimcha", "av_harachamim"])
# print(p1.__str__())
# p1.add("marsh")
# print(p1.__str__())
# print(p1.count())
# p1.remove("marsh")
# print(p1.__str__())
# print(p1.count())