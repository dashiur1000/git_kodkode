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
    elements_in_two = list(a ^ b)
    return elements_in_two


# 5
def is_subset(lst1, lst2):
    set1, set2 = set(lst1), set(lst2)
    new_set = set1 & set2
    if list(new_set) != lst1:
        return False
    return True


# 6
def unique_characters(string):
    text = set(string)
    if len(text) != len(string):
        return False
    return True


# 7
def first_repeated_element(lst):
    set_num = set()
    for i in lst:
        if i in set_num:
            return i
        set_num.add(i)
    return None


# 8
def distinct_words(string):
    str_set = set(string.lower().split())
    return len(str_set)


# 9
def pair_sum_exists(lst, target):
    num_set = set()
    for i in lst:
        num = target - i
        if num in num_set:
            return True
        num_set.add(i)
    return False


# 10
def symmetric_difference(lst1, lst2):
    list_duble = []
    for item in lst1:
        if item in lst2:
            list_duble.append(item)
    for num in list_duble:
        lst1.remove(num)
        lst2.remove(num)
    set_from_list = set(lst1).union(lst2)
    return list(set_from_list)