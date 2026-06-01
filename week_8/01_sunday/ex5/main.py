from fastapi import FastAPI, HTTPException

grades = {
"1": {"name": "Moshe", "grade": 88},
"2": {"name": "Yaakov", "grade": 75},
"3": {"name": "David", "grade": 92},
}

app = FastAPI()


@app.get("/students/top")
def highest_grade():
    best_student = None
    max_grade = 0
    for data in grades.values():
        if data["grade"] > max_grade:
            max_grade = data["grade"]
            best_student = data
    return best_student


@app.get("/students/average")
def class_average():
    sum_all_grades = 0
    number_of_grades = 0
    for grade in grades.values():
        sum_all_grades += grade["grade"]
        number_of_grades += 1
    average = sum_all_grades / number_of_grades
    return {"average": average}


@app.get("/students/count")
def number_of_students():
    return {"count": len(grades)}


@app.get("/students")
def all_students():
    return grades

@app.get("/students/{student_id}")
def one_student(student_id):
    if student_id in grades:
        return grades[student_id]
    else:
        raise HTTPException(status_code=404, detail="not found")
