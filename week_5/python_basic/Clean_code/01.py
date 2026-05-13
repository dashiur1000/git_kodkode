def adult_and_active_testing(name_list):
    updated_list = []
    for item in name_list:
        is_active = item[2]
        if (item[1] >= 18) and (is_active == True):
            updated_list.append(item[0])
    return updated_list

d = [
    ["Dan", 25, True],
    ["Noa", 16, True],
    ["Yael", 30, False],
]

print(adult_and_active_testing(d))