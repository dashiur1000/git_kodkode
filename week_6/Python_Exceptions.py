#  1
def safe_int(s):
    try:
        return int(s)
    except ValueError, TypeError:
        return None


#  2
def safe_divide(a, b):
    try:
        return a / b
    except ZeroDivisionError:
        return "undefined"


#  3
def get_value(d, key):
    try:
        return d[key]
    except KeyError:
        return "missing"


#  4
def parse_ints(values):
    new_list = []
    for i in values:
        try:
            new_list.append(int(i))
        except ValueError:
            continue
    return new_list


#  5
def set_age(age):
    try:
        if age >= 0 and age < 150:
            return age
        else:
            raise ValueError
    except ValueError:
        return "ValueError"


#  6
def retry(func, n):
    while n > 0:
        try:
            result = func()
            return result
        except Exception as e:
            Error = e
        finally:
            n -= 1
    raise Error


#  7
def count_errors(funcs):
    counter = 0
    for function in funcs:
        try:
            function()
        except Exception:
            counter += 1
    return counter



#  8
def load_config(path):
    try:
        with open(path, "r") as file:
            first_line = int(file.readline())
            return first_line
    except Exception as e:
        raise RuntimeError("failed to load config") from e