def moving_zeros(nums):
    for i in range(len(nums)):
        if nums[i] == 0:
            nums.append(nums.pop(i))
    return nums




print(moving_zeros([1, 0, 5, 6, 0, 8]))