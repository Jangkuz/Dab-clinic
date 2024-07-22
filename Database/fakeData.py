from faker import Faker
import pyodbc

fake = Faker()

# Connect to the SQL server database
conn = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-HP-ELIT;DATABASE=Dab_clinic;UID=sa;PWD=12345')

# Create a cursor object
cursor = conn.cursor()

# Define the number of records to generate
num_records = 50

# Loop over the number of records and insert fake data into the table
for i in range(num_records):
    # Generate fake data using Python Faker library
    username = 'abc' + str(i)
    email = 'abc@gmail.com'
    password = '12345'
    name = fake.name()
    date_of_birth = fake.date_of_birth()
    gender = 'Male'
    address = fake.address()
    # phone_number = fake.phone_number()
    phone_number = '123456789'
    role = i % 4

    # Insert fake data into the SQL server table
    cursor.execute("INSERT INTO [dbo].[Account] (username, email, password_hash, fullname, birthdate, gender, phone, role) VALUES (?, ?, ?, ?, ?, ?, ?, ?)",
                   (username, email, password, name, date_of_birth, gender, phone_number, role))

# Commit the changes
conn.commit()

# Close the cursor and the connection
cursor.close()
conn.close()