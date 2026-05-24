# 1
with open("diary.txt", "w", encoding="utf-8") as f:
    f.write("2024-01-15 Had a busy day on the project\n2024-01-16 P-Pyth-in Fil Handlin on I learned\n2024-01-17 Completed the first exercise")
    print("The diary was created successfully")
    f.seek(0)
with open("diary.txt", "r", encoding="utf-8") as f:
    read_file = f.read()
    print(read_file)

# 2
def add_entry(filename, date, content):
    with open(filename, "a", encoding="utf-8") as f:
        f.write(f"{date}: {content}\n")

add_entry("diary.txt", "2024-01-15", "It was a busy day on the project")
add_entry("diary.txt", "2024-01-16", "I learned about File Handling c-Python")
add_entry("diary.txt", "2024-01-17", "I completed the first exercise")
add_entry("diary.txt", "2024-01-18", "Wonderful day — I finished exercise 1!")


def search_diary(filename, keyword):
    """
    keyword מחזיר רשימה של שורות שמכילות את
    """
    results = []
    with open(filename, "r") as f:
        read_file = f.readlines()
        for line in read_file:
            if keyword in line:
                results.append(f"{line.strip()}\n")
    return results
print(search_diary("diary.txt", "2024-01-17"))