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
        for name, grades in students:
            line_to_str = ""
            for i in range(len(grades)):
                line_to_str += str(grades[i])
                if i < len(grades) - 1:
                    line_to_str += ", "
                else:
                    line_to_str += "\n"
            f.write(f"{name}: {line_to_str}")
# create_grades_file("grades.txt")

# 2
def calculate_averages(filename):
    '''
    מחשבת ממוצע לכל סטודנט ,txt.grades קוראת
    {שם: ממוצע} dict :מחזיר
    '''
    averages = {}
    with open("grades.txt", "r", encoding="utf-8") as f:
        file_to_read = f.readlines()
        for line in file_to_read:
            item = line.strip().split(": ")
            grades = [int(g) for g in item[1].split(", ")]
            name = item[0]
            average = round(sum(grades) / len(grades), 1)
            averages[name] = average
    return averages


# results = calculate_averages('grades.txt')
# for name, avg in results.items():
#     print(f'{name}: {avg}')


def save_results(averages, output_filename):
    '''
    :filename_output כותבת לקובץ
    שורה ראשונה: כותרת
    שורות הבאות: שם וממוצע, ,ממויי ממגבו ללנמו
    '''
    calculate_averages(output_filename)
    with open(output_filename, "w", encoding="utf-8") as f:
        f.write("=== Student Results ===")
        averages = dict(averages)
        averages2 = sorted(averages.items())
        for key, value in averages2.items():
            f.write(f"{key}, {str(value)}")

averages = calculate_averages('grades.txt')
save_results(averages, 'results.txt')