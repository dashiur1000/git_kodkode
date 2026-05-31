from fastapi import FastAPI

app = FastAPI()

@app.get("/calc/{a}/{op}/{b}")
def get_op(a: int, op: str, b: int):
    if op == "add":
        result = a + b
    elif op == "sub":
        result = a - b
    elif op == "mul":
        result = a * b
    elif op == "div":
        try:
            result = a / b
        except ZeroDivisionError:
            return "ERROR! ZeroDivisionError"
    else:
        raise TypeError("TypeError")
    return {f"operation: {op}, result: {a} {op} {b} = {result}"}
