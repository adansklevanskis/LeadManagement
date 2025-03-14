# Lead Management Application

A single-page application (SPA) for managing job leads, built using **Angular** for the frontend, **.NET Core 6** for the backend API, and **SQL Server** as the database.

---

## **Features**
- Tabs for managing **Invited Leads** and **Accepted Leads**.
- Functionality to:
  - Accept a lead (applies a discount of 10% if the price is above $500).
  - Decline a lead.
- Email notification simulation for accepted leads (logs to a file).
- Responsive UI styled with **Bootstrap** and **Font Awesome**.

---

## **Technologies Used**
### Frontend
- Angular
- Bootstrap 5
- Font Awesome

### Backend
- .NET Core 6 Web API
- MediatR (CQRS pattern)
- Entity Framework Core (SQL Server)

### Database
- SQL Server

---

## **Prerequisites**
Before starting, ensure you have the following installed on your system:
- Node.js (>=14.x) and npm (>=6.x)
- Angular CLI (>=15.x) - Install using:
  ```bash
  npm install -g @angular/cli
