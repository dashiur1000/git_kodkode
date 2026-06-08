from uuid import main

from fastapi import FastAPI
import db
import uvicorn

app = FastAPI()

@app.post("/setup")
def run_setup():
    return {"status": "setup triggered"}

@app.get("/schema")
def get_schema():
    columns = db.get_schema()
    return {"columns": columns}

@app.get("/soldiers")
def ged_all_soldiers():
    return {"soldiers": []}

@app.post("/new_soldier")
def create_new_soldier(new_soldier: dict):
    new_soldier = db.create(new_soldier["name"], new_soldier["rank"], new_soldier["unit"], new_soldier["active"])
    return new_soldier



if __name__ == "__main__":
    uvicorn.run("main:app", reload=True)