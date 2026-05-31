from fastapi import FastAPI, HTTPException

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
        if b != 0:
            result = a / b
        else:
            raise HTTPException(status_code=400, detail="ERROR! ZeroDivisionError")
    else:
        raise HTTPException(status_code=400, detail="ERROR! invalid error")
    return {"operation": op, "result": result}
