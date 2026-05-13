def check_new_name(new_name):
    if not new_name or len(new_name) < 2:
        print("Error: invalid name")
        return None
    return new_name

def check_new_grades(new_grade):
    if new_grade < 0 or new_grade > 100:
        print("Error: grade must be 0-100")
        return None
    return new_grade

def add_students(names, grades, new_name, new_grade):
    names.append(new_name)
    grades.append(new_grade)

def calculate_stats(grades):
    total = sum(grades)
    average = total / len(grades)
    top_count = sum(1 for grade in grades if grade >= 90)
    failing_count = sum(1 for grade in grades if grade < 56)
    return (total, average, top_count, failing_count)

def print_report(names, grades, average, top_count, failing_count):
    print("=== Student Report ===")
    for i in range(len(names)):
        print(f"  {names[i]}: {grades[i]}")
    print(f"Average: {average:.1f}")
    print(f"Top students: {top_count}")
    print(f"Failing: {failing_count}")

def save_to_file(names, grades):
    with open("students.txt", "w") as f:
        for i in range(len(names)):
            f.write(f"{names[i]},{grades[i]}\n")



def manage_students(names, grades, new_name, new_grade):
    new_name = check_new_name(new_name)
    new_grade = check_new_grades(new_grade)
    if new_name == None or new_grade == None:
        return names, grades
    add_students(names, grades, new_name, new_grade)
    stats = calculate_stats(grades)
    average = stats[1]
    top_count = stats[2]
    failing_count = stats[3]
    print_report(names, grades, average, top_count, failing_count)
    save_to_file(names, grades)
    return names, grades


manage_students(["david", "miri"], [90, 85], "fff", 100)