from flask import Flask, render_template, request, redirect, url_for
import requests

app = Flask(__name__)


get_url = "https://todoprojectapi.azurewebsites.net/api/Todo/get-todoitems"
post_url = "https://todoprojectapi.azurewebsites.net/api/Todo/add-todoitem"
delete_url = "https://todoprojectapi.azurewebsites.net/api/Todo/remove-todoitem"


@app.route('/', methods=['GET', 'POST'])
def home():
    if request.method == 'POST':

        name = request.form['name'].strip()  # Ensure name is not empty
        if not name:
            return "Error: Name field cannot be empty"

        new_item = {
            'name': name,
        }

        description = request.form.get('description')
        if description:
            new_item['description'] = description

        is_completed = request.form.get('isCompleted')
        if is_completed:
            new_item['isCompleted'] = bool(is_completed)

        deadline_date = request.form.get('deadlineDate')
        deadline_time = request.form.get('deadlineTime')

        if deadline_date and deadline_time:

            deadline = f"{deadline_date}T{deadline_time}"
            new_item['deadline'] = deadline

        response = requests.post(post_url, json=new_item)
        if response.status_code == 200:
            return redirect(url_for('home'))
        else:
            return "Error: Failed to add new item"

    else:

        response = requests.get(get_url)
        items = response.json()

        for item in items:
            if 'deadline' in item:
                item['deadline'] = item['deadline'].replace('T', ' ')

        return render_template('home.html', items=items)


@app.route('/delete/<int:item_id>', methods=['DELETE'])
def delete(item_id):
    response = requests.delete(f"{delete_url}/{item_id}")
    if response.status_code == 200:
        return redirect(url_for('home'))
    else:
        return "Error: Failed to delete item"


if __name__ == '__main__':
    app.run(debug=True)
