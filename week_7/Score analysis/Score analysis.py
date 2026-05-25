# 1
def create_grades_file(filename):
    students = [
    ("Dan", [85, 90, 78]),
    ("MOMO", [92, 88, 95]),
    ("Yoni", [70, 65, 80]),
    ("Avi", [100, 95, 98]),
    ("Sara", [60, 72, 68]),
    ]
    with open(filename, "w", encoding="utf-8") as f:
        students_str = ""
        for i in students:
            i_str = str(i)
            students_str += i_str.join(i_str)
            students_str += "\n"


        f.write(students_str)

create_grades_file("grades.txt")