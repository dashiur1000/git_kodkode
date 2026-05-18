# 1
def remove_duplicates(lst):
    return list(set(lst))


# 2
def count_unique_elements(lst):
    all_numbers = set(lst)
    count = 0
    for items in all_numbers:
        count += 1
    return count


# 3
def common_elements(lst1, lst2):
    a = set(lst1)
    b = set(lst2)
    return list(a & b)


# 4
def elements_in_only_one(lst1, lst2):
    a = set(lst1)
    b = set(lst2)
    elements_in_two = list(a | b)
    new_list = a & b
    new_list.remove(elements_in_two[0])
    return new_list
print(elements_in_only_one( [1, 2, 3, 4], [3, 4, 5, 6]))