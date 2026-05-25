def load_tasks(filename):
    """
    Loads tasks from a file and returns them as a list of dictionaries.

    Each dictionary contains 'id', 'status', and 'desc' keys. If the file
    does not exist, an empty list is returned.

    Args:
        filename (str): The path to the file containing the tasks.

    Returns:
        list: A list of dictionaries representing the tasks.
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
    Saves a list of tasks to a file.

    The tasks are appended to the file in the format: id|status|description.

    Args:
        filename (str): The path to the file where tasks will be saved.
        tasks (list): A list of task dictionaries to write to the file.
    """
    with open(filename, "a", encoding="utf-8") as f:
        for i in tasks:
            f.write(f"{i['id']}|{i['status']}|{i['desc']}\n")


def add_task(filename, description):
    """
    Adds a new task to the file with a 'PENDING' status.

    The task ID is automatically calculated based on the number of lines
    currently in the file.

    Args:
        filename (str): The path to the tasks file.
        description (str): The description of the new task.
    """
    with open(filename, "r+", encoding="utf-8") as f:
        nom_line = 1
        for i in f.readlines():
            nom_line += 1
        f.write(f"\n{nom_line}|PENDING|{description}")


def complete_task(filename, task_id):
    """
    Updates the status of a specific task from 'PENDING' to 'DONE'.

    If the given task ID is not found in the file, an error message is printed.

    Args:
        filename (str): The path to the tasks file.
        task_id (int): The ID of the task to be marked as completed.
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
    """
    Reads tasks from the file and prints them to the console.

    Displays completed tasks with '[v]' and pending tasks with '[_]'.

    Args:
        filename (str): The path to the tasks file.
    """
    with open(filename, "r", encoding="utf-8") as f:
        for i in f:
            parts = i.strip().split("|")
            print(f"{'[v]' if parts[1] == 'DONE' else '[_]'} {parts[0]} | {parts[2]}")





def main():
    """
    The main execution loop for the To-Do List Manager CLI application.
    """
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