def no_duplicates(arr):
    new_arr = []
    for i in arr:
        if i not in new_arr:
            new_arr.append(i)
    return new_arr


print(no_duplicates([3, 1, 4, 1, 5, 9, 2, 6, 5, 3]))