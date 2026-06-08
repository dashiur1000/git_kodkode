from MySQLdb.constants.ER import INSERT_INFO
from fastapi import FastAPI, HTTPException
import uvicorn
import db_messages

app = FastAPI()

@app.post("/setup")
def run_setup():
    return {"status": "ok", "table": "messages"}


@app.get("/schema")
def get_schema():
    columns = db_messages.get_schema()
    return {"columns": columns}



@app.get("/messages/{message_id}", status_code=200)
def get_by_id(message_id: int):
    message = db_messages.get_message_by_id(message_id)
    if not message:
        raise HTTPException(status_code=404, detail="message not found")
    return message


@app.get("/messages")
def get_messages():
    all_messages = db_messages.get_all_messages()
    return {"messages": all_messages}


@app.get("/messages/{classification}")
def get_all_by_classification(classification: str):
    by_classification = db_messages.get_by_classification(classification)
    return {"messages" :by_classification}




@app.put("/messages/{message_id}", status_code=200)
def update_message(message_id, data: dict):
    message = db_messages.update_message(message_id, data)
    if not message:
        raise HTTPException(status_code=404, detail="message not found")
    return message


@app.delete("/messages/{message_id}", status_code=200)
def delete_message(message_id):
    message = db_messages.delete_message(message_id)
    if not message:
        raise HTTPException(status_code=404, detail="message not found")
    return message



@app.post("/messages", status_code=201)
def new_message(new_message: dict):
    new_id = db_messages.create_message(new_message["unit"], new_message["classification"], new_message["content"], new_message["source"])
    return {"status": "created", "id": new_id}



if __name__ == "__main__":
    uvicorn.run("main_messages:app", port=8000, reload=True)