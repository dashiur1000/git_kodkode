from fastapi import FastAPI
from datetime import datetime

app = FastAPI()

@app.get("/status")
def time():
    return {"server_name": "my-server", "current_time": datetime.now()}