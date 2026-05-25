def load_tasks(filename):
    """
    :dicts קוראת את הקובץ ומחזירה רשימה של
    [{'id': 1, 'status': 'PENDING', 'desc': 'ללמוד Python'}, ...]
    אם הקובץ לא קיים — מחזירה רשימה ריקה
    """
    new_list = []
    try:
        with open(filename, "r", encoding="utf-8") as f:
            for i in f:
                file_line = i.split("|")
                new_dict = {f"'id': {file_line[0]}, 'status': {file_line[1]}, 'desc': {file_line[2][:-1]}"}
                new_list.append(new_dict)
            return new_list
    except FileNotFoundError:
        return new_list

def save_tasks(filename, tasks):
    """
    שומרת את רשימת המשימות לקובץ
    description|status|id :פורמט כל שורה
    """
    with open(filename, "a", encoding="utf-8") as f:
        for i in tasks:
            f.write(f"{i['id']}|{i['status']}|{i['desc']}\n")


def add_task(filename, description):
    """
    :מוסיפה משימה חדשה עם
    מספר המשימה הבאה = ID -
    - status = 'PENDING'
    הפרמטר שניתן = description -
    """
    with open(filename, "r+", encoding="utf-8") as f:
        nom_line = 1
        for i in f.readlines():
            nom_line += 1
        f.write(f"\n{nom_line}|PENDING|{description}")


def complete_task(filename, task_id):
    """
    DONE-ל PENDING-מ id_task של משימה status משנה את
    לא קיים — מדפיסה הודעת שגיאה ID-אם ה
    """
    with open(filename, "r", encoding="utf-8") as f:
        lines = f.readlines()
    found = False
    new_line = []

    for i in lines:
        items = i.strip().split("|")
        if items[0] == str(task_id):
            items[1] = "DONE"
            found = True
        new_line.append("|".join(items) + "\n")

    if found:
        with open(filename, "w", encoding="utf-8") as f:
            f.writelines(new_line)
    else:
        print("ERROR!")

def list_tasks(filename):
    with open(filename, "r", encoding="utf-8") as f:
        for i in f:
            parts = i.strip().split("|")
            print(f"{'[v]' if parts[1] == 'DONE' else '[_]'} {parts[0]} | {parts[2]}")





def main():
    FILENAME = "tasks.txt"

    while True:
        print('\n=== To-Do List Manager ===')
        print('1..הצג משימות')
        print('2..הוסף משימה')
        print('3..סמן כהושלם')
        print('4.......יציאה')

        choice = input('בחירה: ')

        if choice == '1':
            list_tasks(FILENAME)
        elif choice == '2':
            desc = input('תיאור המשימה: ')
            add_task(FILENAME, desc)
            print('המשימה נוספה!')
        elif choice == '3':
            task_id = int(input('משימה מספר: '))
            complete_task(FILENAME, task_id)
        elif choice == '4':
            print('להתראות!')
            break
        else:
            print('בחירה לא תקינה')


if __name__ == '__main__':
    main()