def reverse(arr):
    new_arr = []
    for i in range(len(arr)):
        new_arr.append(arr[-(i+1)])
    return new_arr


print(reverse([4, 7, 2, 9, 1, 5]))