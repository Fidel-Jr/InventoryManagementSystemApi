Inventory Management System API

A scalable and secure API for managing product inventory with automated stock alerts.

🚀 Features

✔ Product Management
• Full CRUD operations
• Track stock levels and quantities

✔ Low Stock Alert System
• Background job runs every 1 minute
• Detects products below threshold (default: 10)
• Records alerts in the Notifications table

✔ Clean Architecture
• Controller → Service → Repository pattern
• EF Core for database operations
• Fully dependency-injected and maintainable

✔ Extensible Design
• Easy add-on for Email/SMS/Push notifications
• Ideal for scaling into enterprise-grade systems

🧰 Tech Stack
Technology	Usage
ASP.NET Core 9.0	API Framework
Entity Framework Core	ORM
PostgreSQL	Database
BackgroundService / IHostedService	Automated tasks
Dependency Injection	Architecture
⚙️ Getting Started
✅ 1️⃣ Clone the Repository
git clone https://github.com/<your-username>/InventoryManagementAPI.git
cd InventoryManagementAPI

✅ 2️⃣ Configure the Database

Update appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=inventory_db;Username=postgres;Password=yourpassword"
}


⚠ Make sure PostgreSQL is installed and running
Replace yourpassword with your actual credentials

Apply migrations:

dotnet ef database update

✅ 3️⃣ Run the API
dotnet run


You should see:

⏰ Background job started.
🔍 Checking low stock...

🔁 Low Stock Background Job

Runs every 1 minute:

Checks products with Quantity < 10

Inserts a notification into DB

Sample Notification Record
Id	Message	CreatedAt	IsRead
1	⚠️ Product 'Milk' is low (Qty: 5)	2025-10-22T12:00:00Z	False
🤝 Contributing

Pull requests are welcome!
For major changes, please open an issue to discuss what you'd like to modify.
