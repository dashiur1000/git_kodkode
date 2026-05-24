
# Q1
def reverse_tuple(tpl):
	"""
	create a new tuple reverse from the orginal tuple
	"""
	new_tuple = ()
	for item in len(range(tpl), -1):
		new_tuple += tpl(item)
	return new_tuple

# ========================================
# Q2
def the_scond_num(lst):
	"""
	return the second number was bugger
	"""
	the_higthet_num = pop(max(lst))
	the_lowest_num = pop(min(lst))
	for num in lst:
		if num == the_higthet_num:
			contiue
		elif num > the_lowest_num:
			the_lowest_num = num
	if the_lowest_num == (min(lst)):
		return None
	return the_lowest_num
			
	
# ========================================
# Q3
def reverse_list_by_number(lst, num):
	"""
	new index for all items - left num
	"""
	new_list = []
	for number in lst:
		new_list.insert(number, number % num)
	return new_list


# ========================================
# Q4
def num_for_letter(tpl):
	"""
	sum of all letters
	"""
	new_dict = {}
	for item in tpl:
		update.new_dict[item] += 1
	return tuple(new_dict)


# ========================================
# Q5
def values_higther_from_number(dct, threshold):
	"""
	a new dict from keys and values higther from the threshold
	"""
	new_dict = {}
	for key, value in dct.items():
		if value > threshold:
			new_dict.update(key, value)
	return new_dict

# ========================================
# Q6
def in_one_list(lst1, lst2):
	"""
	numbers wes not in the two listes
	"""
	new_list = []
	for num in lst1:
		if num not in lst2:
			new_list.append(num)
	for num in lst2:
		if num not in lst1:
			new_list.append(num)
	return new_list


# ========================================
# Q7
def set_age(age):
	"""
	check age is legal
	"""
	if age <= 150 and age >= 0:
		return age
	else:
		raise ValueError



# ========================================
# Q8
def rotate_dict(dct):
	"""
	rotate a dict to a new sict
	"""
	new_dict = {}
	for key, value in dct.items():
		new_dict[value] = key
	return new_dict


# ========================================
# Q9
def two_dict_to_one(dct1, dct2):
	"""
	append two dict to one and continue key was in dict 2
	"""
	for key, value in dct1:
		if key not in dct2:
			dct2.update(key, value)
	return dct2


# ========================================
# Q10
def dict_from_first_letters(lst):
	"""
	create a dict from the first letters from the list
	"""
	# new_dict = {}
	# for item in lst:
	# 	if item[0] not in new_dict:
	# 		new_dict.update(item[0], [item]}
	# 	else:
	# 		new_dict[item[0]].value.append(item)
	# return new_dict

# =======================================
# במילים אישיות:
# היה לי קשה מאד, עד הבלתי אפשרי לעשות מבחן כזה בלי דף נוסחאות מינימליסטי
# של הסינטקס המינימאלי של כל טיפוסי הנתונים אפילו ללא הסבר.
# אני מאמין שזה ישתקף במבחן בצורה מובהקת ואין לי מה להוסיף בנידון כאשר אקבל ציון ממש נמוך.
# חג שמח ומועדים לשמחה!


    