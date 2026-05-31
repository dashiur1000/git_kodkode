from fastapi import FastAPI

app = FastAPI()


@app.get("/ping")
def get_status():
    return {"status": "pong"}

@app.get("/greet/{name}")
def get_hello(name: str):
    return {"message": f"hello, {name}!"}