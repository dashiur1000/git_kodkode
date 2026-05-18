from math import sqrt


# 1
def sum_of_tuple(tpl):
    sum_all_number = 0
    for numbers in tpl:
        sum_all_number += numbers
    return sum_all_number


# 2
def maximum_element(tpl):
    max_number = tpl[0]
    for number in tpl:
        if number > max_number:
            max_number = number
    return max_number


# 3
def count_occurrences(tpl, num):
    counter = 0
    for number in tpl:
        if number == num:
            counter += 1
    return counter


# 4
def reverse_a_tuple(tpl):
    new_tuple = []
    for num in range(len(tpl)-1, -1, -1):
        new_tuple.append(tpl[num])
    return tuple(new_tuple)


# 5
def swap_pairs(tpl):
    new_tuple = []
    for i in range(0, len(tpl)-1, 2):
        new_tuple.append(tpl[i+1])
        new_tuple.append(tpl[i])
    return tuple(new_tuple)


# 6
def maximum_and_minimum(tpl):
    max_number = tpl[0]
    min_number = tpl[0]
    for number in tpl:
        if number > max_number:
            max_number = number
        elif number < min_number:
            min_number = number
    return min_number, max_number


# 7
def distance_between_points(tpl1, tpl2):
    x1, y1 = tpl1
    x2, y2 = tpl2
    x = (x1 - x2) ** 2
    y = (y1 - y2) ** 2
    sum_all = x + y
    d = (sqrt(sum_all))
    return d


# 8
def merge_and_sort(tpl1, tpl2):
    new_tuple = tpl1 + tpl2
    sorted_tuple = sorted(new_tuple)
    return sorted_tuple


# 9
def frequency_table(tpl):
    new_dict = {}
    for key in tpl:
        if key not in new_dict:
            new_dict[key] = 1
        else:
            new_dict[key] += 1
    new_tuple = tuple(new_dict.items())
    return new_tuple


# 10
def rotate_a_tuple(tpl, num):
    new_list = []
    for index in range(len(tpl)):
        new_list.insert((index + num) % len(tpl), tpl[index])
    new_tuple = tuple(new_list)
    return new_tuple