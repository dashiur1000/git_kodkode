# 1
def sum_values(dct):
    sum_all_values = 0
    for value in dct.values():
        sum_all_values += value
    return sum_all_values


# 2
def maximum_value(dct):
    max_item = max(dct, key=dct.get)
    return max_item


# 3
def count_characters(string):
    my_dict = {}
    for i in string:
        my_dict[i] = my_dict.get(i, 0) + 1
    return my_dict


# 4
def invert_dict(dct):
    new_dict = {}
    for key, value in dct.items():
        new_dict.setdefault(value, key)
    return new_dict


# 5
def merge_two_dictionaries(dct1, dct2):
    new_dict ={}
    new_dict.update(dct1)
    new_dict.update(dct2)
    return new_dict


# 6
def filter_by_value(dct, num):
    new_dict = {}
    for key, value in dct.items():
        if value > num:
            new_dict.setdefault(key, value)
    return new_dict


# 7
def group_by_first_letter(lst):
    new_dict = {}
    for item in lst:
        firs_letter = item[0]
        temporary_list = new_dict.get(firs_letter, [])
        temporary_list.append(item)
        new_dict[firs_letter] = temporary_list
    return new_dict


# 8
def word_frequency(string):
    new_dict = {}
    for item in string.split():
        new_dict[item] = new_dict.get(item, 0) + 1
    return new_dict


# 9
def common_keys(dct1, dct2):
    new_dict = {}
    for item in dct1, dct2:
        for key, value in item.items():
            new_dict[key] = new_dict.get(key, 0) + value
    max_item1 = max(new_dict, key=new_dict.get)
    new_dict.pop(max_item1)
    max_item2 = max(new_dict, key=new_dict.get)
    list_max = [max_item1, max_item2]
    return list_max


# 10
def most_frequent_value(dct):
    list_num = []
    for value in dct.values():
        list_num.append(value)
    dict_num = {}
    for item in list_num:
        dict_num[item] = dict_num.get(item, 0) + 1
    return max(dict_num, key=dict_num.get)



print(most_frequent_value({"a": 1, "b": 2, "c": 1, "d": 3, "e": 1}))