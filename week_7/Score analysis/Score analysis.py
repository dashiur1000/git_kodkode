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
            students_str += i_str.strip("(").strip(")").replace("'", "")
            students_str += "\n"

        f.write(students_str)

create_grades_file("grades.txt")

def calculate_averages(filename):
    '''
    מחשבת ממוצע לכל סטודנט ,txt.grades קוראת
    {שם: ממוצע} dict :מחזיר
    '''
    averages = {}
    with open(filename, "r", encoding="utf-8") as f:
        for i in f:
            line = i.split(",", 1)
            numbers = line[1].replace("[", "").replace("]", "").replace(" ", "").split(",")
            sumi = 0
            for num in numbers:
                sumi += int(num)
            avg = sumi / len(numbers)
            averages.setdefault(line[0], avg)
    return averages



# 3
def save_results(averages, output_filename):
    '''
    :filename_output כותבת לקובץ
    שורה ראשונה: כותרת
    שורות הבאות: שם וממוצע, ,ממויי ממגבו ללנמו
    '''
    if isinstance(averages, dict):
        averages_items = averages.items()
    else:
        averages_items = averages

    sorted_averages = sorted(averages_items, key=lambda x: x[1], reverse=True)

    with open(output_filename, 'w', encoding='utf-8') as f:
        f.write("=== Student Results ===\n")
        for name, avg in sorted_averages:
            f.write(f"{name}: {avg:.1f}\n")