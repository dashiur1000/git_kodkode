from fastapi import  FastAPI

app = FastAPI()

@app.get("/")
def get_my_api():
    return {"service": "my-api", "version": "1.0"}


@app.get("/users/domin")
def get_domin():
    return {"role": "admin", "access": "full"}


@app.get("/users/{user_id}")
def get_user_id(user_id: int, name: str, email: str):
    return {"user_id": user_id, "name": name,"email": email}

