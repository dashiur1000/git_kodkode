import uvicorn
from fastapi import FastAPI

app = FastAPI()

@app.get("/greet/")
def greet_name(name="world"):
    return {"message: hello:", name, "!"}

if __name__ == '__main__':
    uvicorn.run(app, host="127.0.0.1", port=8000)