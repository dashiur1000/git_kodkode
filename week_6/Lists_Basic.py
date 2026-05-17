# 1
import copy

from flask.logging import has_level_handler


def sum_of_list(lst):
    sum_all_numbers = 0
    for index in lst:
        sum_all_numbers += index
    return sum_all_numbers


# 2
def max_element(lst):
    max_number = 0
    for index in lst:
        if index > max_number:
            max_number = index
    return max_number


# 3
def count_occurrences(lst, value):
    num_value = 0
    for index in lst:
        if index == value:
            num_value += 1
    return num_value


# 4
def reverse_list(lst):
    new_list = []
    for index in range(len(lst)):
        new_list.append(lst.pop())
    return new_list


# 5
def remove_duplicates(lst):
    new_list = []
    for index in lst:
        if index in new_list:
            continue
        else:
            new_list.append(index)
    return new_list


# 6
def second_largest(lst):
    if len(lst) > 2:
        new_list = set(copy.deepcopy(lst))
        largest_number = max(new_list)
        new_list.remove(largest_number)
        if len(new_list) == 0:
            return "The list is built from the same number"
        largest_number = max(new_list)
    elif len(lst) == 2:
        if lst[0] != lst[1]:
            largest_number = min(lst)
        else:
            return "The list is built from the same number"
    elif len(lst) == 0:
        return "There is not numbers"
    else:
        largest_number = max(lst)

    return largest_number

# 7
def merge_two_sorted_lists(lst1, lst2):
    all_list = [lst1, lst2]
    new_list = []
    for index in all_list:
        new_list.extend(index)
    new_list.sort()
    return new_list

# 8
def rotate_a_list(lst, num):
    new_list = []
    for index in range(len(lst)):
        new_list.insert((index+num) % len(lst), lst[index])
    return new_list