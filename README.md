**# InventoryManagementSystemApi
Scalable and Secured API for any Product Inventory Management System
**

🚀 Features
✅ Product Management
Create, Read, Update, and Delete (CRUD) products

Track stock levels per product

✅ Low Stock Alert System
Background job runs every 1 minute
Detects products below a set threshold (default: 10)
Saves alerts to the Notifications table in the database

✅ Clean Architecture
Controller → Service → Repository layers
EF Core for data access
Dependency Injection for maintainability

✅ Extensible
Easy to plug in Email/SMS or other notification systems later
Follows best practices for background processing and scoped services


⚙️ Technologies Used
ASP.NET Core 9.0
Entity Framework Core
PostgreSQL
BackgroundService / IHostedService
Dependency Injection


🛠️ Getting Started
1️⃣ Clone the repository
git clone https://github.com/<your-username>/InventoryManagementAPI.git
cd InventoryManagementAPI


🛠️ 2️⃣ Configure the Database
This project uses PostgreSQL as the database.
Open your appsettings.json and update your connection string like this:
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=inventory_db;Username=postgres;Password=yourpassword"
}

💡 Notes
Make sure PostgreSQL is installed and running locally.

Replace yourpassword with your actual PostgreSQL password.

If you’re using pgAdmin or a hosted PostgreSQL (e.g., Supabase, Neon, Render, etc.), update the connection details accordingly.

You can change the database name (inventory_db) to whatever you prefer.

To apply migrations and set up your database, run the following commands in your terminal:

dotnet ef database update

This will create all required tables automatically.


4️⃣ Run the API
dotnet run

You should see logs like:
info: LowStockBackgroundJob[0]
      ⏰ Background job started.
info: LowStockBackgroundJob[0]
      🔍 Checking low stock...
By default, the job runs every hour and checks for any product with quantity < 10.

🔁 Background Job Logic

Every 1 minute:

The background job runs automatically.

It queries the database for products with Quantity < 10.

For each low-stock product, it creates a record in the Notifications table.

This happens silently in the background — no manual trigger needed.

🧩 Example Notification Record
Id	Message	CreatedAt	IsRead
1	⚠️ Product 'Milk' is low on stock (Qty: 5).	2025-10-22T12:00:00Z	false

🧑‍💻 Author

[Your Name]
📧 fidelsalongacolinares04.com
]
🌐 yourportfolio.com

If you found this useful, please ⭐ star the repo on GitHub!
