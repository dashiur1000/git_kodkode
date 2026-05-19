# 1
count = 0
def bump():
    def value():
        global count
        count += 1
        return count
    return value


# 2
def make_counter():
    counter = 0
    def returned():
        nonlocal counter
        counter += 1
        return counter
    return returned


# 3
x = "global"
def outer():
    x = "enclosing"
    def inner():
        x = "local"
        print(x)
    inner()
    print(x)
outer()
print(x)


# 4
list1 = [1, 2, 3]
print(list(range(5)))


# 9
def add_item(item):
    bag = []
    bag.append(item)
    return bag